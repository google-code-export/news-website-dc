using System;

namespace NewsVn.Web.Modules
{
    public partial class SpecialAdPostsPortlet : System.Web.UI.UserControl
    {
        public object Datasource { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected override void OnDataBinding(EventArgs e)
        {
            rptSpecialAds.DataSource = Datasource;
            rptSpecialAds.DataBind();
        }
    }
}