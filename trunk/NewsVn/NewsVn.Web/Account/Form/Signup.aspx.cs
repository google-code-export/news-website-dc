using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using NewsVn.Impl.Context;
using NewsVn.Web.Utils;

namespace NewsVn.Web.Account.Form
{
    public partial class Signup : BaseUI.BasePage
    {
        MembershipUser newUser;

        protected void Page_Load(object sender, EventArgs args)
        {
            this.Title = SiteTitle + "Đăng ký";

            this.GenerateAgeDropDownList();

            if (!IsPostBack)
            {
                ltrTitle.Text = wzUserSignUp.ActiveStep.Title;
            }
        }

        private void GenerateAgeDropDownList()
        {
            string age = string.Empty;
            for (int i = 18; i <= 80; i++)
            {
                age = i.ToString();
                ddlAge.Items.Add(new ListItem(age, age));
            }
        }

        protected void wzUserSignUp_OnActiveStepChanged(object sender, EventArgs args)
        {
            ltrTitle.Text = wzUserSignUp.ActiveStep.Title;

            if (wzUserSignUp.ActiveStepIndex == 2)
            {
                pnAgreement.Visible = false;
            }
        }

        protected void Start_Click(object sender, EventArgs args)
        {
            var mcs = new MembershipCreateStatus();
            bool success = false;

            newUser = Membership.CreateUser(txtUsername.Text.Trim(), txtConfirmPassword.Text, txtEmail.Text.Trim(), ddlSecurityQuestion.SelectedItem.Text, txtSecurityAnswer.Text.Trim(), true, out mcs);

            switch (mcs)
            {
                case MembershipCreateStatus.Success:
                    success = true;
                    break;
                case MembershipCreateStatus.DuplicateEmail:
                    ltrCreateAccountError.Text = string.Format(ErrorBar, "Email đã được sử dụng.");
                    break;
                case MembershipCreateStatus.InvalidUserName:
                    ltrCreateAccountError.Text = string.Format(ErrorBar, "Tên tài khoản không hợp lệ.");
                    break;
                case MembershipCreateStatus.DuplicateUserName:
                    ltrCreateAccountError.Text = string.Format(ErrorBar, "Tên tài khoản đã được sử dụng.");
                    break;
                case MembershipCreateStatus.InvalidAnswer:
                    ltrCreateAccountError.Text = string.Format(ErrorBar, "Câu trả lời không hợp lệ.");
                    break;
                case MembershipCreateStatus.InvalidEmail:
                    ltrCreateAccountError.Text = string.Format(ErrorBar, "Email không hợp lệ.");
                    break;
                case MembershipCreateStatus.InvalidPassword:
                    ltrCreateAccountError.Text = string.Format(ErrorBar, "Mật khẩu không hợp lệ.");
                    break;
                case MembershipCreateStatus.InvalidQuestion:
                    ltrCreateAccountError.Text = string.Format(ErrorBar, "Câu hỏi không hợp lệ.");
                    break;
                case MembershipCreateStatus.UserRejected:
                    ltrCreateAccountError.Text = string.Format(ErrorBar, "Tài khoản bị khước từ.");
                    break;
                default:
                    ltrCreateAccountError.Text = string.Format(ErrorBar, "Lỗi không xác định. Vui lòng thử lại.");
                    break;
            }

            if (success)
            {
                try
                {
                    Roles.AddUserToRole(newUser.UserName, "guest");
                    wzUserSignUp.ActiveStepIndex = 1;
                }
                catch (Exception)
                {
                    Membership.DeleteUser(newUser.UserName, true);
                    ltrCreateAccountError.Text = string.Format(ErrorBar, "Lỗi không xác định. Vui lòng thử lại.");
                }
            }
        }

        protected void Finish_Click(object sender, EventArgs args)
        {
            try
            {
                using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
                {
                    var newProfile = new Impl.Entity.UserProfile();
                    newProfile.ID = txtUsername.Text.Trim();
                    newProfile.Nickname = txtNickname.Text.Trim();
                    newProfile.Name = txtName.Text.Trim();
                    newProfile.Age = int.Parse(ddlAge.SelectedValue);
                    newProfile.Gender = Boolean.Parse(ddlGender.SelectedValue);
                    if (!txtLocation.Text.Trim().Equals(string.Empty))
                    {
                        newProfile.Location = txtLocation.Text.Trim();
                    }
                    if (!ddlCountry.SelectedValue.Equals(string.Empty))
                    {
                        newProfile.Country = ddlCountry.SelectedItem.Text;
                    }
                    newProfile.Email = txtEmail.Text.Trim();
                    if (!txtPhone.Text.Trim().Equals(string.Empty))
                    {
                        newProfile.Phone = txtPhone.Text.Trim();
                    }
                    newProfile.ShowEmail = chkShowEmail.Checked;
                    newProfile.ShowPhone = chkShowPhone.Checked;
                    newProfile.UpdatedOn = DateTime.Now;

                    ctx.UserProfileRespo.Setter.addOne(newProfile);

                    wzUserSignUp.ActiveStepIndex = 2;
                }
            }
            catch (Exception)
            {
                ltrInitInfoError.Text = string.Format(ErrorBar, "Không thể khởi tạo hồ sơ. Vui lòng thử lại.");
            }
        }
    }
}