using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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