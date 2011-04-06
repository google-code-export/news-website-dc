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
        private int postID = -1;
        private bool checkCateID_By_SEONAME(string seoNAME)
        {
            var cate = _Categories.Where(c => c.SeoName == seoNAME && c.Actived == true).Select(c => new { c.ID }).ToList();
            if (cate.Count() > 0)
            {
                intCateID = cate[0].ID;
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
                if (!int.TryParse(Request.QueryString["cp"], out postID) || Request.QueryString["ct"] == null || !checkCateID_By_SEONAME(Request.QueryString["ct"]))
                {
                    //response ve page thong bao 404
                    Response.Redirect("Default.aspx");
                }
                load_postDetail(postID);
                load_pletFocusPost();
                load_pletRelationPostList();
            }
        }
       

        private void load_postDetail(int postID)
        {
            var postData = _Posts.Where(p => p.Actived == true && p.Approved == true
              && p.ID == postID).FirstOrDefault();
            if (postData==null)
            {
                //response ve page thong bao 404
                Response.Redirect("Default.aspx");
            }
            var postComment = _PostComments.Where(pc => pc.Post.ID == postID).Select(
                pc => new { 
                pc.CreatedOn,
                pc.Content,
                pc.Title,
                pc.CreatedBy,
                }).OrderByDescending(pc => pc.CreatedOn).ToList();
            pletPostDetail.CountedComment = postComment.Count();
            pletPostDetail.AllowComment = postData.AllowComments;
            pletPostDetail.Datasource = postData;
            pletPostDetail.DataBind();
            //commentbox
            pletCommentBox.PostID = postID;    
            //check_PageView  - khong su dung pageview thi ko can update
            if (postData.CheckPageView)
            {
                Allow_Update_PageView();
            }
        }
        private void Allow_Update_PageView()
        {
            if (Session[HttpContext.Current.Session.SessionID] == null)
            {
                Session[HttpContext.Current.Session.SessionID] = postID.ToString() + ",";
                update_PageView();
            }
            else
            {
                var array = Session[HttpContext.Current.Session.SessionID].ToString().Split(',');
                var isExist = Array.FindAll(array, item => item.Equals(postID.ToString())); 
                //session chua xem:length=0,
                if (isExist.Length == 0)
                {
                    Session[HttpContext.Current.Session.SessionID] = Session[HttpContext.Current.Session.SessionID].ToString() + postID.ToString() + ",";
                    update_PageView();
                }
            }
        }
        private void update_PageView()
        {
            var post = ApplicationManager.Entities.Posts.Where(p => p.ID == postID).FirstOrDefault();
            if (post != null)
            {
                post.PageView += 1;
                ApplicationManager.Entities.SaveChanges();
                ApplicationManager.UpdateCacheData<Data.Post>(ApplicationManager.Entities.Posts.Where( t => t.Approved && t.Actived));//set lai cache
            }
        }
        //lay tieu_diem theo chu de, pageview cao nhat trong thang
        void load_pletFocusPost()
        {
            var listData = _Posts.Where(p => p.Actived == true && p.Approved == true
                && p.CheckPageView == true
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
                }).OrderByDescending(p => p.PageView).Take(5).ToList();

            pletFocusPost.Datasource = listData;
            pletFocusPost.DataBind();
        }
        //lay post theo chu de  & <= post.approvedon && != viewstate('visitedID')
        void load_pletRelationPostList()
        {
            var listData = _Posts.Where(p => p.Actived == true && p.Approved == true
               && p.Category.ID == intCateID).Select(p => new
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
            pletRelateionPostList.DataBind();
        }
    }
}