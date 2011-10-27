using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsVn.Web.Modules
{
    public partial class BannerControl : BaseUI.SecuredModule
    {
        public int BannerPosition { get; set; }
        public int BannerType { get; set; }
        public int RepeatDirection { get; set; }
        public object Datasource { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
             //Response.Write(BannerType.ToString());
            
        }
        protected override void OnDataBinding(EventArgs e)
        {
            rptBanner.DataSource = Datasource;
            rptBanner.DataBind();
        }
    }
}