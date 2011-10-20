using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewsVn.Impl.Context;
using NewsVn.Web.Utils;

namespace NewsVn.Web.Account.Guest
{
    public partial class MyProfile : BaseUI.SecuredPage
    {
        // HttpContext.Current.User.Identity.Name
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
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = this.SiteTitle + "Tài khoản của tôi";
            
            if (!IsPostBack)
            {
                load_UserDetail();
            }
        }
        void load_UserDetail()
        {
            try
            {
                using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
                {
                    var _UserProfiles = ctx.UserProfileRepo.Getter.getOne(u => u.Account.Equals(HttpContext.Current.User.Identity.Name, StringComparison.OrdinalIgnoreCase));
                    // BaseUI.BaseMaster.ExecuteSEO("Thông tin hồ sơ " + Account, "newsvn, newsvn.vn, ket noi ban be, tim ban 4 phuong," + clsCommon.RemoveUnicodeMarks(_UserProfiles.Description).Replace('-', ' ') + " - " + clsCommon.RemoveUnicodeMarks(_UserProfiles.Expectation).Replace('-', ' '), Account + " - " + _UserProfiles.Description + " - " + _UserProfiles.Expectation);
                    lblNickName.Text = _UserProfiles.Nickname;
                    lblNickName_01.Text = _UserProfiles.Nickname;
                    lblGender.Text = Utils.ApplicationKeyValueRef.GetKeyValue("Dropdown.Gender", _UserProfiles.Gender.ToString());
                    lblAge.Text = _UserProfiles.Age.ToString();
                    lblBodyShape.Text = _UserProfiles.BodyShape;
                    lblCountry.Text =  Utils.ApplicationKeyValueRef.GetKeyValue("Dropdown.Nation", _UserProfiles.Country.ToString());
                    lblDescription.Text = _UserProfiles.Description;
                    lblDrink.Text = _UserProfiles.Drink == true ? "Có" : "Không";
                    lblEdu.Text = Utils.ApplicationKeyValueRef.GetKeyValue("Dropdown.Education", _UserProfiles.Education.ToString());
                    lblExpectation.Text = _UserProfiles.Expectation;
                    lblFullName.Text = _UserProfiles.Name;
                    lblHeight.Text = _UserProfiles.Height.ToString();
                    lblMarialStatus.Text = Utils.ApplicationKeyValueRef.GetKeyValue("Dropdown.MaritalStatus", _UserProfiles.MaritalStatus.ToString());
                    lblOccu.Text = _UserProfiles.Career;
                    lblProvince.Text = Utils.ApplicationKeyValueRef.getLocationNameByID(_UserProfiles.Location.Value);
                    lblReligion.Text = Utils.ApplicationKeyValueRef.GetKeyValue("Dropdown.Religion", _UserProfiles.Religion.ToString()); 
                    lblSmoke.Text = _UserProfiles.Smoke == true ? "Có" : "Không";
                    lblWeight.Text = _UserProfiles.Weight.ToString();

                    lblPhone.Text = _UserProfiles.Phone;
                    lblEmail.Text = _UserProfiles.Email;
                    chkShowEmail.Checked = _UserProfiles.ShowPhone;
                    chkShowEmail.Checked = _UserProfiles.ShowEmail;

                    try
                    {
                        arr = _UserProfiles.Avatar.Split(';').ToList();
                        int count = arr.Count();
                        while (count <= 2)
                        {
                            arr.Add("/resources/Images/No_Image/no_avatar.jpg");
                            count++;
                        }
                        Image2.ImageUrl = arr[0];
                        Image3.ImageUrl = arr[1];
                        Image4.ImageUrl = arr[2];
                    }
                    catch (Exception)
                    {

                        Image2.ImageUrl = "/resources/Images/No_Image/no_avatar.jpg";
                        Image3.ImageUrl = "/resources/Images/No_Image/no_avatar.jpg";
                        Image4.ImageUrl = "/resources/Images/No_Image/no_avatar.jpg";
                    }

                    _UserProfiles = null;


                }
            }
            catch
            {

            }
        }
        protected override void OnDataBinding(EventArgs e)
        {
            //<%--Every user has maximum 3 avatars, first avatar will be shown on profile list, if user didnt upload an avatar, use default 'No Photo' image in replace--%>
            //<%--In database, each image url will be separated by ';'--%>

            //try
            //{
            //    arr = Datasource.Avatar.Split(';').ToList();
            //    int count = arr.Count();
            //    while (count <= 2)
            //    {
            //        arr.Add("/resources/Images/No_Image/no_avatar.jpg");
            //        count++;
            //    }
            //    Image2.ImageUrl = arr[0];
            //    Image3.ImageUrl = arr[1];
            //    Image4.ImageUrl = arr[2];
            //}
            //catch (Exception)
            //{

            //    Image2.ImageUrl = "/resources/Images/No_Image/no_avatar.jpg";
            //    Image3.ImageUrl = "/resources/Images/No_Image/no_avatar.jpg";
            //    Image4.ImageUrl = "/resources/Images/No_Image/no_avatar.jpg";
            //}

            //this.ShowEmail = Datasource.ShowEmail;
            //this.ShowPhone = Datasource.ShowPhone;
        }
    }
}
