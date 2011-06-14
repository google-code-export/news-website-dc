using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewsVn.Impl.Context;
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
            using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
            {
                var cates = ctx.CategoryRespo.Getter.getQueryable(c => c.Type.Trim().ToLower() == "post")
                    .OrderByDescending(c => c.Parent == null).ThenBy(c => c.Parent.Name);

                foreach (var cate in cates)
                {
                    if (cate.Parent == null)
                        ddlCategory.Items.Add(new ListItem(cate.Name, cate.ID.ToString()));
                    else
                        ddlCategory.Items.Add(new ListItem(cate.Parent.Name + " / " + cate.Name, cate.ID.ToString()));
                }
            }
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
                using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
                {
                    int postID = -1;
                    int.TryParse(Request.QueryString["pid"], out postID);

                    var post = ctx.PostRespo.Getter.getOne(p => p.ID == postID);

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
        }

        private void AddNewPost()
        {
            try
            {
                using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
                {
                    var cate = ctx.CategoryRespo.Getter.getOne(c => c.ID == int.Parse(ddlCategory.SelectedValue));

                    var post = new Impl.Entity.Post
                    {
                        Title = txtTitle.Text.Trim(),
                        Avatar = txtAvatar.Text.Trim(),
                        Actived = chkActived.Checked,
                        AllowComments = chkAllowComments.Checked,
                        CheckPageView = chkCheckPageView.Checked,
                        PageView = 0,
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

                    ctx.PostRespo.Setter.addOne(post);

                    post.SeoUrl = string.Format("pt/{0}/{1}/{2}.aspx", cate.SeoName, post.ID, clsCommon.RemoveUnicodeMarks(post.Title));
                    ctx.SubmitChanges();

                    this.ClearUpdateForm();
                }
            }
            catch (Exception ex)
            {
                ltrError.Text = string.Format(ErrorBar, ex.Message);
            }
        }

        private void ModifyPost(int postID)
        {
            using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
            {
                var post = ctx.PostRespo.Getter.getOne(p => p.ID == postID);

                if (post != null)
                {
                    var cate = ctx.CategoryRespo.Getter.getOne(c => c.ID == int.Parse(ddlCategory.SelectedValue));

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
                    post.Category = cate;

                    ctx.SubmitChanges();
                    this.ClearUpdateForm();
                }
            }
        }
    }
}