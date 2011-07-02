using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewsVn.Impl.Context;
using NewsVn.Web.Utils;

namespace NewsVn.Web.Account.SysAdmin.User
{
    public partial class ViewUser : BaseUI.SecuredPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = this.SiteTitle + "Quản lý tài khoản";
            
            if (!IsPostBack)
            {
                this.GoToPage(1, int.Parse(ddlPageSize.SelectedValue));
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
                {
                    foreach (var user in this.getSelectedUsers())
                    {
                        if (Membership.DeleteUser(user.UserName))
                        {
                            var deletedProfile = ctx.MemberProfileRepo.Getter.getOne(u=>u.Account.Equals(user.UserName));
                            ctx.MemberProfileRepo.Setter.deleteOne(deletedProfile);
                        }
                    }
                    ltrInfo.Text = string.Format(InfoBar, "Xóa tài khoản thành công!");
                }
            }
            catch (Exception)
            {
                ltrError.Text = string.Format(ErrorBar, "Không thể xóa tài khoản được chọn!");
            }

            this.GoToCurrentPage();
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var user in this.getSelectedUsers())
                {
                    user.IsApproved = !user.IsApproved;
                    Membership.UpdateUser(user);
                }
                ltrInfo.Text = string.Format(InfoBar, "Kích hoạt/Vô hiệu tài khoản thành công!");
            }
            catch (Exception)
            {
                ltrError.Text = string.Format(ErrorBar, "Không thể kích hoạt/vô hiệu tài khoản được chọn!");
            }

            this.GoToCurrentPage();
        }

        protected void btnResetPassword_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var user in this.getSelectedUsers())
                {
                    user.ResetPassword();
                }
                ltrInfo.Text = string.Format(InfoBar, "Đặt lại mật khẩu cho tài khoản thành công!");
            }
            catch (Exception)
            {
                ltrError.Text = string.Format(ErrorBar, "Không thể đặt lại mật khẩu cho tài khoản được chọn!");
            }

            this.GoToCurrentPage();
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.GoToCurrentPage();
        }

        private void GoToCurrentPage()
        {
            int pageIndex = int.Parse(ddlPageIndex.SelectedValue);
            int pageSize = int.Parse(ddlPageSize.SelectedValue);
            GoToPage(pageIndex, pageSize);
        }

        private void GoToPage(int pageIndex, int pageSize)
        {
            this.GenerateDataPager(pageSize);
            try
            {
                ddlPageSize.Text = pageSize.ToString();
                ddlPageIndex.Text = pageIndex.ToString();
            }
            catch (Exception)
            {
                ddlPageIndex.SelectedIndex = ddlPageIndex.Items.Count - 1;
                pageIndex = int.Parse(ddlPageIndex.SelectedValue);
            }
            this.LoadUserList(pageIndex, pageSize);
        }

        private void LoadUserList(int pageIndex, int pageSize)
        {
            using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
            {
                var users = Membership.GetAllUsers().Cast<MembershipUser>()
                    .Where(u => !Roles.IsUserInRole(u.UserName, "guest") && !Roles.IsUserInRole(u.UserName, "sysadmin"))
                    .Skip((pageIndex - 1) * pageSize).Take(pageSize);
                var profiles = ctx.MemberProfileRepo.Getter.getEnumerable()
                    .Join(users, p => p.Account, u => u.UserName, (p, u) => new
                    {
                        p.Account,
                        p.Name,
                        p.IdNumber,
                        p.Email,
                        p.UpdatedOn,
                        p.UpdatedBy,
                        RoleName = this.getConfiguredRoleNames(p.Account),
                        Approved = u.IsApproved,
                        Status = u.IsOnline ? "Online" : "Offline"
                    });
                rptUserList.DataSource = profiles;
                rptUserList.DataBind();
            }
        }

        private void GenerateDataPager(int pageSize)
        {
            using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
            {
                var users = Membership.GetAllUsers().Cast<MembershipUser>()
                    .Where(u => !Roles.IsUserInRole(u.UserName, "guest") && !u.UserName.Equals(User.Identity.Name));
                int numOfPages = (int)Math.Ceiling((decimal)users.Count() / pageSize);
                ddlPageIndex.Items.Clear();
                for (int i = 1; i <= numOfPages; i++)
                {
                    ddlPageIndex.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }
            }
        }

        private string getConfiguredRoleNames(string userName)
        {
            string roleNames = string.Empty;
            string[] roles = Roles.GetRolesForUser(userName);

            for (int i = 0; i < roles.Length; i++)
            {
                roleNames += ApplicationSettings.GetSettingValue("App.Security.Role", roles[i]) + ";";
            }
            return roleNames;
        }

        private IEnumerable<MembershipUser> getSelectedUsers()
        {
            var selectedUserNames = new List<string>();

            foreach (RepeaterItem item in rptUserList.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    CheckBox chkAccount = item.FindControl("chkAccount") as CheckBox;

                    if (chkAccount.Checked)
                    {
                        HiddenField hidAccount = item.FindControl("hidAccount") as HiddenField;
                        selectedUserNames.Add(hidAccount.Value);
                    }
                }
            }

            return Membership.GetAllUsers().Cast<MembershipUser>().Where(u => selectedUserNames.Contains(u.UserName));
        }
    }
}