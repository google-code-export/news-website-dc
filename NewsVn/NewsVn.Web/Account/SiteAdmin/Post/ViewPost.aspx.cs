using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
               CategoryName = p.Category.Parent == null ? p.Category.Name : p.Category.Parent.Name + "/" + p.Category.Name,
               CategorySeoUrl = p.Category.SeoUrl
            }).OrderByDescending(p => p.CreatedOn).Skip((pageIndex - 1) * pageSize).Take(pageSize);
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
    }
}