using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsVn.Web.Exceptions
{
    public partial class Common : BaseUI.BasePage
    {
        protected string ErrorDetails { get; set; }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ErrorDetails = "Lỗi xảy ra trong quá trình xử lý.";
                if (Session["error-details"] != null)
                {
                    ErrorDetails = Session["error-details"].ToString();
                }
                ltrError.Text = string.Format(ErrorBar, ErrorDetails + " Click <a href='" + HostName + "trang-chu.aspx' style='color:#fff;font-weight:bold'>vào đây</a> để trở về trang chủ.");
            }
        }
    }
}