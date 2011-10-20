using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;
using NewsVn.Impl.Context;
using NewsVn.Web.Utils;

namespace NewsVn.Web.Modules
{
    public partial class SysAdmin_UpdateUser : BaseUI.SecuredModule
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.LoadRoleDropDown();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string generatedPassword = string.Empty;
            var newUser = this.AddNewUser(out generatedPassword);

            if (newUser != null)
            {
                this.UpdateMemberProfile(newUser, generatedPassword);
            }
        }

        private MembershipUser AddNewUser(out string generatedPassword)
        {
            var mcs = new MembershipCreateStatus();
            bool success = false;
            generatedPassword = Membership.GeneratePassword(20, 5);

            var newUser = Membership.CreateUser(txtUsername.Text.Trim(), generatedPassword,
                txtEmail.Text.Trim(), new Guid().ToString(), new Guid().ToString(), true, out mcs);

            switch (mcs)
            {
                case MembershipCreateStatus.Success:
                    success = true;
                    break;
                case MembershipCreateStatus.DuplicateEmail:
                    ltrError.Text = string.Format(ErrorBar, "Email đã được sử dụng.");
                    break;
                case MembershipCreateStatus.InvalidUserName:
                    ltrError.Text = string.Format(ErrorBar, "Tên tài khoản không hợp lệ.");
                    break;
                case MembershipCreateStatus.DuplicateUserName:
                    ltrError.Text = string.Format(ErrorBar, "Tên tài khoản đã được sử dụng.");
                    break;
                case MembershipCreateStatus.InvalidEmail:
                    ltrError.Text = string.Format(ErrorBar, "Email không hợp lệ.");
                    break;
                case MembershipCreateStatus.InvalidPassword:
                    ltrError.Text = string.Format(ErrorBar, "Mật khẩu không hợp lệ.");
                    break;
                case MembershipCreateStatus.UserRejected:
                    ltrError.Text = string.Format(ErrorBar, "Tài khoản bị khước từ.");
                    break;
                default:
                    ltrError.Text = string.Format(ErrorBar, "Lỗi không xác định. Vui lòng thử lại.");
                    break;
            }

            if (success)
            {
                try
                {
                    Roles.AddUserToRole(newUser.UserName, ddlRole.SelectedValue);
                    return newUser;
                }
                catch (Exception)
                {
                    Membership.DeleteUser(newUser.UserName, true);
                    ltrError.Text = string.Format(ErrorBar, "Không thể thêm mới tài khoản này!");
                    return null;
                }
            }
            return null;
        }

        private void UpdateMemberProfile(MembershipUser user, string generatedPassword)
        {
            try
            {
                using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
                {
                    var memberProfile = new Impl.Entity.MemberProfile
                    {
                        Account = user.UserName,
                        Name = txtName.Text.Trim(),
                        IdNumber = txtIdNumber.Text.Trim(),
                        Email = user.Email,
                        Gender = bool.Parse(rblGender.SelectedValue),
                        UpdatedOn = DateTime.Now,
                        UpdatedBy = HttpContext.Current.User.Identity.Name
                    };

                    if (!string.IsNullOrEmpty(txtPhone.Text.Trim()))
                    {
                        memberProfile.Phone = txtPhone.Text.Trim();
                    }
                    if (!string.IsNullOrEmpty(txtDOB.Text.Trim()))
                    {
                        memberProfile.DOB = DateTime.Parse(txtDOB.Text.Trim());
                    }
                    if (!string.IsNullOrEmpty(txtEducation.Text.Trim()))
                    {
                        memberProfile.Education = txtEducation.Text.Trim();
                    }
                    if (!string.IsNullOrEmpty(ddlLocation.SelectedValue))
                    {
                        memberProfile.Location = ddlLocation.SelectedValue;
                    }

                    ctx.MemberProfileRepo.Setter.addOne(memberProfile);
                    this.ClearUpdateForm();
                    var args = new Dictionary<string, string>();
                    args["newsvn.account.name"] = user.UserName;
                    args["newsvn.account.password"] = generatedPassword;
                    ApplicationMailing.Send(new string[] { user.Email }, ApplicationMailing.SendPurpose.CreateAccount, args);
                    ltrInfo.Text = string.Format(InfoBar, "Hoàn tất thêm mới tài khoản!");
                }
            }
            catch (Exception)
            {
                Membership.DeleteUser(user.UserName, true);
                ltrError.Text = string.Format(ErrorBar, "Không thể cập nhật thông tin tài khoản!");
            }
        }

        private void LoadRoleDropDown()
        {
            string[] excludedRoleNames = new string[] { "guest", "sysadmin" };
            
            foreach (var roleName in Roles.GetAllRoles())
            {
                if (!excludedRoleNames.Contains(roleName))
                {
                    ddlRole.Items.Add(new ListItem(this.getConfiguredRoleName(roleName), roleName));
                }
            }
        }

        private void ClearUpdateForm()
        {
            txtUsername.Text = string.Empty;
            txtEmail.Text = string.Empty;
            ddlRole.SelectedIndex = 0;
            txtName.Text = string.Empty;
            txtIdNumber.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtDOB.Text = string.Empty;
            rblGender.SelectedIndex = 0;
            ddlLocation.SelectedIndex = 0;
            txtEducation.Text = string.Empty;
        }

        private string getConfiguredRoleName(string roleName)
        {
            return ApplicationSettings.GetSettingValue("App.Security.Role", roleName);
        }
    }
}