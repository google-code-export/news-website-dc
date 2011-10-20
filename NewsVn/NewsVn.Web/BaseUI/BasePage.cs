using System;
using System.Text;
using NewsVn.Web.Utils;

namespace NewsVn.Web.BaseUI
{
    public class BasePage : System.Web.UI.Page
    {
        public string SiteTitle { get; set; }

        public string InfoBar { get; set; }
        public string ErrorBar { get; set; }

        public string HostName { get; set; }

        protected override void OnInit(EventArgs e)
        {
            SiteTitle = "NewsVN - xxx :: ";

            var sb = new StringBuilder();
            sb.Append("<li><div class=\"ui-widget\"><div class=\"ui-state-highlight ui-corner-all\" style=\"padding: 0 .7em;\">");
            sb.Append("<p><span class=\"ui-icon ui-icon-info\" style=\"float: left; margin: .15em .3em 0 0;\"></span>");
            sb.Append("<b>&raquo;</b> {0}</p></div></div></li>");
            InfoBar = sb.ToString();

            sb = new StringBuilder();
            sb.Append("<li><div class=\"ui-widget\"><div class=\"ui-state-error ui-corner-all\" style=\"padding: 0 .7em;\">");
            sb.Append("<p><span class=\"ui-icon ui-icon-alert\" style=\"float: left; margin: .15em .3em 0 0;\"></span>");
            sb.Append("<b>&raquo;</b> {0}</p></div></div></li>");
            ErrorBar = sb.ToString();

            HostName = ApplicationManager.HostName;

            base.OnInit(e);
        }
    }
}