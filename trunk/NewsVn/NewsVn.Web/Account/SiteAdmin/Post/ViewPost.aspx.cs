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
    public partial class ViewPost : BaseUI.SecuredPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = SiteTitle + "Quản lý tin tức";

            if (!IsPostBack)
            {
                this.GoToPage(1, int.Parse(ddlPageSize.SelectedValue));
            }
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
                    ctx.PostRepo.Setter.deleteMany(this.GetSelectedPosts(ctx));
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
                    foreach (var post in this.GetSelectedPosts(ctx))
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
                    foreach (var post in this.GetSelectedPosts(ctx).Where(p => !p.Approved))
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

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.GoToCurrentPage();
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            string filterColumn = ddlFilterColumn.SelectedValue;
            string filterText = txtFilterText.Text;

            try
            {
                using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
                {
                    rptPostList.DataSource = ctx.PostRepo.Getter.getQueryable(p => p.GetType().GetProperty(filterColumn).GetValue(p, null).ToString().Contains(filterText));
                    rptPostList.DataBind();
                }
            }
            catch (Exception ex)
            {
                this.GoToCurrentPage();
                ltrError.Text = string.Format(ErrorBar, ex.Message);
            }
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
            this.LoadPostList(pageIndex, pageSize);
        }

        private void LoadPostList(int pageIndex, int pageSize)
        {
            using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
            {
                var posts = ctx.PostRepo.Getter.getQueryable().OrderByDescending(p => p.ApprovedOn == null).ThenByDescending(p => p.CreatedOn).AsEnumerable();
                rptPostList.DataSource = ctx.PostRepo.Getter.getPagedList(posts, pageIndex, pageSize).Select(p => new
                    {
                        p.ID,
                        p.Title,
                        PostTitle = this.GetPostTitle(p.Title, p.Approved, p.Actived),
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
                int numOfPages = (int)Math.Ceiling((decimal)ctx.PostRepo.Getter.getQueryable().Count() / pageSize);
                ddlPageIndex.Items.Clear();
                for (int i = 1; i <= numOfPages; i++)
                {
                    ddlPageIndex.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }
            }
        }

        private IQueryable<Impl.Entity.Post> GetSelectedPosts(NewsVnContext ctx)
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

        private string GetPostTitle(string title, bool approved, bool active)
        {
            title = Utils.clsCommon.getEllipsisText(title, 30);
            if (!approved)
            {
                title = string.Format("<b>{0}</b>", title);
            }
            if (!active)
            {
                title = string.Format("<span style=\"color:#666 !important\">{0}</span>", title);
            }
            return title;
        }
    }
}