using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewsVn.Impl.Context;
using NewsVn.Web.Utils;

namespace NewsVn.Web.Account.SiteAdmin.AdPost
{
    public partial class ViewAdPost : BaseUI.SecuredPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = SiteTitle + "Quản lý rao nhanh";
            
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
                    ctx.AdPostRepo.Setter.deleteMany(this.GetSelectedAdPosts(ctx));
                }
            }
            catch (Exception)
            {
                ltrError.Text = string.Format(ErrorBar, "Không thể xóa rao nhanh được chọn!");
            }

            this.GoToCurrentPage();
        }

        protected void btnToggleActive_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
                {
                    foreach (var adpost in this.GetSelectedAdPosts(ctx))
                    {
                        adpost.Actived = !adpost.Actived;
                    }
                    ctx.SubmitChanges();
                }
            }
            catch (Exception)
            {
                ltrError.Text = string.Format(ErrorBar, "Không thể ẩn/hiện rao nhanh được chọn!");
            }

            this.GoToCurrentPage();
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
                {
                    foreach (var adpost in this.GetSelectedAdPosts(ctx).Where(p => !p.Approved))
                    {
                        adpost.Approved = true;
                        adpost.ApprovedOn = DateTime.Now;
                        adpost.ApprovedBy = HttpContext.Current.User.Identity.Name;
                        adpost.ExpiredOn = adpost.ApprovedOn.Value.AddDays(7);
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
            this.GoToCurrentPage();
        }

        private void GoToCurrentPage()
        {
            int pageIndex = int.Parse(ddlPageIndex.SelectedValue);
            int pageSize = int.Parse(ddlPageSize.SelectedValue);
            this.GoToPage(pageIndex, pageSize);
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
            this.LoadAdPostList(pageIndex, pageSize);
        }

        private void LoadAdPostList(int pageIndex, int pageSize)
        {
            using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
            {
                var adposts = ctx.AdPostRepo.Getter.getQueryable().OrderByDescending(p => p.ApprovedOn == null).ThenByDescending(p => p.CreatedOn).AsEnumerable();
                rptAdPostList.DataSource = ctx.AdPostRepo.Getter.getPagedList(adposts, pageIndex, pageSize).Select(p => new
                {
                    p.ID,
                    p.Title,
                    AdTitle = this.GetAdPostTitle(p.Title, p.Approved, p.ExpiredOn, p.Actived),
                    p.SeoUrl,
                    p.CreatedOn,
                    p.CreatedBy,
                    p.UpdatedOn,
                    p.UpdatedBy,
                    p.Approved,
                    p.ApprovedOn,
                    p.ApprovedBy,
                    p.ExpiredOn,
                    p.Actived,
                    CategoryID = p.Category.ID,
                    CategoryName = p.Category.Parent == null ? p.Category.Name : p.Category.Parent.Name + "/" + p.Category.Name
                });
                rptAdPostList.DataBind();
            }
        }

        private void GenerateDataPager(int pageSize)
        {
            using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
            {
                int numOfPages = (int)Math.Ceiling((decimal)ctx.AdPostRepo.Getter.getQueryable().Count() / pageSize);
                ddlPageIndex.Items.Clear();
                for (int i = 1; i <= numOfPages; i++)
                {
                    ddlPageIndex.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }
            }
        }

        private IQueryable<Impl.Entity.AdPost> GetSelectedAdPosts(NewsVnContext ctx)
        {
            var selectedAdPostIDs = new List<int>();

            foreach (RepeaterItem item in rptAdPostList.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    CheckBox chkID = item.FindControl("chkID") as CheckBox;

                    if (chkID.Checked)
                    {
                        HiddenField hidID = item.FindControl("hidID") as HiddenField;
                        selectedAdPostIDs.Add(int.Parse(hidID.Value));
                    }
                }
            }

            return ctx.AdPostRepo.Getter.getQueryable(p => selectedAdPostIDs.Contains(p.ID));
        }

        private string GetAdPostTitle(string title, bool approved, DateTime? expiredOn, bool active)
        {
            title = Utils.clsCommon.getEllipsisText(title, 30);
            if (!approved)
            {
                title = string.Format("<b>{0}</b>", title);
            }
            if (expiredOn.HasValue && expiredOn.Value < DateTime.Now)
            {
                title = string.Format("<span style=\"text-decoration:line-through !important\">{0}</span>", title);
            }
            if (!active)
            {
                title = string.Format("<span style=\"color:#666 !important\">{0}</span>", title);
            }
            return title;
        }
    }
}