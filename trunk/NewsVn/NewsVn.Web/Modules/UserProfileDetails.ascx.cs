using System;
using System.Collections.Generic;
using System.Linq;
using NewsVn.Impl.Context;
using NewsVn.Web.Utils;

namespace NewsVn.Web.Modules
{
    public partial class UserProfileDetails : BaseUI.BaseModule
    {
        public Impl.Entity.UserProfile Datasource { get; set; }
        //Sample property used only for building layout
        //Replace with real UserProfile.ShowEmail
        public bool ShowEmail { get; set; }
        //Sample property used only for building layout
        //Replace with real UserProfile.ShowPhone
        public bool ShowPhone { get; set; }
        //Use to set sample properties
        //used only for building layout
        public List<string> arr { get; set; }
        protected override void OnInit(EventArgs e)
        {
            Datasource = new Impl.Entity.UserProfile();
            
        }
        protected override void OnDataBinding(EventArgs e)
        {
            //<%--Every user has maximum 3 avatars, first avatar will be shown on profile list, if user didnt upload an avatar, use default 'No Photo' image in replace--%>
            //<%--In database, each image url will be separated by ';'--%>
            try
            {
                arr = Datasource.Avatar.Split(';').ToList();
                int count = arr.Count();
                while (count <= 2)
                {
                    arr.Add("resources/Images/No_Image/no_avatar.jpg");
                    count++;
                }
                Image2.ImageUrl = Utils.ApplicationManager.HostName + arr[0];
            }
            catch (Exception)
            {

                Image2.ImageUrl = Utils.ApplicationManager.HostName + "resources/Images/No_Image/no_avatar.jpg";
            }
            using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
            {
                string strAcc = Request.QueryString["acc"];
            }
            this.ShowEmail = Datasource.ShowEmail;
            this.ShowPhone = Datasource.ShowPhone;
            lblGender.Text = ApplicationKeyValueRef.GetKeyValue("Dropdown.Gender", Datasource.Gender.ToString());
            lblReligion.Text = ApplicationKeyValueRef.GetKeyValue("Dropdown.Religion", Datasource.Religion.ToString());
            lblMarialStatus.Text = ApplicationKeyValueRef.GetKeyValue("Dropdown.MaritalStatus", Datasource.MaritalStatus.ToString());
            lblEducation.Text = ApplicationKeyValueRef.GetKeyValue("Dropdown.Education", Datasource.Education.ToString());
            lblHeight.Text = string.IsNullOrEmpty(Datasource.Height.ToString()) ? "" : Datasource.Height.ToString() + " (cm)";
            lblWeight.Text = string.IsNullOrEmpty(Datasource.Weight.ToString()) ? "" : Datasource.Weight.ToString() + " (kg)";
            if (Datasource.Country.HasValue)
                lblCountry.Text = ApplicationKeyValueRef.getLocationNameByID(Datasource.Country.Value);
            if (Datasource.Location.HasValue)
                lblLocation.Text = ApplicationKeyValueRef.getLocationNameByID(Datasource.Location.Value);
           
        }
    }
}