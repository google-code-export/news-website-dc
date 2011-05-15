using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;

namespace NewsVn.Web.Modules
{
    public partial class QuickSearchResult : BaseUI.BaseModule
    {
        public object Datasource { get; set; }
        public int ItemFounded { get; set; }
        public string keySearch { get; set; }
        protected void Page_Load(object sender, EventArgs args)
        {
            if (!IsPostBack)
            {
                this.LoadResultPosts();
            }
        }

        protected void lvResultPosts_DataBound(object sender, EventArgs e)
        {
            
            bool moreThanOnePage =  pagerResultPosts.PageSize < pagerResultPosts.TotalRowCount;

            //pagerResultPosts.Visible = moreThanOnePage;

            // this check is important to avoid touching the Hyperlinks if the Pager doesn't configured to use Query string Field
            if (!string.IsNullOrEmpty(pagerResultPosts.QueryStringField) && moreThanOnePage)
            {
                foreach (DataPagerFieldItem Pitem in pagerResultPosts.Controls)
                {
                    foreach (Control c in Pitem.Controls)
                    {
                        if (c is HyperLink)
                        {
                            HyperLink tmp = c as HyperLink;

                            // check if the navigate url contains 'page' query string
                            if (tmp.NavigateUrl.IndexOf(pagerResultPosts.QueryStringField + "=") != -1)
                            {
                                string pageIndexString = tmp.NavigateUrl.Split(new string[]
                                { pagerResultPosts.QueryStringField + "=" }, StringSplitOptions.RemoveEmptyEntries)[1];

                                // check if current url contains 'scope' query string
                                string keysearch = Request.QueryString["keysearch"];
                                // don't write page index for the first page
                                if (pageIndexString.Equals("1"))
                                {
                                    tmp.NavigateUrl = string.Format("{0}tim-kiem/{1}.aspx",
                                        HostName,keysearch);
                                }
                                else
                                {
                                    tmp.NavigateUrl = string.Format("{0}tim-kiem/{1}/trang-{2}.aspx",
                                        HostName, keysearch, pageIndexString);
                                }
                            }
                        }
                    }
                }
            }
            
        }

        protected void lvResultPosts_PagePropertiesChanged(object sender, EventArgs e)
        {
            this.LoadResultPosts();
        }

        private void LoadResultPosts()
        {
            //Sample List used only for building layout
            //Replace with real data list

            lvResultPosts.DataSource = Datasource;
            lvResultPosts.DataBind();
        }
    }
}