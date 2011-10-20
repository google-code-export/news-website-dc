using System;
using System.Text.RegularExpressions;
using System.Web;
using NewsVn.Web.Utils;

namespace NewsVn.Web
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            ApplicationManager.Init();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            string redirectUrl = this.Response.RedirectLocation;
            if (!this.Request.RawUrl.Contains("ReturnUrl=") && !string.IsNullOrEmpty(redirectUrl))
            {
                this.Response.RedirectLocation = Regex.Replace(redirectUrl, "ReturnUrl=(?'url'[^&]*)", delegate(Match m)
                {
                    return string.Format("returnurl={0}", HttpUtility.UrlEncode(this.Request.RawUrl));
                }, RegexOptions.Singleline | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture);
            }
        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}