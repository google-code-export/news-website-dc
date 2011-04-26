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
                this.LoadPostList();
                this.GenerateDataPager();
            }
        }

        private void LoadPostList()
        {
            rptPostList.DataSource = _Posts.Skip(0).Take(50);
            rptPostList.DataBind();
        }

        private void GenerateDataPager()
        {
            noPages.Text = _Posts.Count().ToString();
        }
    }
}