using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewsVn.Web.Utils;
using NewsVn.Impl.Context;
namespace NewsVn.Web
{
    public partial class Profile : BaseUI.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                load_UserProfileDetailsByAccount(Request.QueryString["acc"]);
                
            }
        }
        private void load_UserProfileDetailsByAccount(string Account)
        {
            using (var ctx=new NewsVnContext(ApplicationManager.ConnectionString))
            {
                var _UserProfiles = ctx.UserProfileRespo.Getter.getOne(u => u.Account.Equals(Account, StringComparison.OrdinalIgnoreCase));
                pletUserProfileDetails.Datasource = _UserProfiles;
                pletUserProfileDetails.DataBind();
                BaseUI.BaseMaster.ExecuteSEO("Thông tin hồ sơ " + Account, "newsvn, newsvn.vn, ket noi ban be, tim ban 4 phuong," + clsCommon.RemoveUnicodeMarks(_UserProfiles.Description).Replace('-', ' ') + " - " + clsCommon.RemoveUnicodeMarks(_UserProfiles.Expectation).Replace('-', ' '), Account + " - " + _UserProfiles.Description + " - " + _UserProfiles.Expectation);
                _UserProfiles = null;
            }
            

        }
        
    }
}