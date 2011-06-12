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
                    ctx.CategoryRespo.Setter.deleteMany(this.getSelectedCategories());
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
                    foreach (var cate in this.getSelectedCategories())
                    {
                        cate.Actived = !cate.Actived;
                        ctx.CategoryRespo.Setter.editOne(cate, true);
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
                rptCategoryList.DataSource = ctx.CategoryRespo.Getter.getQueryable(c => c.Parent != null).Select(c => new
                {
                    c.ID,
                    c.Name,
                    c.UpdatedOn,
                    c.Actived,
                    ParentName = c.Parent.Name
                }).OrderByDescending(c => c.UpdatedOn).ThenByDescending(c => c.UpdatedOn);
                rptCategoryList.DataBind();
            }
        }

        private IQueryable<Impl.Entity.Category> getSelectedCategories()
        {
            using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
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

                return ctx.CategoryRespo.Getter.getQueryable(c => selectedCategoryIDs.Contains(c.ID));
            }            
        }
    }
}