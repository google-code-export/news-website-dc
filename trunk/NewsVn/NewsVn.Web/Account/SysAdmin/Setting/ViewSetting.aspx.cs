using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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