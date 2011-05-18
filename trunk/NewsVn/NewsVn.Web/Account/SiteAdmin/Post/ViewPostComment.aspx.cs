using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsVn.Web.Account.SiteAdmin.Post
{
    public partial class ViewPostComment : BaseUI.SecuredPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = SiteTitle + "Quản lý bình luận";

            if (!IsPostBack)
            {
                this.LoadCommentList(1, 35);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.GoToCurrentPage();
        }

        private void GoToCurrentPage()
        {

        }

        private void GoToPage(int pageIndex, int pageSize)
        {

        }

        private void LoadCommentList(int pageIndex, int pageSize)
        {
            rptCommentList.DataSource = _PostComments.Select(c => new
            {
                c.ID, c.Title, c.Content,
                c.Email, c.CreatedBy, c.CreatedOn,
                PostID = c.Post.ID, PostTitle = c.Post.Title
            }).OrderByDescending(c => c.CreatedOn).ThenBy(c => c.PostID)
            .Skip((pageIndex - 1) * pageSize).Take(pageSize);
            rptCommentList.DataBind();
        }
    }
}