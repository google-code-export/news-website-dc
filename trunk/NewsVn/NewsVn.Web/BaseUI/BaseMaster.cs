using System;
using NewsVn.Web.Utils;
namespace NewsVn.Web.BaseUI
{
    public class BaseMaster : System.Web.UI.MasterPage
    {
        public string HostName { get; set; }        

        protected override void OnInit(EventArgs e)
        {
            HostName = ApplicationManager.HostName;
            base.OnInit(e);
        }        
    }
}