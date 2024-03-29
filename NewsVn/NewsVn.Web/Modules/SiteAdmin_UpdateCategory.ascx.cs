﻿using System;
using System.Linq;
using System.Web.UI.WebControls;
using NewsVn.Impl.Context;
using NewsVn.Web.Utils;

namespace NewsVn.Web.Modules
{
    public partial class SiteAdmin_UpdateCategory : BaseUI.SecuredModule
    {
        public bool AllowEdit { get; set; }

        public string CategoryType
        {
            get
            {
                if (string.IsNullOrEmpty(_categoryType))
                {
                    _categoryType = "post";
                }
                return _categoryType;
            }
            set
            {
                _categoryType = value;
            }
        }
        private string _categoryType;

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
            using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
            {
                var parentCates = ctx.CategoryRepo.Getter.getQueryable(c => c.Parent == null && c.Type.Trim().ToLower() == CategoryType).OrderBy(p => p.Name);
                foreach (var cate in parentCates)
                    ddlParentCategory.Items.Add(new ListItem(cate.Name, cate.ID.ToString()));
            }
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
                using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
                {
                    int categoryID = -1;
                    int.TryParse(Request.QueryString["cid"], out categoryID);

                    var category = ctx.CategoryRepo.Getter.getOne(c => c.ID == categoryID && c.Parent != null);

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
        }

        private void AddNewCategory()
        {
            try
            {
                using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
                {
                    var parentCategory = ctx.CategoryRepo.Getter.getOne(c => c.ID == int.Parse(ddlParentCategory.SelectedValue));

                    var category = new Impl.Entity.Category
                    {
                        Type = CategoryType,
                        Name = txtName.Text.Trim(),
                        Description = txtDescription.Text.Trim(),
                        Actived = chkActived.Checked,
                        SeoName = string.Format("{0}/{1}", parentCategory.SeoName, clsCommon.RemoveUnicodeMarks(txtName.Text.Trim())),
                        SeoUrl = string.Format("ct/{0}/{1}.aspx", parentCategory.SeoName, clsCommon.RemoveUnicodeMarks(txtName.Text.Trim())),
                        UpdatedOn = DateTime.Now,
                        Parent = parentCategory
                    };

                    ctx.CategoryRepo.Setter.addOne(category);
                    this.ClearUpdateForm();
                }
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
                using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
                {
                    var category = ctx.CategoryRepo.Getter.getOne(c => c.ID == categoryID && c.Parent != null);

                    if (category != null)
                    {
                        var parentCategory = ctx.CategoryRepo.Getter.getOne(c => c.ID == int.Parse(ddlParentCategory.SelectedValue));

                        category.Type = CategoryType;
                        category.Name = txtName.Text.Trim();
                        category.Description = txtDescription.Text.Trim();
                        category.Actived = category.Actived;
                        category.SeoName = string.Format("{0}/{1}", parentCategory.SeoName, clsCommon.RemoveUnicodeMarks(txtName.Text.Trim()));
                        category.SeoUrl = string.Format("ct/{0}.aspx", category.SeoName);
                        category.UpdatedOn = DateTime.Now;
                        category.Parent = parentCategory;

                        ctx.SubmitChanges();
                        this.ClearUpdateForm();
                    }
                }
            }
            catch (Exception ex)
            {
                ltrError.Text = string.Format(ErrorBar, ex.Message);
            }
        }
    }
}