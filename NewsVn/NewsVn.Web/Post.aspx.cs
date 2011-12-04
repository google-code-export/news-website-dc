using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using NewsVn.Impl.Context;
using NewsVn.Web.Utils;

namespace NewsVn.Web
{
    public partial class Post : BaseUI.BasePage
    {
        private int intCateID = -1;
        private string strCateName;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (var ctx = new NewsVnContext(Utils.ApplicationManager.ConnectionString))
                {
                    int codePost = 0;
                    int.TryParse(Request.QueryString["cp"], out codePost);
                    load_postDetail(codePost, ctx);
                    load_pletFocusPost(ctx);
                    bindBannerRight(ctx);
                }
            }
        }
        void bindBannerRight(NewsVnContext ctx)
        {
            var bannerRightListID = ctx.BannerDetailRepo.Getter.getQueryable(c => c.Activated && c.TypePosition == 2).Select(c => c.ID).ToArray();
            if (bannerRightListID.Length >= 1)
            {   //lay random 1 list right banner
                var lstID = new List<int>();
                for (int i = 0; i <= (bannerRightListID.Length < 5 ? bannerRightListID.Length - 1 : 5); i++)
                {
                    if (bannerRightListID.Length <= 5)
                    {
                        for (int j = 0; j <= bannerRightListID.Length - 1; j++)
                        {
                            lstID.Add(bannerRightListID[j]);
                        }
                        break;
                    }
                    var randon = new Random();
                    int _randomIndex = randon.Next(0, bannerRightListID.Length - 1);
                    if (!lstID.Contains(bannerRightListID[_randomIndex]))
                    {
                        lstID.Add(bannerRightListID[_randomIndex]);
                    }
                }
                Control UC_PortletAdPost = LoadControl("~/Modules/AdBoxList.ascx");
                var bannerRightLists = ctx.BannerDetailRepo.Getter.getQueryable(a => lstID.Contains(a.ID)).OrderByDescending(a => a.Price).ToList();
                var _AdBoxList1 = ((Modules.AdBoxList)UC_PortletAdPost);
                _AdBoxList1.Datasource = bannerRightLists;
                _AdBoxList1.DataBind();
                adboxArea.Controls.Add(_AdBoxList1);
            }
        }
        private void load_postDetail(int postID, NewsVnContext ctx)
        {
            var postData = ctx.PostRepo.Getter.getOne(p => p.ID == postID);
            if (postData != null)
            {
                var postComment = ctx.PostCommentRepo.Getter
                .getQueryable(pc => pc.Post.ID == postID && pc.UpdatedOn <= DateTime.Now)
                .Select(pc => new
                {
                    pc.UpdatedOn,
                    pc.Content,
                    pc.Title,
                    pc.UpdatedBy,
                }).OrderByDescending(pc => pc.UpdatedOn);
                pletPostDetail.CountedComment = postComment.Count();
                pletPostDetail.AllowComment = postData.AllowComments;
                pletPostDetail.Datasource = postData;
                pletPostDetail.DataBind();

                //cateid by post
                intCateID = postData.CategoryID;
                strCateName = postData.Category.Name;
                //seo
                this.ExecuteSEO(postData.Title.Trim().Length > 0 ? postData.Title.Trim() : "Cổng thông tin điện tử 24/07",
                    clsCommon.RemoveUnicodeMarks(postData.Title).Replace('-', ' ') + " " + postData.Title,
                    clsCommon.hintDesc(postData.Description, 300));
                // Fix for static title : 2011/11/20
                //this.SiteTitle = " - " + postData.Title;
                //related post
                load_pletRelationPostList(postData, ctx);
                //commentbox
                pletCommentBox.PostID = postID;
                //check_PageView  - khong su dung pageview thi ko can update
                if (postData.CheckPageView)
                {
                    Allow_Update_PageView(postID, ctx); //25/10/2011
                }
            }
            else
            {
                Response.Redirect(HostName);
            }
        }
        private void Allow_Update_PageView(int postID, NewsVnContext ctx)
        {
            //chua xem thi cho add pageview
            if (Session[HttpContext.Current.Session.SessionID] == null)
            {
                Session[HttpContext.Current.Session.SessionID] = postID.ToString() + ",";
                update_PageView(postID, ctx);
            }
            else
            {
                var array = Session[HttpContext.Current.Session.SessionID].ToString().Split(',');
                var isExist = Array.FindAll(array, item => item.Equals(postID.ToString()));
                //session chua xem:length=0,
                if (isExist.Length == 0)
                {
                    Session[HttpContext.Current.Session.SessionID] = Session[HttpContext.Current.Session.SessionID].ToString() + postID.ToString() + ",";
                    update_PageView(postID, ctx);
                }
            }
        }
        private void update_PageView(int postID, NewsVnContext ctx)
        {
            var post = ctx.PostRepo.Getter.getOne(p => p.ID == postID);

            if (post != null)
            {
                post.PageView += 1;
                ctx.SubmitChanges();
            }
        }
        //lay tieu_diem theo chu de, pageview cao nhat trong thang
        void load_pletFocusPost(NewsVnContext ctx)
        {
            var _Posts = ctx.PostRepo.Getter.getQueryable(p => p.Actived == true && p.Approved == true);
            var listData = _Posts.Where(p => p.CheckPageView == true
            && p.Category.ID == intCateID || (p.Category.Parent != null && p.Category.Parent.ID == intCateID))
                .Where(p => p.ApprovedOn.Value.AddDays(30) >= DateTime.Now)
            .Select(p => new
            {
                p.ID,
                p.Title,
                p.Description,
                p.Avatar,
                p.SeoUrl,
                p.ApprovedOn,
                p.PageView
            }).OrderByDescending(p => p.PageView).Take(5);

            pletFocusPost.Datasource = listData;
            pletFocusPost.HostName = HostName;
            pletFocusPost.DataBind();
        }
        //lay post theo chu de  & <= post.approvedon && != viewstate('visitedID')
        void load_pletRelationPostList(Impl.Entity.Post postData, NewsVnContext ctx)
        {
            var _Posts = ctx.PostRepo.Getter.getQueryable(p => p.Actived == true && p.Approved == true);
            var listData = _Posts.Where(p => p.CategoryID == intCateID || (p.Category.Parent != null && p.Category.ParentID == intCateID))
           .Where(p => p.ApprovedOn <= postData.ApprovedOn && p.ID != postData.ID)
           .Select(p => new
           {
               p.ID,
               p.Title,
               p.Description,
               p.Avatar,
               p.SeoUrl,
               p.ApprovedOn,
               p.PageView
           }).OrderByDescending(p => p.ApprovedOn).Take(5);
            pletRelateionPostList.Datasource = listData;
            pletRelateionPostList.HostName = HostName;
            pletRelateionPostList.DataBind();
        }
    }
}