using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
                foreach (var post in this.getSelectedCategories())
                {
                    ApplicationManager.Entities.DeleteObject(post);
                }

                this.SaveChangesAndReload();
            }
            catch (Exception)
            {
                ltrError.Text = string.Format(ErrorBar, "Không thể xóa tin được chọn!");
            }

            this.LoadCategoryList();
        }

        protected void btnToggleActive_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var cate in this.getSelectedCategories())
                {
                    cate.Actived = !cate.Actived;
                }

                this.SaveChangesAndReload();
            }
            catch (Exception)
            {
                ltrError.Text = string.Format(ErrorBar, "Không thể ẩn tin được chọn!");
            }

            this.LoadCategoryList();
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.LoadCategoryList();
        }

        private void LoadCategoryList()
        {
            rptCategoryList.DataSource = _Categories.Where(c => c.Parent != null).Select(c => new
            {
                c.ID, c.Name, c.CreatedOn, c.UpdatedOn, c.Actived,
                ParentName = c.Parent.Name
            }).OrderByDescending(c => c.CreatedOn).ThenByDescending(c => c.UpdatedOn);
            rptCategoryList.DataBind();
        }

        private IQueryable<Data.Category> getSelectedCategories()
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

            return _Categories.Where(c => selectedCategoryIDs.Contains(c.ID));
        }

        private void SaveChangesAndReload()
        {
            ApplicationManager.Entities.SaveChanges();
            _Categories = ApplicationManager.Entities.Categories.ToList().AsQueryable();
            ApplicationManager.UpdateCacheData<Data.Category>(ApplicationManager.Entities.Categories.Where(c => c.Actived));
        }
    }
}