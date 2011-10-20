using System;

namespace NewsVn.Web.Modules
{
    public partial class RelatedPostList : System.Web.UI.UserControl
    {
        public string HostName { get; set; }
        public object Datasource { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected override void OnDataBinding(EventArgs e)
        {
            rptRelationPost.DataSource = Datasource;
            rptRelationPost.DataBind();
        }
    }
}