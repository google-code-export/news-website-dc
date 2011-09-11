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
            if (!IsPostBack)
            {
                GenerateAgeDropDownLists();
                loadDdlGender();
                loadDdlSmoke();
                loadDdlDrunk();
                loadDdlReligion();
                loadDdlEducation();
                loadDdlAvatarAvailable();
                loadDdlCountry();
                    
            }
        }

        private void loadDdlCountry()
        {
            var countryRefValue = Utils.ApplicationKeyValueRef.GetAll().Where(g => g.Type == "List.Nation").ToList();
            ddlCountry.DataSource = countryRefValue;
            ddlCountry.DataBind();  
        }

        private void loadDdlAvatarAvailable()
        {
            var hasAvatarRefValue = Utils.ApplicationKeyValueRef.GetAll().Where(g => g.Type == "DropDown.HasAvatar").ToList();
            ddlAvatarAvailable.DataSource = hasAvatarRefValue;
            ddlAvatarAvailable.DataBind();  
        }

        private void loadDdlEducation()
        {
            var educationRefValue = Utils.ApplicationKeyValueRef.GetAll().Where(g => g.Type == "List.Education").ToList();
            ddlEducation.DataSource = educationRefValue;
            ddlEducation.DataBind();  
        }

        private void loadDdlDrunk()
        {
            var drunkRefValue = Utils.ApplicationKeyValueRef.GetAll().Where(g => g.Type == "Dropdown.Drunk").ToList();
            ddlDrink.DataSource = drunkRefValue;
            ddlDrink.DataBind();  
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //gender-fagetage-avatar-material-education-religion-smoke-drink-nation-city-name
            string query =  ddlGender.SelectedValue + "-" + ddlFromAge.SelectedValue + ddlToAge.SelectedValue + "-" + ddlAvatarAvailable.SelectedValue + "-" + ddlMaritalStatus.SelectedValue + "-" + ddlEducation.SelectedValue + "-" + ddlReligion.SelectedValue + "-" + ddlSmoke.SelectedValue + "-" + ddlDrink.SelectedValue + "-"; 
            query+= ddlCountry.SelectedValue + "-" + Utils.clsCommon.RemoveDangerousMarks(txtLocation.Text.Trim().Length>=1?txtLocation.Text.Trim().ToLower():"0") + "-" + Utils.clsCommon.RemoveDangerousMarks(txtName.Text.Trim().Length>=1?txtName.Text.Trim().ToLower():"0");
            string[] arr = query.Split('-');
            Response.Redirect(HostName + "tinh-yeu-gia-dinh/tim-ban-tim-kiem/" + query + ".aspx");
        }


        protected void loadDdlReligion()
        {
            try
            {
                var religionRefValue = Utils.ApplicationKeyValueRef.GetAll().Where(g => g.Type == "List.Religion").ToList();
                ddlReligion.DataSource = religionRefValue;
                ddlReligion.DataBind();
            }
            catch (Exception) { }
        }

        protected void GenerateAgeDropDownLists()
        {
            string age = string.Empty;
            for (int i = 18; i <= 80; i++)
            {
                age = i.ToString();
                ddlFromAge.Items.Add(new ListItem(age, age));
                ddlToAge.Items.Add(new ListItem(age, age));
            }
        }

        protected void loadDdlGender()
        {
            try
            {
                var genderRefValue = Utils.ApplicationKeyValueRef.GetAll().Where(g => g.Type == "Dropdown.Gender").ToList();
                ddlGender.DataSource = genderRefValue;
                ddlGender.DataBind();
            }
            catch (Exception) { }
        }

        protected void ddlGender_DataBinding(object sender, EventArgs e)
        {
            ddlGender.DataTextField = "Value";
            ddlGender.DataValueField = "Key";
        }

        protected void loadDdlSmoke()
        {
            try
            {
               var smokeRefValue = Utils.ApplicationKeyValueRef.GetAll().Where(g => g.Type == "Dropdown.Smoke").ToList();
                ddlSmoke.DataSource = smokeRefValue;
                ddlSmoke.DataBind();
            }
            catch (Exception){}
        }

        protected void ddlSmoke_DataBinding(object sender, EventArgs e)
        {
            ddlSmoke.DataTextField = "Value";
            ddlSmoke.DataValueField = "Key";
        }

        protected void ddlDrink_DataBinding(object sender, EventArgs e)
        {
            ddlDrink.DataTextField = "Value";
            ddlDrink.DataValueField = "Key";
        }

        protected void ddlReligion_DataBinding(object sender, EventArgs e)
        {
            ddlReligion.DataTextField = "Value";
            ddlReligion.DataValueField = "Key";
        }

        protected void ddlEducation_DataBinding(object sender, EventArgs e)
        {
            ddlEducation.DataTextField = "Value";
            ddlEducation.DataValueField = "Key";

        }

        protected void ddlAvatarAvailable_DataBinding(object sender, EventArgs e)
        {
            ddlAvatarAvailable.DataTextField = "Value";
            ddlAvatarAvailable.DataValueField = "Key";
        }

        protected void ddlCountry_DataBinding(object sender, EventArgs e)
        {
            ddlCountry.DataTextField = "Value";
            ddlCountry.DataValueField="Key";
        }
    }
}