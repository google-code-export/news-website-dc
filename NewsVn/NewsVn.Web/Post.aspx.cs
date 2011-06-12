using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewsVn.Web.Utils;

namespace NewsVn.Web
{
    public partial class Post : BaseUI.BasePage
    {
        private int intCateID = -1;
        private string strCateName;
        private bool checkCateID_By_SEONAME(string seoNAME)
        {
            var cate = _Categories.Where(c => c.SeoName == seoNAME && c.Actived == true).Select(c => new { c.ID,c.Name }).ToList();
            if (cate.Count() > 0)
            {
                intCateID = cate[0].ID;
                strCateName = cate[0].Name;
                return true;
            }
            else
                return false;

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //params querystring post: PostID,SeoName
            if (!IsPostBack)
            {
                try
                {
                    int codePost = int.Parse(Request.QueryString["cp"]);
                    checkCateID_By_SEONAME(Request.QueryString["ct"]);
                    load_postDetail(codePost);
                    load_pletFocusPost();
                }
                catch (Exception ex)
                {
                    clsCommon.WriteTextLog("Post.aspx - fnc: load_pletRelationPostList (codePost:" + Request.QueryString["cp"] + ", category:" + Request.QueryString["ct"] + " )", ex.Message.ToString());     
                }
            }
        }
       

        private void load_postDetail(int postID)
        {
            try
            {
                var postData = _Posts.Where(p => p.Actived == true && p.Approved == true
              && p.ID == postID).FirstOrDefault();

                var postComment = _PostComments.Where(pc => pc.Post.ID == postID).Select(
                    pc => new
                    {
                        pc.UpdatedOn,
                        pc.Content,
                        pc.Title,
                        pc.UpdatedBy,
                    }).OrderByDescending(pc => pc.UpdatedOn).ToList();
                pletPostDetail.CountedComment = postComment.Count();
                pletPostDetail.AllowComment = postData.AllowComments;
                pletPostDetail.Datasource = postData;
                pletPostDetail.DataBind();
                //seo
                BaseUI.BaseMaster.ExecuteSEO(postData.Title.Trim().Length > 0 ? postData.Title.Trim() : "Cổng thông tin điện tử 24/07", clsCommon.RemoveUnicodeMarks(postData.Title).Replace('-', ' ') + " " + postData.Title, clsCommon.hintDesc(postData.Description, 300));
                //related post
                load_pletRelationPostList(postData);
                //commentbox
                pletCommentBox.PostID = postID;
                //check_PageView  - khong su dung pageview thi ko can update
                if (postData.CheckPageView)
                {
                    Allow_Update_PageView(int.Parse(Request.QueryString["cp"]));
                }
            }
            catch (Exception ex)
            {
                clsCommon.WriteTextLog("Post.aspx - fnc: load_postDetail", ex.Message.ToString());    
            }
        }
        private void Allow_Update_PageView(int postID)
        {
            //chua xem thi cho add pageview
            if (Session[HttpContext.Current.Session.SessionID] == null)
            {
                Session[HttpContext.Current.Session.SessionID] = postID.ToString() + ",";
                update_PageView(postID);
            }
            else
            {
                var array = Session[HttpContext.Current.Session.SessionID].ToString().Split(',');
                var isExist = Array.FindAll(array, item => item.Equals(postID.ToString())); 
                //session chua xem:length=0,
                if (isExist.Length == 0)
                {
                    Session[HttpContext.Current.Session.SessionID] = Session[HttpContext.Current.Session.SessionID].ToString() + postID.ToString() + ",";
                    update_PageView(postID);
                }
            }
        }
        private void update_PageView( int postID)
        {
            var post = ApplicationManager.Entities.Posts.Where(p => p.ID == postID).FirstOrDefault();
            if (post != null)
            {
                post.PageView += 1;
                ApplicationManager.Entities.SaveChanges();
                //ApplicationManager.UpdateCacheData<Data.Post>(ApplicationManager.Entities.Posts.Where( t => t.Approved && t.Actived));//set lai cache
            }
        }
        //lay tieu_diem theo chu de, pageview cao nhat trong thang
        void load_pletFocusPost()
        {
            var listData = _Posts.Where(p =>p.CheckPageView == true
                && p.Category.ID == intCateID || (p.Category.Parent != null && p.Category.Parent.ID == intCateID))
                //.Where(p => p.ApprovedOn.Value.AddDays(30) >= DateTime.Now)
                .Select(p => new
                {
                    p.ID,
                    p.Title,
                    p.Description,
                    p.Avatar,
                    p.SeoUrl,
                    p.ApprovedOn,
                    p.PageView
                }).OrderByDescending(p => p.PageView).Take(5).ToList();

            pletFocusPost.Datasource = listData;
            pletFocusPost.HostName = HostName;
            pletFocusPost.DataBind();
        }
        //lay post theo chu de  & <= post.approvedon && != viewstate('visitedID')
        void load_pletRelationPostList(Data.Post postData)
        {
            string strid = postData.ID.ToString() + " | approvedon=" + postData.ApprovedOn.Value.ToString() + " | url:" + Request.RawUrl;
            try
            {
                var listData = _Posts.Where(p => p.Category.ID == intCateID || (p.Category.Parent != null && p.Category.Parent.ID == intCateID))
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
               }).OrderByDescending(p => p.ApprovedOn).Take(5).ToList();
                pletRelateionPostList.Datasource = listData;
                pletRelateionPostList.HostName = HostName;
                pletRelateionPostList.DataBind();
            }
            catch (Exception ex)
            {
                clsCommon.WriteTextLog("Post.aspx - fnc: load_pletRelationPostList | postID:" + strid, ex.Message.ToString());        
            }
        }
    }
}