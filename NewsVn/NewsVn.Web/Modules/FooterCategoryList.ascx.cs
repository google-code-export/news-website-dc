using System;

namespace NewsVn.Web.Modules
{
    public partial class FooterCategoryList :BaseUI.BaseModule
    {
        public object Datasource { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnDataBinding(EventArgs e)
        {
            rptFooterCate.DataSource = Datasource;
            rptFooterCate.DataBind();
        }
    }
}