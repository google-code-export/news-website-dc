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
    public partial class ViewAdPost : BaseUI.SecuredPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = SiteTitle + "Quản lý rao nhanh";

            if (!IsPostBack)
            {
                this.GoToPage(1, int.Parse(ddlPageSize.SelectedValue));
            }
        }

        protected void Sorter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Pager_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GoToCurrentPage();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }

        protected void btnToggleActive_Click(object sender, EventArgs e)
        {

        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.GoToCurrentPage();
        }

        protected void btnClearSort_Click(object sender, EventArgs e)
        {

        }

        protected void btnClearFilter_Click(object sender, EventArgs e)
        {

        }

        private void GoToCurrentPage()
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
            this.LoadAdPostList(pageIndex, pageSize);
        }

        private void LoadAdPostList(int pageIndex, int pageSize)
        {
            using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
            {
                var adposts = ctx.AdPostRepo.Getter.getQueryable().OrderByDescending(p => p.CreatedOn);
                rptAdPostList.DataSource = ctx.AdPostRepo.Getter.getPagedList(adposts, pageIndex, pageSize).Select(p => new
                {
                    p.ID,
                    p.Title,
                    TitleCssClass = GetTitleCssClass(p.Actived, p.ExpiredOn),
                    p.SeoUrl,
                    p.CreatedOn,
                    p.CreatedBy,
                    p.UpdatedOn,
                    p.UpdatedBy,
                    p.ExpiredOn,
                    p.Actived,
                    CategoryID = p.Category.ID,
                    CategoryName = p.Category.Parent == null ? p.Category.Name : p.Category.Parent.Name + "/" + p.Category.Name
                });
                rptAdPostList.DataBind();
            }
        }

        private void GenerateDataPager(int pageSize)
        {
            using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
            {
                int numOfPages = (int)Math.Ceiling((decimal)ctx.AdPostRepo.Getter.getQueryable().Count() / pageSize);
                ddlPageIndex.Items.Clear();
                for (int i = 1; i <= numOfPages; i++)
                {
                    ddlPageIndex.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }
            }
        }

        private string GetTitleCssClass(bool actived, DateTime? expiredOn)
        {
            string cssClass = string.Empty;

            if (!actived)
            {
                cssClass += "post-not-actived ";
            }

            if (expiredOn.HasValue && expiredOn.Value < DateTime.Now)
            {
                cssClass += "post-expired ";
            }

            return cssClass;
        }
    }
}