using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsVn.Web.Modules
{
    public partial class FocusPostsPortlet : System.Web.UI.UserControl
    {
        public object Datasource { get; set; }
        protected override void OnDataBinding(EventArgs e)
        {
            rptFocusPost.DataSource = Datasource;
            rptFocusPost.DataBind();
        }
    }
}