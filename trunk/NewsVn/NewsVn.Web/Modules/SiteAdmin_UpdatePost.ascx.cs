using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewsVn.Web.Utils;

namespace NewsVn.Web.Modules
{
    public partial class SiteAdmin_UpdatePost : BaseUI.SecuredModule
    {
        public bool AllowEdit { get; set; }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            editorContent.DisableItemList = CE_Configuration;

            if (!IsPostBack)
            {
                this.LoadCategoryDropDown();
                this.SetPostApprovalByRole();
                this.LoadPostByID();
            }
        }
        
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int postID = -1;
            int.TryParse(Request.QueryString["pid"], out postID);

            if (postID != -1 && AllowEdit)
                this.ModifyPost(postID);
            else 
                this.AddNewPost();
        }

        private void LoadCategoryDropDown()
        {
            var parentCates = _Categories.Where(p => p.Parent == null).OrderBy(p => p.Name);
            var otherCates = _Categories.Where(p => !parentCates.Contains(p)).OrderBy(p => p.Parent.Name);

            foreach (var cate in parentCates)
                ddlCategory.Items.Add(new ListItem(cate.Name, cate.ID.ToString()));

            foreach (var cate in otherCates)
                ddlCategory.Items.Add(new ListItem(cate.Parent.Name + " / " + cate.Name, cate.ID.ToString()));
        }

        private void SetPostApprovalByRole()
        {
            chkApproved.Checked = HttpContext.Current.User.IsInRole("siteadmin");
            chkApproved.Checked = true;
            chkApproved.Visible = false;
        }

        private void ClearUpdateForm()
        {
            txtTitle.Text = string.Empty;
            txtAvatar.Text = string.Empty;
            txtDescription.Text = string.Empty;
            editorContent.Text = string.Empty;
            chkActived.Checked = true;
            chkAllowComments.Checked = true;
            chkCheckPageView.Checked = true;
            ddlCategory.SelectedIndex = 0;

            this.SetPostApprovalByRole();
        }

        private void LoadPostByID()
        {
            if (AllowEdit)
            {
                int postID = -1;
                int.TryParse(Request.QueryString["pid"], out postID);

                Data.Post post = _Posts.FirstOrDefault(p => p.ID == postID);

                if (post != null)
                {
                    txtTitle.Text = post.Title;
                    txtAvatar.Text = post.Avatar;
                    chkActived.Checked = post.Actived;
                    chkAllowComments.Checked = post.AllowComments;
                    chkCheckPageView.Checked = post.CheckPageView;
                    chkApproved.Checked = post.Approved;
                    txtDescription.Text = post.Description;
                    editorContent.Text = post.Content;
                    txtCategory.Text = post.Category.ID.ToString();
                    ddlCategory.Items.FindByValue(post.Category.ID.ToString()).Selected = true;
                }
            }
        }

        private void AddNewPost()
        {
            ApplicationManager.Entities.Connection.Open();
            var trans = ApplicationManager.Entities.Connection.BeginTransaction();

            try
            {
                Data.Category cate = _Categories.FirstOrDefault(p => p.ID == int.Parse(ddlCategory.SelectedValue));

                Data.Post post = new Data.Post
                {
                    Title = txtTitle.Text.Trim(),
                    Avatar = txtAvatar.Text.Trim(),
                    Actived = chkActived.Checked,
                    AllowComments = chkAllowComments.Checked,
                    CheckPageView = chkCheckPageView.Checked,
                    Approved = chkApproved.Checked,
                    Description = txtDescription.Text.Trim(),
                    Content = editorContent.Text.Trim(),
                    SeoUrl = "SeoUrl",
                    CreatedOn = DateTime.Now,
                    CreatedBy = HttpContext.Current.User.Identity.Name,
                    Category = cate
                };

                if (chkApproved.Checked)
                {
                    post.ApprovedOn = DateTime.Now;
                    post.ApprovedBy = HttpContext.Current.User.Identity.Name;
                }

                ApplicationManager.Entities.AddToPosts(post);
                ApplicationManager.Entities.SaveChanges();

                post.SeoUrl = string.Format("pt/{0}/{1}/{2}.aspx", cate.SeoName, post.ID, clsCommon.RemoveUnicodeMarks(post.Title));

                this.SaveChangesAndReload();

                trans.Commit();

                this.ClearUpdateForm();
            }
            catch (Exception)
            {
                trans.Rollback();
            }
            finally
            {
                ApplicationManager.Entities.Connection.Close();
            }
        }

        private void ModifyPost(int postID)
        {
            Data.Post post = _Posts.FirstOrDefault(p => p.ID == postID);

            if (post != null)
            {
                Data.Category cate = _Categories.FirstOrDefault(p => p.ID == int.Parse(ddlCategory.SelectedValue));

                post.Title = txtTitle.Text.Trim();
                post.Avatar = txtAvatar.Text.Trim();
                post.Actived = chkActived.Checked;
                post.AllowComments = chkAllowComments.Checked;
                post.CheckPageView = chkCheckPageView.Checked;
                post.Description = txtDescription.Text.Trim();
                post.Content = editorContent.Text.Trim();
                post.SeoUrl = string.Format("pt/{0}/{1}/{2}.aspx", cate.SeoName, post.ID, clsCommon.RemoveUnicodeMarks(post.Title));
                post.UpdatedOn = DateTime.Now;
                post.UpdatedBy = HttpContext.Current.User.Identity.Name;
                post.Category = _Categories.FirstOrDefault(p => p.ID == int.Parse(ddlCategory.SelectedValue));

                this.SaveChangesAndReload();
                this.ClearUpdateForm();
            }
        }

        private void SaveChangesAndReload()
        {
            ApplicationManager.Entities.SaveChanges();
            _Posts = ApplicationManager.Entities.Posts.ToList().AsQueryable();
        }
    }
}