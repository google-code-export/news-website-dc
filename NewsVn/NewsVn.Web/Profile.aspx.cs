using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewsVn.Web.Utils;
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
            var _UserProfiles=ApplicationManager.Entities.UserProfiles;
            var data = _UserProfiles.Where(u => u.Account == Account)
                .FirstOrDefault();
            pletUserProfileDetails.Datasource = data;
            pletUserProfileDetails.DataBind();
            BaseUI.BaseMaster.ExecuteSEO("Thông tin hồ sơ " + Account, "newsvn, newsvn.vn, ket noi ban be, tim ban 4 phuong," + clsCommon.RemoveUnicodeMarks(data.Description).Replace('-', ' ') + " - " + clsCommon.RemoveUnicodeMarks(data.Expectation).Replace('-', ' '), Account + " - " + data.Description + " - " + data.Expectation);
            data = null;

        }
        
    }
}