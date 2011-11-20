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
    public partial class ViewCategory : BaseUI.SecuredPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = SiteTitle + "Quản lý danh mục";

            if (!IsPostBack)
            {
                this.LoadCategoryList();
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
                {
                    ctx.CategoryRepo.Setter.deleteMany(this.getSelectedCategories(ctx));
                }
            }
            catch (Exception)
            {
                ltrError.Text = string.Format(ErrorBar, "Không thể xóa danh mục được chọn!");
            }

            this.LoadCategoryList();
        }

        protected void btnToggleActive_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
                {
                    foreach (var cate in this.getSelectedCategories(ctx))
                    {
                        cate.Actived = !cate.Actived;
                    }
                    ctx.SubmitChanges();
                }
            }
            catch (Exception)
            {
                ltrError.Text = string.Format(ErrorBar, "Không thể ẩn danh mục được chọn!");
            }

            this.LoadCategoryList();
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.LoadCategoryList();
        }

        private void LoadCategoryList()
        {
            using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
            {
                rptCategoryList.DataSource = ctx.CategoryRepo.Getter
                    .getQueryable(c => c.Parent != null && c.Type.Trim().ToLower() == "adpost").Select(c => new
                    {
                        c.ID,
                        c.Name,
                        NameCssClass = GetNameCssClass(c.Actived),
                        c.UpdatedOn,
                        c.Actived,
                        ParentName = c.Parent.Name
                    }).OrderByDescending(c => c.UpdatedOn).ThenByDescending(c => c.UpdatedOn);
                rptCategoryList.DataBind();
            }
        }

        private IQueryable<Impl.Entity.Category> getSelectedCategories(NewsVnContext ctx)
        {
            var selectedCategoryIDs = new List<int>();

            foreach (RepeaterItem item in rptCategoryList.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    CheckBox chkID = item.FindControl("chkID") as CheckBox;

                    if (chkID.Checked)
                    {
                        HiddenField hidID = item.FindControl("hidID") as HiddenField;
                        selectedCategoryIDs.Add(int.Parse(hidID.Value));
                    }
                }
            }

            return ctx.CategoryRepo.Getter.getQueryable(c => selectedCategoryIDs.Contains(c.ID));
        }

        private string GetNameCssClass(bool actived)
        {
            string cssClass = string.Empty;

            if (!actived)
            {
                cssClass += "post-not-actived ";
            }

            return cssClass;
        }
    }
}