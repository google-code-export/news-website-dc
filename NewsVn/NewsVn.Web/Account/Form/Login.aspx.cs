using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsVn.Web.Account.Form
{
    public partial class Login : BaseUI.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(IsPostBack))
            {
                if (!Context.User.Identity.IsAuthenticated)
                {
                    var login = loginView.FindControl("login") as System.Web.UI.WebControls.Login;
                    login.FailureText = string.Format(ErrorBar, "Đăng nhập không thành công.");
                }
            }
        }
    }
}