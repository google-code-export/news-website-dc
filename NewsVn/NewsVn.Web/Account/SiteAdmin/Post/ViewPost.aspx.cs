using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using NewsVn.Impl.Context;
using NewsVn.Web.Utils;

namespace NewsVn.Web.Account.SiteAdmin.Post
{
    public partial class ViewPost : BaseUI.SecuredPage
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

        static Func<Impl.Entity.Post, bool> postPredicate = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = SiteTitle + "Quản lý tin tức";

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
            this.GoToFirstPage();
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
                    ctx.PostRepo.Setter.deleteMany(this.getSelectedPosts(ctx));
                }
            }
            catch (Exception)
            {
                ltrError.Text = string.Format(ErrorBar, "Không thể xóa tin được chọn!");
            }

            this.GoToCurrentPage();
        }

        protected void btnToggleActive_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
                {
                    foreach (var post in this.getSelectedPosts(ctx))
                    {
                        post.Actived = !post.Actived;
                    }
                    ctx.SubmitChanges();
                }
            }
            catch (Exception)
            {
                ltrError.Text = string.Format(ErrorBar, "Không thể ẩn/hiện tin được chọn!");
            }

            this.GoToCurrentPage();
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
                {
                    foreach (var post in this.getSelectedPosts(ctx).Where(p => !p.Approved))
                    {
                        post.Approved = true;
                        post.ApprovedOn = DateTime.Now;
                        post.ApprovedBy = HttpContext.Current.User.Identity.Name;
                    }
                    ctx.SubmitChanges();
                }
            }
            catch (Exception)
            {
                ltrError.Text = string.Format(ErrorBar, "Không thể duyệt tin được chọn!");
            }

            this.GoToCurrentPage();
        }

        protected void btnClearSort_Click(object sender, EventArgs e)
        {
            orderBy = string.Empty;
            _orderColumn = string.Empty;
            _orderDirection = string.Empty;

            ddlSortColumn.SelectedIndex = 0;
            ddlSortDirection.SelectedIndex = 0;

            this.GoToFirstPage();
        }

        protected void fpViewPost_Filtering(object sender, Impl.Entity.Post token)
        {
            var filter = sender as Modules.SiteAdmin_FilterPost;
            token.Title = (filter.FindControl("txtTitle") as TextBox).Text.Trim();
        }

        protected void fpViewPost_Filtered(object sender, Func<Impl.Entity.Post,bool> predicate)
        {
            postPredicate = predicate;
            this.GoToFirstPage();
        }

        protected void btnClearFilter_Click(object sender, EventArgs e)
        {
            postPredicate = null;
            this.GoToFirstPage();
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
            this.CheckSortingAndFiltering();
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
            this.LoadPostList(pageIndex, pageSize);
        }

        private void LoadPostList(int pageIndex, int pageSize)
        {
            using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
            {
                Func<Impl.Entity.Post, bool> predicate = p => true;

                if (postPredicate != null)
                {
                    predicate = postPredicate;
                }

                var posts = ctx.PostRepo.Getter.getEnumerable(predicate)
                    .OrderByDescending(p => p.ApprovedOn).ThenByDescending(p => p.ApprovedOn).AsEnumerable();

                posts = ctx.PostRepo.Getter.getSortedList(posts, orderBy);

                rptPostList.DataSource = ctx.PostRepo.Getter.getPagedList(posts, pageIndex, pageSize).Select(p => new
                    {
                        p.ID,
                        p.Title,
                        p.SeoUrl,
                        p.CreatedOn,
                        p.CreatedBy,
                        p.UpdatedOn,
                        p.UpdatedBy,
                        p.Approved,
                        p.ApprovedOn,
                        p.ApprovedBy,
                        p.Actived,
                        CategoryID = p.Category.ID,
                        p.PageView,
                        CategoryName = p.Category.Parent == null ? p.Category.Name : p.Category.Parent.Name + "/" + p.Category.Name
                    });
                rptPostList.DataBind();
            }
        }

        private void GenerateDataPager(int pageSize)
        {
            using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
            {
                int numOfPages = (int)Math.Ceiling((decimal)ctx.PostRepo.Getter.getEnumerable().Count() / pageSize);
                
                ddlPageIndex.Items.Clear();

                if (numOfPages > 0)
                {
                    for (int i = 1; i <= numOfPages; i++)
                    {
                        ddlPageIndex.Items.Add(new ListItem(i.ToString(), i.ToString()));
                    }
                }
                else
                {
                    ddlPageIndex.Items.Add("1");
                }
            }
        }

        private void CheckSortingAndFiltering()
        {
            btnClearSort.Visible = !string.IsNullOrEmpty(orderBy);
            lnkFilter.Visible = postPredicate == null;
            btnClearFilter.Visible = !lnkFilter.Visible;

            var sb = new StringBuilder();

            if (!string.IsNullOrEmpty(orderBy))
            {
                sb.AppendFormat("Đang sắp xếp theo: <b>{0}</b>", ddlSortColumn.SelectedItem.Text);
                sb.AppendFormat(", chiều: <b>{0}</b>", ddlSortDirection.SelectedItem.Text);
            }

            if (postPredicate != null)
            {
                sb.Append(string.IsNullOrEmpty(orderBy) ? "" : " | ");
                sb.Append("Bật chế độ lọc");
            }

            if (!string.IsNullOrEmpty(sb.ToString()))
            {
                ltrInfo.Text = string.Format(InfoBar, sb.ToString());
            }
        }

        private IQueryable<Impl.Entity.Post> getSelectedPosts(NewsVnContext ctx)
        {
            var selectedPostIDs = new List<int>();

            foreach (RepeaterItem item in rptPostList.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    CheckBox chkID = item.FindControl("chkID") as CheckBox;

                    if (chkID.Checked)
                    {
                        HiddenField hidID = item.FindControl("hidID") as HiddenField;
                        selectedPostIDs.Add(int.Parse(hidID.Value));
                    }
                }
            }

            return ctx.PostRepo.Getter.getQueryable(p => selectedPostIDs.Contains(p.ID));
        }
    }
}