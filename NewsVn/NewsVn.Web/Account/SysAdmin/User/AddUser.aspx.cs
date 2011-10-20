using System;

namespace NewsVn.Web.Account.SysAdmin.User
{
    public partial class AddUser : BaseUI.SecuredPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = this.SiteTitle + "Thêm tài khoản mới";
        }
    }
}