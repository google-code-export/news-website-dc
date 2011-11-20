using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using System.Web.UI.WebControls;
using NewsVn.Impl.Context;
using NewsVn.Web.Utils;

namespace NewsVn.Web.Account.SysAdmin.User
{
    public partial class ViewUser : BaseUI.SecuredPage
    {
        static string orderBy = string.Empty;

        static string _orderColumn = string.Empty;
        protected string OrderColumn
        {
            get { return _orderColumn; }
            set { _orderColumn = value; }
        }

        static string _orderDirection = string.Empty;
        protected string OrderDirection
        {
            get { return _orderDirection.ToLower(); }
            set { _orderDirection = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = this.SiteTitle + "Quản lý tài khoản";
            
            if (!IsPostBack)
            {
                this.GoToPage(1, int.Parse(ddlPageSize.SelectedValue));
            }
        }

        protected void Sorter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _orderColumn = ddlSortColumn.SelectedValue;
            _orderDirection = ddlSortDirection.SelectedValue;
            orderBy = string.Format("{0} {1}", _orderColumn, _orderDirection);
            this.GoToCurrentPage();
        }

        protected void Pager_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GoToCurrentPage();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
                {
                    var args = new Dictionary<string, string>();
                    foreach (var user in this.getSelectedUsers())
                    {
                        string email = user.Email;
                        args["newsvn.account.name"] = user.UserName;
                        if (Membership.DeleteUser(user.UserName))
                        {
                            var deletedProfile = ctx.MemberProfileRepo.Getter.getOne(u=>u.Account.Equals(user.UserName));
                            ctx.MemberProfileRepo.Setter.deleteOne(deletedProfile);
                            ApplicationMailing.Send(new string[] { email }, ApplicationMailing.SendPurpose.DeleteAccount, args);
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
                var args = new Dictionary<string, string>();
                foreach (var user in this.getSelectedUsers())
                {
                    user.IsApproved = !user.IsApproved;
                    Membership.UpdateUser(user);
                    args["newsvn.account.name"] = user.UserName;
                    args["newsvn.account.status"] = user.IsApproved ? "Kích hoạt" : "Vô hiệu";
                    ApplicationMailing.Send(new string[] { user.Email }, ApplicationMailing.SendPurpose.ChangeApproval, args);
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
                var args = new Dictionary<string, string>();
                foreach (var user in this.getSelectedUsers())
                {
                    args["newsvn.account.name"] = user.UserName;
                    args["newsvn.account.password"] = user.ResetPassword();
                    ApplicationMailing.Send(new string[] { user.Email }, ApplicationMailing.SendPurpose.ResetPassword, args);
                }
                ltrInfo.Text = string.Format(InfoBar, "Đặt lại mật khẩu cho tài khoản thành công! Mật khẩu mới đã được gởi đến email của tài khoản.");
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
                    .Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

                var profiles = ctx.MemberProfileRepo.Getter
                    .getSortedList(ctx.MemberProfileRepo.Getter.getQueryable(x => users.Select(y => y.UserName)
                    .ToList().Contains(x.Account)), orderBy).ToList();
                  
                rptUserList.DataSource = profiles.Join(users, p => p.Account, u => u.UserName, (p, u) => new
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
                rptUserList.DataBind();
            }
        }

        private void GenerateDataPager(int pageSize)
        {
            using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
            {
                var users = Membership.GetAllUsers().Cast<MembershipUser>()
                    .Where(u => !Roles.IsUserInRole(u.UserName, "guest") && !u.UserName.Equals(User.Identity.Name));

                if (users.Count() > 0)
                {
                    int numOfPages = (int)Math.Ceiling((decimal)users.Count() / pageSize);
                    ddlPageIndex.Items.Clear();
                    for (int i = 1; i <= numOfPages; i++)
                    {
                        ddlPageIndex.Items.Add(new ListItem(i.ToString(), i.ToString()));
                    }
                }
                else
                {
                    ddlPageIndex.Items.Add("1");
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