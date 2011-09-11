using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsVn.Web.Modules
{
    public partial class FooterIntro : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                System.IO.StreamReader sr;
                sr = System.IO.File.OpenText(Page.Server.MapPath("~/Resources/Templates/NewsvnInfo.txt"));
                NewsVnInfo.InnerHtml = sr.ReadToEnd();
            }
        }
    }
}