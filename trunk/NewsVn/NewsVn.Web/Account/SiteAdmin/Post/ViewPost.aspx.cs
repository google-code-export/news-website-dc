using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewsVn.Impl.Context;
using NewsVn.Web.Utils;
using System.Text;
using System.Linq.Expressions;

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

        static Impl.Model.FilterModel postFilter;

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

        protected void fpViewPost_Filtered(object sender, ref Impl.Model.FilterModel filterModel)
        {
            postFilter = filterModel;
            this.GoToFirstPage();
        }

        protected void btnClearFilter_Click(object sender, EventArgs e)
        {
            postFilter = null;
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
                var posts = FilterPost(ctx);

                posts = posts.OrderByDescending(p => p.ApprovedOn).ThenByDescending(p => p.ApprovedOn).AsEnumerable();

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
            lnkFilter.Visible = postFilter == null;
            btnClearFilter.Visible = !lnkFilter.Visible;

            var sb = new StringBuilder();

            if (!string.IsNullOrEmpty(orderBy))
            {
                sb.AppendFormat("Đang sắp xếp theo: <b>{0}</b>", ddlSortColumn.SelectedItem.Text);
                sb.AppendFormat(", chiều: <b>{0}</b>", ddlSortDirection.SelectedItem.Text);
            }

            if (postFilter != null)
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

        private bool CheckStringCompare(string strHost, string strCompare)
        {
            if (string.IsNullOrEmpty(strHost) || string.IsNullOrEmpty(strCompare))
            {
                return true;
            }

            strHost = strHost.Trim();
            strCompare = strCompare.Trim();

            return strHost.Equals(strCompare, StringComparison.OrdinalIgnoreCase);
        }

        private IEnumerable<Impl.Entity.Post> FilterPost(NewsVnContext ctx)
        {
            if (postFilter == null)
            {
                return ctx.PostRepo.Getter.getEnumerable();
            }

            var token = postFilter.Token as Impl.Entity.Post;
            var method = postFilter.Method;
            var chain = postFilter.Chain;

            if (method == Impl.Model.FilterMethod.Absolute && chain == Impl.Model.FilterChain.LinkAll)
            {
                return ctx.PostRepo.Getter.getEnumerable(p => CheckStringCompare(p.Title, token.Title)
                    && CheckStringCompare(p.Category.Name, token.Category.Name));
            }
            if (method == Impl.Model.FilterMethod.Absolute && chain == Impl.Model.FilterChain.LinkOne)
            {
                return ctx.PostRepo.Getter.getEnumerable(p => CheckStringCompare(p.Title, token.Title)
                    || CheckStringCompare(p.Category.Name, token.Category.Name));
            }
            if (method == Impl.Model.FilterMethod.Relative && chain == Impl.Model.FilterChain.LinkAll)
            {
                return ctx.PostRepo.Getter.getEnumerable(p => CheckStringContain(p.Title, token.Title)
                    && CheckStringContain(p.Category.Name, token.Category.Name));
            }
            if (method == Impl.Model.FilterMethod.Relative && chain == Impl.Model.FilterChain.LinkOne)
            {
                return ctx.PostRepo.Getter.getEnumerable(p => CheckStringContain(p.Title, token.Title)
                    || CheckStringContain(p.Category.Name, token.Category.Name));
            }

            return ctx.PostRepo.Getter.getEnumerable();
        }

        private bool CheckStringContain(string strHost, string strContain)
        {
            if (string.IsNullOrEmpty(strHost) || string.IsNullOrEmpty(strContain))
            {
                return true;
            }

            strHost = strHost.ToLower().Trim();
            strContain = strContain.ToLower().Trim();

            return strHost.Contains(strContain);
        }
    }
}