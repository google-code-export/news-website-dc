using System;

namespace NewsVn.Web.Modules
{
    public partial class FocusPostsPortlet : System.Web.UI.UserControl
    {
        public string HostName { get; set; }
        public object Datasource { get; set; }
        protected override void OnDataBinding(EventArgs e)
        {
            rptFocusPost.DataSource = Datasource;
            rptFocusPost.DataBind();
        }
    }
}