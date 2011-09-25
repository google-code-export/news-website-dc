using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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