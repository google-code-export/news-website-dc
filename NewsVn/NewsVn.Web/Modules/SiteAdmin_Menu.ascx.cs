using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsVn.Web.Modules
{
    public partial class SiteAdmin_Menu : BaseUI.SecuredModule
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var links = (from c in this.Controls.Cast<Control>() where c.GetType() == typeof(HyperLink) select c)
                    .ToList().ConvertAll<HyperLink>(l => (HyperLink)l);
                var activeLink = (from l in links where l.CssClass == (SiteMap.CurrentNode != null ? SiteMap.CurrentNode.Description : "") select l)
                    .FirstOrDefault();
                if (activeLink != null) { activeLink.CssClass += " selected"; }
            }
        }
    }
}