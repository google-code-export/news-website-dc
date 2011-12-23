using System;

namespace NewsVn.Web.BaseUI
{
    public class SecuredPage : BasePage
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            SiteTitle = "NewsVN - Trang bảo mật ";
        }

        protected override void OnLoad(EventArgs e)
        {
            ExeSeo = false;

            base.OnLoad(e);
        }
    }
}