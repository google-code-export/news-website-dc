using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewsVn.Web.Utils;

namespace NewsVn.Web.Modules
{
    public partial class SiteAdmin_UpdateCategory : BaseUI.SecuredModule
    {
        public bool AllowEdit { get; set; }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.LoadParentCategoryDropDown();
                this.LoadCategoryByID();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int categoryID = -1;
            int.TryParse(Request.QueryString["cid"], out categoryID);

            if (categoryID != -1 && AllowEdit)
                this.ModifyCategory(categoryID);
            else
                this.AddNewCategory();
        }

        private void LoadParentCategoryDropDown()
        {
            var parentCates = _Categories.Where(c => c.Parent == null).OrderBy(p => p.Name);
            
            foreach (var cate in parentCates)
                ddlParentCategory.Items.Add(new ListItem(cate.Name, cate.ID.ToString()));
        }

        private void ClearUpdateForm()
        {
            txtName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            chkActived.Checked = true;
            ddlParentCategory.SelectedIndex = 0;
        }

        private void LoadCategoryByID()
        {
            if (AllowEdit)
            {
                int categoryID = -1;
                int.TryParse(Request.QueryString["cid"], out categoryID);

                Data.Category category = _Categories.FirstOrDefault(c => c.ID == categoryID && c.Parent != null);

                if (category != null)
                {
                    txtName.Text = category.Name;
                    txtDescription.Text = category.Description;
                    chkActived.Checked = category.Actived;
                    txtParentCategory.Text = category.Parent.ID.ToString();
                    ddlParentCategory.Items.FindByValue(category.Parent.ID.ToString()).Selected = true;
                }
                else
                {
                    ltrError.Text = string.Format(ErrorBar, "Danh mục không tồn tại hoặc không cho phép chỉnh sửa.");
                    btnUpdate.Visible = false;
                }
            }
        }

        private void AddNewCategory()
        {
            Data.Category parentCategory = _Categories.FirstOrDefault(c => c.ID == int.Parse(ddlParentCategory.SelectedValue));
            
            try
            {
                Data.Category category = new Data.Category
                {
                    Name = txtName.Text.Trim(),
                    Description = txtDescription.Text.Trim(),
                    Actived = chkActived.Checked,
                    SeoName = string.Format("{0}/{1}", parentCategory.SeoName, clsCommon.RemoveUnicodeMarks(txtName.Text.Trim())),
                    SeoUrl = string.Format("ct/{0}/{1}.aspx", parentCategory.SeoName, clsCommon.RemoveUnicodeMarks(txtName.Text.Trim())),
                    CreatedOn = DateTime.Now,
                    Parent = parentCategory
                };

                this.SaveChangesAndReload();
                this.ClearUpdateForm();
            }
            catch (Exception ex)
            {
                ltrError.Text = string.Format(ErrorBar, ex.Message);
            }
        }

        private void ModifyCategory(int categoryID)
        {
            try
            {
                Data.Category category = _Categories.FirstOrDefault(c => c.ID == categoryID && c.Parent != null);

                if (category != null)
                {
                    Data.Category parentCategory = _Categories.FirstOrDefault(c => c.ID == int.Parse(ddlParentCategory.SelectedValue));
                    
                    category.Name = txtName.Text.Trim();
                    category.Description = txtDescription.Text.Trim();
                    category.Actived = category.Actived;
                    category.SeoName = string.Format("{0}/{1}", parentCategory.SeoName, clsCommon.RemoveUnicodeMarks(txtName.Text.Trim()));
                    category.SeoUrl = string.Format("ct/{0}.aspx", category.SeoName);
                    category.UpdatedOn = DateTime.Now;
                    category.Parent = parentCategory;

                    this.SaveChangesAndReload();
                    this.ClearUpdateForm();
                }
            }
            catch (Exception ex)
            {
                ltrError.Text = string.Format(ErrorBar, ex.Message);
            }
        }

        private void SaveChangesAndReload()
        {
            ApplicationManager.Entities.SaveChanges();
            _Categories = ApplicationManager.Entities.Categories;
            ApplicationManager.UpdateCacheData<Data.Category>(ApplicationManager.Entities.Categories.Where(c => c.Actived));
        }
    }
}