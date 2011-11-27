using System;

namespace NewsVn.Web.Account.Form
{
    public partial class Login : BaseUI.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SiteTitle += "Đăng nhập";
            
            if (!(IsPostBack))
            {
                if (!Context.User.Identity.IsAuthenticated)
                {
                    var login = loginView.FindControl("login") as System.Web.UI.WebControls.Login;
                    login.FailureText = string.Format(ErrorBar, "Thông tin sai. Đăng nhập không thành công.");
                }
            }
        }
    }
}