using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using NewsVn.Impl.Context;
using NewsVn.Web.Utils;

namespace NewsVn.Web.Account.SiteAdmin.Post
{
    public partial class ViewPostComment : BaseUI.SecuredPage
    {
        static string orderBy = string.Empty;

        static string _orderColumn = string.Empty;
        protected string OrderColumn
        {
            get { return _orderColumn; }
            set { _orderColumn = value; }
        }

        static string _orderDirection = string.Empty;
        protected string OrderDirection
        {
            get { return _orderDirection.ToLower(); }
            set { _orderDirection = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            SiteTitle += "Quản lý bình luận";

            if (!IsPostBack)
            {
                this.GoToPage(1, int.Parse(ddlPageSize.SelectedValue));
            }
        }

        protected void Sorter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _orderColumn = ddlSortColumn.SelectedValue;
            _orderDirection = ddlSortDirection.SelectedValue;
            orderBy = string.Format("{0} {1}", _orderColumn, _orderDirection);
            this.GoToCurrentPage();
        }

        protected void Pager_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GoToCurrentPage();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
                {
                    ctx.PostCommentRepo.Setter.deleteMany(this.getSelectedComments(ctx));
                }
            }
            catch (Exception)
            {
                ltrError.Text = string.Format(ErrorBar, "Không thể xóa tin được chọn!");
            }

            this.GoToCurrentPage();
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.GoToCurrentPage();
        }

        private void GoToCurrentPage()
        {
            int pageIndex = int.Parse(ddlPageIndex.SelectedValue);
            int pageSize = int.Parse(ddlPageSize.SelectedValue);
            GoToPage(pageIndex, pageSize);
        }

        private void GoToPage(int pageIndex, int pageSize)
        {
            this.GenerateDataPager(pageSize);
            try
            {
                ddlPageSize.Text = pageSize.ToString();
                ddlPageIndex.Text = pageIndex.ToString();
            }
            catch (Exception)
            {
                ddlPageIndex.SelectedIndex = ddlPageIndex.Items.Count - 1;
                pageIndex = int.Parse(ddlPageIndex.SelectedValue);
            }
            this.LoadCommentList(pageIndex, pageSize);
        }

        private void LoadCommentList(int pageIndex, int pageSize)
        {
            using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
            {
                var comments = ctx.PostCommentRepo.Getter.getQueryable()
                    .OrderByDescending(c => c.UpdatedOn).ThenBy(c => c.PostID).AsQueryable();

                comments = ctx.PostCommentRepo.Getter.getSortedList(comments, orderBy);

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

        private void GenerateDataPager(int pageSize)
        {
            using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
            {
                int numOfPages = (int)Math.Ceiling((decimal)ctx.PostCommentRepo.Getter.getQueryable().Count() / pageSize);
                ddlPageIndex.Items.Clear();
                for (int i = 1; i <= numOfPages; i++)
                {
                    ddlPageIndex.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }
            }
        }

        private IQueryable<Impl.Entity.PostComment> getSelectedComments(NewsVnContext ctx)
        {
            var selectedCommentIDs = new List<int>();

            foreach (RepeaterItem item in rptCommentList.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    CheckBox chkID = item.FindControl("chkID") as CheckBox;

                    if (chkID.Checked)
                    {
                        HiddenField hidID = item.FindControl("hidID") as HiddenField;
                        selectedCommentIDs.Add(int.Parse(hidID.Value));
                    }
                }                
            }

            return ctx.PostCommentRepo.Getter.getQueryable(c => selectedCommentIDs.Contains(c.ID));
        }        
    }
}