using System.Text;
using NewsVn.Web.Utils;

namespace NewsVn.Web.BaseUI
{
    public class BaseService : System.Web.Services.WebService
    {
        public string HostName { get; set; }
        public static string[] skyStatus { get; set; }
        protected string _CacheName;

        public string InfoBar { get; set; }
        public string ErrorBar { get; set; }

        public BaseService()
        {
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

            skyStatus = ApplicationManager.skyStatus;
            HostName = NewsVn.Web.Utils.ApplicationManager.HostName;
        }
    }
}