using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
                foreach (var post in this.getSelectedPosts())
                {
                    ApplicationManager.Entities.DeleteObject(post);
                }

                this.SaveChangesAndReload();                
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
                foreach (var post in this.getSelectedPosts())
                {
                    post.Actived = !post.Actived;
                }

                this.SaveChangesAndReload();
            }
            catch (Exception)
            {
                ltrError.Text = string.Format(ErrorBar, "Không thể ẩn tin được chọn!");
            }

            this.GoToCurrentPage();
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var post in this.getSelectedPosts().Where(p => !p.Approved))
                {
                    post.Approved = true;
                    post.ApprovedOn = DateTime.Now;
                    post.ApprovedBy = HttpContext.Current.User.Identity.Name;
                }

                this.SaveChangesAndReload();
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
                rptPostList.DataSource = _Posts.Where(p => p.GetType().GetProperty(filterColumn).GetValue(p, null).ToString().Contains(filterText));
                rptPostList.DataBind();
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
            rptPostList.DataSource = _Posts.Select(p => new {
               p.ID, p.Title, p.SeoUrl,
               p.CreatedOn, p.CreatedBy, p.UpdatedOn, p.UpdatedBy,
               p.Approved, p.ApprovedOn, p.ApprovedBy, p.Actived,
               CategoryID = p.Category.ID,p.PageView,
               CategoryName = p.Category.Parent == null ? p.Category.Name : p.Category.Parent.Name + "/" + p.Category.Name
            }).OrderByDescending(p => p.ApprovedOn).ThenByDescending(p => p.ApprovedOn)
                .Skip((pageIndex - 1) * pageSize).Take(pageSize);
            rptPostList.DataBind();
        }

        private void GenerateDataPager(int pageSize)
        {
            int numOfPages = (int)Math.Ceiling((decimal)_Posts.Count() / pageSize);
            ddlPageIndex.Items.Clear();
            for (int i = 1; i <= numOfPages; i++)
            {
                ddlPageIndex.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }

        private IQueryable<Data.Post> getSelectedPosts()
        {
            var selectedPosts = new List<Data.Post>();
            int postID = -1;

            foreach (RepeaterItem item in rptPostList.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    CheckBox chkID = item.FindControl("chkID") as CheckBox;

                    if (chkID.Checked)
                    {
                        HiddenField hidID = item.FindControl("hidID") as HiddenField;
                        postID = int.Parse(hidID.Value);
                        selectedPosts.Add(_Posts.FirstOrDefault(p => p.ID == postID));
                    }
                }
            }

            return selectedPosts.AsQueryable();
        }

        private void SaveChangesAndReload()
        {
            ApplicationManager.Entities.SaveChanges();
            _Posts = ApplicationManager.Entities.Posts.AsQueryable();
        }
    }
}