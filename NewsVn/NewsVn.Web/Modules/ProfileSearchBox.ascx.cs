using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsVn.Web.Modules
{
    public partial class ProfileSearchBox : BaseUI.BaseModule
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //gender-fagetage-avatar-material-education-religion-smoke-drink-nation-city-name
            string query =  ddlGender.SelectedValue + "-" + ddlFromAge.SelectedValue + ddlToAge.SelectedValue + "-" + ddlAvatarAvailable.SelectedValue + "-" + ddlMaritalStatus.SelectedValue + "-" + ddlEducation.SelectedValue + "-" + ddlReligion.SelectedValue + "-" + ddlSmoke.SelectedValue + "-" + ddlDrink.SelectedValue + "-"; 
            query+= ddlCountry.SelectedValue + "-" + Utils.clsCommon.RemoveDangerousMarks(txtLocation.Text.Trim().Length>=1?txtLocation.Text.Trim().ToLower():"0") + "-" + Utils.clsCommon.RemoveDangerousMarks(txtName.Text.Trim().Length>=1?txtName.Text.Trim().ToLower():"0");
            string[] arr = query.Split('-');
            Response.Redirect(HostName + "tinh-yeu-gia-dinh/tim-ban-tim-kiem/" + query + ".aspx");
        }
    }
}