using System;

namespace NewsVn.Web.Account.SysAdmin.Setting
{
    public partial class ViewSetting : BaseUI.SecuredPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = this.SiteTitle + "Quản lý cấu hình";
        }
    }
}