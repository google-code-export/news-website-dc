using System;

namespace NewsVn.Web.Account.SiteAdmin.Misc
{
    public partial class ViewVideoBox : BaseUI.SecuredPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SiteTitle += "Quản lý Video quảng cáo";
        }
    }
}