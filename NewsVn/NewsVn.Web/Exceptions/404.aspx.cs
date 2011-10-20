using System;

namespace NewsVn.Web.Exceptions
{
    public partial class _404 : BaseUI.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ltrError.Text = string.Format(ErrorBar, "Không tìm thấy trang được yêu cầu. Click <a href='" + HostName + "trang-chu.aspx' style='color:#fff;font-weight:bold'>vào đây</a> để trở về trang chủ.");
            }
        }
    }
}