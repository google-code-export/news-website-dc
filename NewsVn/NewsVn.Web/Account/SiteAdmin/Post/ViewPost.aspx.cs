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
            if (!IsPostBack)
            {
                this.GoToPage(1, 35);
            }
        }

        protected void Pager_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pageIndex = int.Parse(ddlPageIndex.SelectedValue);
            int pageSize = int.Parse(ddlPageSize.SelectedValue);
            this.GoToPage(pageIndex, pageSize);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var post in this.getSelectedPosts())
                {
                    ApplicationManager.Entities.DeleteObject(post);
                }

                ApplicationManager.Entities.SaveChanges();

                this.Pager_SelectedIndexChanged(sender, e);
            }
            catch (Exception)
            {
                clsCommon.Excute_Javascript("alert('Không thể xóa tin được chọn!')", this);
            }
        }

        protected void btnToggleActive_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var post in this.getSelectedPosts())
                {
                    post.Actived = !post.Actived;
                }

                ApplicationManager.Entities.SaveChanges();

                this.Pager_SelectedIndexChanged(sender, e);
            }
            catch (Exception)
            {
                clsCommon.Excute_Javascript("alert('Không thể ẩn tin được chọn!')", this);
            }
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

                ApplicationManager.Entities.SaveChanges();

                this.Pager_SelectedIndexChanged(sender, e);
            }
            catch (Exception)
            {
                clsCommon.Excute_Javascript("alert('Không thể duyệt tin được chọn!')", this);
            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.Pager_SelectedIndexChanged(sender, e);
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            string filterColumn = ddlFilterColumn.SelectedValue;
            string filterText = txtFilterText.Text;

            rptPostList.DataSource = _Posts.Where(p => p.GetType().GetProperty(filterColumn).GetValue(p, null).ToString().Contains(filterText));
            rptPostList.DataBind();
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
               p.ID, ShortTitle = clsCommon.getEllipsisText(p.Title, 30), p.Title, p.SeoUrl,
               p.CreatedOn, p.CreatedBy, p.UpdatedOn, p.UpdatedBy,
               p.Approved, p.ApprovedOn, p.ApprovedBy, p.Actived,
               CategoryID = p.Category.ID,
               CategoryName = p.Category.Parent == null ? p.Category.Name : p.Category.Parent.Name + "/" + p.Category.Name
            }).OrderByDescending(p => p.CreatedOn).ThenByDescending(p => p.ApprovedOn)
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

            return _Posts.Where(p => selectedPostIDs.Contains(p.ID));
        }
    }
}