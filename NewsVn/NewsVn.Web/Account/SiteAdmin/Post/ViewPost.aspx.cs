using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using NewsVn.Impl.Context;
using NewsVn.Impl.Model;
using NewsVn.Web.Utils;

namespace NewsVn.Web.Account.SiteAdmin.Post
{
    public partial class ViewPost : BaseUI.SecuredPage
    {
        const string OrderBySK = "siteadmin.post.sort.orderBy";
        const string OrderColumnSK = "siteadmin.post.sort.orderColumn";
        const string OrderDirectionSK = "siteadmin.post.sort.orderDirection";
        const string FilterExpressionSK = "siteadmin.post.filter.expression";
        const string FilterModelSK = "siteadmin.post.filter.model";
               
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
                
        public Expression<Func<Impl.Entity.Post, bool>> FilterExpression
        {
            get
            {
                if (Session[FilterExpressionSK] != null)
                {
                    _filterExpression = Session[FilterExpressionSK] as Expression<Func<Impl.Entity.Post, bool>>;
                }
                return _filterExpression;
            }
            set
            {
                _filterExpression = value;
                if (_filterExpression == null)
                {
                    Session.Remove(FilterExpressionSK);
                }
                else
                {
                    Session[FilterExpressionSK] = _filterExpression;
                }
                
            }
        }
        private Expression<Func<Impl.Entity.Post, bool>> _filterExpression = null;        

        public FilterModel FilterModel
        {
            get
            {
                if (Session[FilterModelSK] != null)
                {
                    _filterModel = Session[FilterModelSK] as FilterModel;
                }
                return _filterModel;
            }
            set
            {
                _filterModel = value;
                if (_filterModel == null)
                {
                    Session.Remove(FilterModelSK);
                }
                else
                {
                    Session[FilterModelSK] = _filterModel;
                }                
            }
        }
        private FilterModel _filterModel = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            SiteTitle += "Quản lý tin tức";

            if (!IsPostBack)
            {
                this.GoToPage(1, int.Parse(ddlPageSize.SelectedValue));
            }
        }

        protected void Sorter_SelectedIndexChanged(object sender, EventArgs e)
        {
            OrderColumn = ddlSortColumn.SelectedValue;
            OrderDirection = ddlSortDirection.SelectedValue;
            OrderBy = string.Format("{0} {1}", OrderColumn, OrderDirection);
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
            OrderBy = string.Empty;
            OrderColumn = string.Empty;
            OrderDirection = string.Empty;

            ddlSortColumn.SelectedIndex = 0;
            ddlSortDirection.SelectedIndex = 0;

            this.GoToFirstPage();
        }

        protected void fpViewPost_Filtered(object sender, Expression<Func<Impl.Entity.Post, bool>> expression, FilterModel model)
        {
            FilterExpression = expression;
            FilterModel = model;
            this.GoToFirstPage();
        }

        protected void btnClearFilter_Click(object sender, EventArgs e)
        {
            FilterExpression = null;
            FilterModel = null;
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
                Expression<Func<Impl.Entity.Post, bool>> expression = p => true;

                if (FilterExpression != null)
                {
                    expression = FilterExpression;
                }

                var posts = ctx.PostRepo.Getter.getQueryable(expression)
                    .OrderByDescending(p => p.CreatedOn).AsQueryable();

                posts = ctx.PostRepo.Getter.getSortedList(posts, OrderBy);

                rptPostList.DataSource = ctx.PostRepo.Getter.getPagedList(posts, pageIndex, pageSize).Select(p => new
                    {
                        p.ID,
                        p.Title,
                        TitleCssClass = GetTitleCssClass(p.Actived, p.Approved),
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
                Expression<Func<Impl.Entity.Post, bool>> expression = p => true;

                if (FilterExpression != null)
                {
                    expression = FilterExpression;
                }
                int numOfRecords = ctx.PostRepo.Getter.getQueryable(expression).Count();
                int numOfPages = (int)Math.Ceiling((decimal)numOfRecords / pageSize);
                
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

                ltrPostCount.Text = string.Format("Có {0:N0} tin", numOfRecords);
            }
        }

        private void CheckSortingAndFiltering()
        {
            btnClearSort.Visible = !string.IsNullOrEmpty(OrderBy);
            btnClearFilter.Visible = FilterExpression != null;

            var sb = new StringBuilder();

            if (!string.IsNullOrEmpty(OrderBy))
            {
                sb.AppendFormat("Đang sắp xếp theo: <b>{0}</b>", ddlSortColumn.SelectedItem.Text);
                sb.AppendFormat(", chiều: <b>{0}</b>", ddlSortDirection.SelectedItem.Text);
            }

            if (FilterExpression != null)
            {                                
                sb.Append(string.IsNullOrEmpty(OrderBy) ? "" : " | ");
                sb.Append("Đang lọc theo: ");

                var token = FilterModel.Token as Impl.Entity.Post;

                if (!string.IsNullOrEmpty(token.Title))
                {
                    sb.AppendFormat("Tiêu đề: <b>{0}</b>, ", token.Title);
                }
                if (!string.IsNullOrEmpty(token.Category.Name))
                {
                    sb.AppendFormat("Danh mục: <b>{0}</b>, ", token.Category.Name);
                }
                if (!string.IsNullOrEmpty(token.UpdatedBy))
                {
                    sb.AppendFormat("Người sửa: <b>{0}</b>, ", token.UpdatedBy);
                }
                if (token.UpdatedOn != null)
                {
                    sb.AppendFormat("Ngày sửa: <b>{0:dd/MM/yyyy}</b>, ", token.UpdatedOn);
                }
                if (!string.IsNullOrEmpty(token.ApprovedBy))
                {
                    sb.AppendFormat("Người duyệt: <b>{0}</b>, ", token.ApprovedBy);
                }
                if (token.ApprovedOn != null)
                {
                    sb.AppendFormat("Ngày duyệt: <b>{0:dd/MM/yyyy}</b>, ", token.ApprovedOn);
                }

                if (FilterModel.Data.Keys.Contains("ManagePost_FilterMethod"))
                {
                    sb.AppendFormat("Phương pháp: <b>{0}</b>, ",
                        FilterModel.Data["ManagePost_FilterMethod"].ToString());
                }

                if (FilterModel.Data.Keys.Contains("ManagePost_FilterChain"))
                {
                    sb.AppendFormat("Kết điều kiện: <b>{0}</b>",
                        FilterModel.Data["ManagePost_FilterChain"].ToString());
                }
            }

            string infoText = sb.ToString();

            if (!string.IsNullOrEmpty(infoText))
            {
                ltrInfo.Text = string.Format(InfoBar, infoText);
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

        private string GetTitleCssClass(bool actived, bool approved)
        {
            string cssClass = string.Empty;

            if (!actived)
            {
                cssClass += "post-not-actived ";
            }

            if (!approved)
            {
                cssClass += "post-not-approved ";
            }

            return cssClass;
        }
    }
}