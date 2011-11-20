﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewsVn.Impl.Context;
using NewsVn.Web.Utils;

namespace NewsVn.Web.Account.Guest
{
    public partial class EditProfile : BaseUI.BasePage
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
            this.Title = this.SiteTitle + "Cập nhật Thông tin tài khoản";
            if (!IsPostBack)
            {
                this.GenerateAgeDropDownList();

                if (!IsPostBack)
                {
                    Utils.ApplicationKeyValueRef.BindingDataToComboBox(ddlGender, "Dropdown.Gender");
                    Utils.ApplicationKeyValueRef.BindingDataToComboBox(ddlReligion, "Dropdown.Religion");
                    Utils.ApplicationKeyValueRef.BindingDataToComboBox(ddlEdu, "Dropdown.Education");
                    Utils.ApplicationKeyValueRef.BindingDataToComboBox(ddlMaritalStatus, "Dropdown.MaritalStatus");
                    Utils.ApplicationKeyValueRef.BindingDataToComboBox(ddlCountry, "Dropdown.Nation");
                    
                    LoadLocation();
                }
                load_UserDetail();
            }
        }
        private void LoadLocation()
        {
            using (var ctx = new NewsVnContext(Utils.ApplicationManager.ConnectionString))
            {
                var _Location = ctx.LocationRepo.Getter.getQueryable(p => p.CountryID != 0)
                    .Select(l => new
                    {
                        l.LocationID,
                        l.LocationName
                    }).ToList();

                ddlProvince.DataSource = _Location;
                ddlProvince.DataTextField = "LocationName";
                ddlProvince.DataValueField = "LocationID";
                ddlProvince.DataBind();
            }
        }
        void GenerateAgeDropDownList()
        {
            string age = string.Empty;
            for (int i = 18; i <= 80; i++)
            {
                age = i.ToString();
                ddlAge.Items.Add(new ListItem(age, age));
            }
        }
        void load_UserDetail()
        {
            try
            {
                using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
                {
                    var _UserProfiles = ctx.UserProfileRepo.Getter.getOne(u => u.Account.ToLower() == HttpContext.Current.User.Identity.Name.ToLower());
                    // var mtb = new BaseUI.BaseMaster();mtb.ExecuteSEO("Thông tin hồ sơ " + Account, "newsvn, newsvn.vn, ket noi ban be, tim ban 4 phuong," + clsCommon.RemoveUnicodeMarks(_UserProfiles.Description).Replace('-', ' ') + " - " + clsCommon.RemoveUnicodeMarks(_UserProfiles.Expectation).Replace('-', ' '), Account + " - " + _UserProfiles.Description + " - " + _UserProfiles.Expectation);
                    lblNickName.Text = _UserProfiles.Nickname;
                    lblNickName_01.Text = _UserProfiles.Nickname;
                    ddlGender.SelectedValue = string.IsNullOrEmpty(_UserProfiles.Gender.ToString()) ? "0" : _UserProfiles.Gender.ToString();
                    ddlAge.SelectedValue = string.IsNullOrEmpty(_UserProfiles.Age.ToString()) ? "0" : _UserProfiles.Age.ToString();
                    txtBodySharp.Text = _UserProfiles.BodyShape;
                    ddlProvince.SelectedValue = string.IsNullOrEmpty(_UserProfiles.Location.ToString()) ? "0" : _UserProfiles.Location.ToString();
                    ddlCountry.SelectedValue = string.IsNullOrEmpty(_UserProfiles.Country.ToString()) ? "0" : _UserProfiles.Country.ToString();
                    txtDescription.Text = _UserProfiles.Description;
                    chkDrink.Checked = _UserProfiles.Drink == true ? true : false;
                    chkSmoke.Checked = _UserProfiles.Smoke == true ? true : false;
                    ddlEdu.SelectedValue = string.IsNullOrEmpty(_UserProfiles.Education.ToString()) ? "0" : _UserProfiles.Education.ToString();
                    txtExpectation.Text= _UserProfiles.Expectation;
                    txtFullName.Text = _UserProfiles.Name;
                    txtHeight.Text = _UserProfiles.Height.ToString();
                    txtWeight.Text = _UserProfiles.Weight.ToString();
                    ddlMaritalStatus.SelectedValue = string.IsNullOrEmpty(_UserProfiles.MaritalStatus.ToString()) ? "0" : _UserProfiles.MaritalStatus.ToString();
                    txtOccu.Text = _UserProfiles.Career;
                    //lblOccu.Text = _UserProfiles.Career;
                    //lblProvince.Text = Utils.ApplicationKeyValueRef.getLocationNameByID(_UserProfiles.Location.Value);
                    //lblReligion.Text = Utils.ApplicationKeyValueRef.GetKeyValue("Dropdown.Religion", _UserProfiles.Religion.ToString());
                   
                    txtPhone.Text = _UserProfiles.Phone;
                    lblEmail.Text = _UserProfiles.Email;
                    chkShowPhone.Checked = _UserProfiles.ShowPhone;
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
                {
                    var _u = ctx.UserProfileRepo.Getter.getOne(u => u.Account.Equals(HttpContext.Current.User.Identity.Name, StringComparison.OrdinalIgnoreCase));
                    // var mtb = new BaseUI.BaseMaster();mtb.ExecuteSEO("Thông tin hồ sơ " + Account, "newsvn, newsvn.vn, ket noi ban be, tim ban 4 phuong," + clsCommon.RemoveUnicodeMarks(_UserProfiles.Description).Replace('-', ' ') + " - " + clsCommon.RemoveUnicodeMarks(_UserProfiles.Expectation).Replace('-', ' '), Account + " - " + _UserProfiles.Description + " - " + _UserProfiles.Expectation);
                    _u.Gender=int.Parse( ddlGender.SelectedValue );
                    _u.Age=int.Parse( ddlAge.SelectedValue );
                    _u.BodyShape = txtBodySharp.Text;
                    _u.Country=int.Parse( ddlProvince.SelectedValue);
                    _u.Description = txtDescription.Text;
                    _u.Drink = chkDrink.Checked;
                    _u.Smoke = chkSmoke.Checked;
                    _u.Education = int.Parse(ddlEdu.SelectedValue);
                    _u.Expectation = txtExpectation.Text;
                    _u.Name = txtFullName.Text;
                    _u.Height = int.Parse(txtHeight.Text);
                    _u.Weight = int.Parse(txtWeight.Text);
                    _u.MaritalStatus = int.Parse(ddlMaritalStatus.SelectedValue);
                    _u.Career = txtOccu.Text;
                    _u.Country = int.Parse(ddlCountry.SelectedValue);
                    _u.Location = int.Parse(ddlProvince.SelectedValue);
                    _u.Phone = txtPhone.Text;
                    _u.Email = lblEmail.Text;
                    _u.ShowPhone = chkShowPhone.Checked;
                    _u.ShowEmail = chkShowEmail.Checked;
                    _u.UpdatedOn = DateTime.Now;

                    ctx.SubmitChanges();
                    Response.Redirect("~/thanh-vien/thong-tin-tai-khoan.aspx");
                }
            }
            catch(Exception ex)
            {
                ltrInitInfoError.Text = "Không thể cập nhật hồ sơ. Vui lòng thử lại. Lỗi (" + ex.Message.ToString() + ")";// string.Format(ErrorBar, "Không thể cập nhật hồ sơ. Vui lòng thử lại. Lỗi (" + ex.Message.ToString()+ ")");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/thanh-vien/thong-tin-tai-khoan.aspx");
        }
    }
}