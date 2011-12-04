using System;

namespace NewsVn.Web.Account.SiteAdmin.AdPost
{
    public partial class EditAdPost : BaseUI.SecuredPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SiteTitle += "Sửa thông tin rao nhanh";
        }
    }
}