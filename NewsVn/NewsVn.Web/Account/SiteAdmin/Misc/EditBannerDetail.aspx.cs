using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewsVn.Impl.Context;
using NewsVn.Web.Utils;

namespace NewsVn.Web.Account.SiteAdmin.AdPost
{
    public partial class EditBannerDetail : BaseUI.SecuredPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SiteTitle += "Sửa thông tin Banner quảng cáo";
        }                
    }
}