using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewsVn.Impl.Context;
using NewsVn.Web.Utils;

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
            using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
            {
                var comments = ctx.PostCommentRepo.Getter.getEnumerable().OrderByDescending(c => c.UpdatedOn).ThenBy(c => c.PostID);
                rptCommentList.DataSource = ctx.PostCommentRepo.Getter.getPagedList(comments, pageIndex, pageSize).Select(c => new
                    {
                        c.ID,
                        c.Title,
                        c.Content,
                        c.Email,
                        c.UpdatedBy,
                        c.UpdatedOn,
                        PostID = c.Post.ID,
                        PostTitle = c.Post.Title,
                        PostUrl = c.Post.SeoUrl
                    });
                rptCommentList.DataBind();
            }
        }
    }
}