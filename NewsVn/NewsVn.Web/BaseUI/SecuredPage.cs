using System;

namespace NewsVn.Web.BaseUI
{
    public class SecuredPage : BasePage
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            SiteTitle = "NewsVN - Cổng thông tin điện tử 24/07 ::: ";
        }
    }
}