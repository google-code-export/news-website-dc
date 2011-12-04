using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using NewsVn.Impl.Context;
using NewsVn.Web.Utils;

namespace NewsVn.Web.Account.SiteAdmin.Post
{
    public partial class ViewPostComment : BaseUI.SecuredPage
    {
        const string OrderBySK = "siteadmin.post.comment.sort.orderBy";
        const string OrderColumnSK = "siteadmin.post.comment.sort.orderColumn";
        const string OrderDirectionSK = "siteadmin.post.comment.sort.orderDirection";

        public string OrderBy
        {
            get
            {
                if (Session[OrderBySK] != null)
                {
                    _orderBy = Session[OrderBySK] as string;
                }
                return _orderBy;
            }
            set
            {
                _orderBy = value;
                if (string.IsNullOrEmpty(_orderBy))
                {
                    Session.Remove(OrderBySK);
                }
                else
                {
                    Session[OrderBySK] = _orderBy;
                }
            }
        }
        private string _orderBy = string.Empty;

        protected string OrderColumn
        {
            get
            {
                if (Session[OrderColumnSK] != null)
                {
                    _orderColumn = Session[OrderColumnSK] as string;
                }
                return _orderColumn;
            }
            set
            {
                _orderColumn = value;
                if (string.IsNullOrEmpty(_orderColumn))
                {
                    Session.Remove(OrderColumnSK);
                }
                else
                {
                    Session[OrderColumnSK] = _orderColumn;
                }
            }
        }
        private string _orderColumn = string.Empty;

        protected string OrderDirection
        {
            get
            {
                if (Session[OrderDirectionSK] != null)
                {
                    _orderDirection = Session[OrderDirectionSK] as string;
                }
                return _orderDirection.ToLower();
            }
            set
            {
                _orderDirection = value;
                if (string.IsNullOrEmpty(_orderDirection))
                {
                    Session.Remove(OrderDirectionSK);
                }
                else
                {
                    Session[OrderDirectionSK] = _orderDirection;
                }
            }
        }
        private string _orderDirection = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            SiteTitle += "Quản lý bình luận";

            if (!IsPostBack)
            {
                this.GoToFirstPage();
            }
        }

        protected void Sorter_SelectedIndexChanged(object sender, EventArgs e)
        {
            OrderColumn = ddlSortColumn.SelectedValue;
            OrderDirection = ddlSortDirection.SelectedValue;
            OrderBy = string.Format("{0} {1}", OrderColumn, OrderDirection);
            this.GoToCurrentPage();
        }

        protected void Pager_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GoToCurrentPage();
        }

        protected void btnClearSort_Click(object sender, EventArgs e)
        {
            OrderBy = string.Empty;
            OrderColumn = string.Empty;
            OrderDirection = string.Empty;

            ddlSortColumn.SelectedIndex = 0;
            ddlSortDirection.SelectedIndex = 0;

            this.GoToFirstPage();
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

        private void GoToFirstPage()
        {
            int pageSize = int.Parse(ddlPageSize.SelectedValue);
            GoToPage(1, pageSize);
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
            this.CheckSorting();
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

                comments = ctx.PostCommentRepo.Getter.getSortedList(comments, OrderBy);

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

        private void CheckSorting()
        {
            btnClearSort.Visible = !string.IsNullOrEmpty(OrderBy);

            var sb = new StringBuilder();

            if (!string.IsNullOrEmpty(OrderBy))
            {
                sb.AppendFormat("Đang sắp xếp theo: <b>{0}</b>", ddlSortColumn.SelectedItem.Text);
                sb.AppendFormat(", chiều: <b>{0}</b>", ddlSortDirection.SelectedItem.Text);
            }

            string infoText = sb.ToString();

            if (!string.IsNullOrEmpty(infoText))
            {
                ltrInfo.Text = string.Format(InfoBar, infoText);
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