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
                if (!int.TryParse(Request.QueryString["cp"], out postID) || Request.QueryString["ct"] == null || !checkCateID_By_SEONAME(Request.QueryString["ct"].ToString()))
                {
                    //response ve page thong bao 404
                    Response.Redirect("Default.aspx");
                }
                load_postDetail(postID);
                load_pletFocusPost();
            }
        }

        private void load_postDetail(int postID)
        {
            var postData = _Posts.Where(p => p.Actived == true && p.Approved == true
               && p.CheckPageView == true && p.ID == postID).FirstOrDefault();
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
            //pletCommentBox.PostID = postID;
            //pletCommentBox.PostTitle = postData.Title;
            //pletCommentBox.CommentNumbers = postComment.Count();
            //pletCommentBox.Datasource = postComment;
            //pletCommentBox.DataBind();
        }
        //lay tieu_diem theo chu de
        void load_pletFocusPost()
        {
            var listData = _Posts.Where(p => p.Actived == true && p.Approved == true
               && p.CheckPageView == true && p.ApprovedOn.Value.Month == DateTime.Now.Month
               && p.Category.ID == intCateID || (p.Category.Parent != null && p.Category.Parent.ID == intCateID)).Select(p => new
               {
                   p.ID,
                   p.Title,
                   p.Description,
                   p.Avatar,
                   p.SeoUrl,
                   p.ApprovedOn,
                   p.PageView
               }).OrderByDescending(p => p.PageView).Take(5).ToList();

            //var data = clsPost.Load_Post_From_XML("Focus",5);
            pletFocusPost.Datasource = listData;
            pletFocusPost.DataBind();
        }
    }
}