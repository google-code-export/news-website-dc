using System;
using System.Linq;
using System.Web.UI.WebControls;
using NewsVn.Impl.Context;

namespace NewsVn.Web.Modules
{
    public partial class ProfileSearchBox : BaseUI.BaseModule
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    GenerateAgeDropDownLists();
                    LoadLocation();
                    Utils.ApplicationKeyValueRef.BindingDataToComboBox(ddlCountry, "Dropdown.Nation");
                    Utils.ApplicationKeyValueRef.BindingDataToComboBox(ddlGender, "Dropdown.Gender");
                    Utils.ApplicationKeyValueRef.BindingDataToComboBox(ddlEducation, "Dropdown.Education");
                    Utils.ApplicationKeyValueRef.BindingDataToComboBox(ddlSmoke, "Dropdown.Smoke");
                    Utils.ApplicationKeyValueRef.BindingDataToComboBox(ddlDrink, "Dropdown.Drunk");
                    Utils.ApplicationKeyValueRef.BindingDataToComboBox(ddlReligion, "Dropdown.Religion");
                    Utils.ApplicationKeyValueRef.BindingDataToComboBox(ddlMaritalStatus, "Dropdown.MaritalStatus");
                    Utils.ApplicationKeyValueRef.BindingDataToComboBox(ddlAvatarAvailable, "Dropdown.HasAvatar");
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                //gender-fagetage-avatar-material-education-religion-smoke-drink-nation-city-name
                string query = ddlGender.SelectedValue + "-" + ddlFromAge.SelectedValue + ddlToAge.SelectedValue + "-" + ddlAvatarAvailable.SelectedValue + "-" + ddlMaritalStatus.SelectedValue + "-" + ddlEducation.SelectedValue + "-" + ddlReligion.SelectedValue + "-" + ddlSmoke.SelectedValue + "-" + ddlDrink.SelectedValue + "-";
                query += ddlCountry.SelectedValue + "-" + ddlLocation.SelectedValue + "-" + Utils.clsCommon.RemoveDangerousMarks(txtName.Text.Trim().Length >= 1 ? txtName.Text.Trim().ToLower() : "0");
                string[] arr = query.Split('-');
                Response.Redirect(HostName + "tinh-yeu-gia-dinh/tim-ban-tim-kiem/" + query + ".aspx");
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void GenerateAgeDropDownLists()
        {
            try
            {
                string age = string.Empty;
                for (int i = 18; i <= 80; i++)
                {
                    age = i.ToString();
                    ddlFromAge.Items.Add(new ListItem(age, age));
                    ddlToAge.Items.Add(new ListItem(age, age));
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            //LoadLocationByCountryId(ddlCountry.SelectedValue);
        }

        private void LoadLocationByCountryId(string strCountryId)
        {
            using (var ctx = new NewsVnContext(Utils.ApplicationManager.ConnectionString))
            {
                var _Location = ctx.LocationRepo.Getter.getEnumerable(l => l.CountryID == int.Parse(strCountryId))
                    .Select(l => new
                    {
                        l.LocationID,
                        l.LocationName 
                    }).ToList();

                ddlLocation.DataSource = _Location;
                ddlLocation.DataTextField = "LocationName";
                ddlLocation.DataValueField = "LocationID";
                ddlLocation.DataBind();
            }
        }

        private void LoadLocation()
        {
            using (var ctx = new NewsVnContext(Utils.ApplicationManager.ConnectionString))
            {
                var _Location = ctx.LocationRepo.Getter.getEnumerable()
                    .Select(l => new
                    {
                        l.LocationID,
                        l.LocationName
                    }).ToList();

                ddlLocation.DataSource = _Location;
                ddlLocation.DataTextField = "LocationName";
                ddlLocation.DataValueField = "LocationID";
                ddlLocation.DataBind();
            }
        }
                         
    }
}