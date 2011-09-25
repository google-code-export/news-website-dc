using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using NewsVn.Impl.Context;
using System.Globalization;

namespace NewsVn.Web.Modules
{
    public partial class AdSearchResult : System.Web.UI.UserControl
    {

        public object DataSource { get; set; }    

        protected override void OnDataBinding(EventArgs e)
        {
            this.LoadResultAds();
        }

        private void LoadResultAds()
        {
            lvAdResult.DataSource = DataSource;
            lvAdResult.DataBind();
        }
       
        protected void lvAdResult_PagePropertiesChanged(object sender, EventArgs e)
        {
            LoadResultAds();
        }

        protected void lvAdResult_DataBound(object sender, EventArgs e)
        {
            pnPagerAdContainer.Visible = dpAdResult.PageSize < dpAdResult.TotalRowCount;
        }

    }
}