using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using NewsVn.Web.Utils;
using System.Text.RegularExpressions;

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
            //Exception err=Server.GetLastError();
            //if (err.Message != null)
            //{
            //    if (err.Message == "The client disconnected.")
            //    {

            //        Response.Redirect("");
            //    }
            //    else if (err.Message == "File does not exist.")
            //    {
            //        Response.Redirect("");
            //    }
            //    else if (err.Message.Contains("dangerous Request.Form value"))
            //    {
            //        Response.Redirect("");
            //    }
            //    else
            //    {
            //        Response.Redirect("");
            //    }
            //}
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}