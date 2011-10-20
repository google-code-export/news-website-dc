using System;

namespace NewsVn.Web.Modules
{
    public partial class RandomProfileBox : BaseUI.BaseModule
    {
        public string Position { get; set; }
        public object Datasource { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected override void OnDataBinding(EventArgs e)
        {
            rptRandomUserProfile.DataSource = Datasource;
            rptRandomUserProfile.DataBind();
        }
    }
}