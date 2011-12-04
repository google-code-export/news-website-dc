using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using System.Web.UI.WebControls;
using NewsVn.Impl.Context;
using NewsVn.Web.Utils;
using System.Text;

namespace NewsVn.Web.Account.SiteAdmin.Guest
{
    public partial class ViewGuest : BaseUI.SecuredPage
    {
        const string OrderBySK = "siteadmin.guest.sort.orderBy";
        const string OrderColumnSK = "siteadmin.guest.sort.orderColumn";
        const string OrderDirectionSK = "siteadmin.guest.sort.orderDirection";

        public string OrderBy
        {
            get
            {
                if (Session[OrderBySK] != null)
                {
                    _orderBy = Session[OrderBySK] as string;
                }
                return _orderBy;
            }
            set
            {
                _orderBy = value;
                if (string.IsNullOrEmpty(_orderBy))
                {
                    Session.Remove(OrderBySK);
                }
                else
                {
                    Session[OrderBySK] = _orderBy;
                }
            }
        }
        private string _orderBy = string.Empty;

        protected string OrderColumn
        {
            get
            {
                if (Session[OrderColumnSK] != null)
                {
                    _orderColumn = Session[OrderColumnSK] as string;
                }
                return _orderColumn;
            }
            set
            {
                _orderColumn = value;
                if (string.IsNullOrEmpty(_orderColumn))
                {
                    Session.Remove(OrderColumnSK);
                }
                else
                {
                    Session[OrderColumnSK] = _orderColumn;
                }
            }
        }
        private string _orderColumn = string.Empty;

        protected string OrderDirection
        {
            get
            {
                if (Session[OrderDirectionSK] != null)
                {
                    _orderDirection = Session[OrderDirectionSK] as string;
                }
                return _orderDirection.ToLower();
            }
            set
            {
                _orderDirection = value;
                if (string.IsNullOrEmpty(_orderDirection))
                {
                    Session.Remove(OrderDirectionSK);
                }
                else
                {
                    Session[OrderDirectionSK] = _orderDirection;
                }
            }
        }
        private string _orderDirection = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            SiteTitle += "Quản lý tài khoản";

            if (!IsPostBack)
            {
                this.GoToFirstPage();
            }
        }

        protected void Sorter_SelectedIndexChanged(object sender, EventArgs e)
        {
            OrderColumn = ddlSortColumn.SelectedValue;
            OrderDirection = ddlSortDirection.SelectedValue;
            OrderBy = string.Format("{0} {1}", OrderColumn, OrderDirection);
            this.GoToCurrentPage();
        }

        protected void Pager_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GoToCurrentPage();
        }

        protected void btnClearSort_Click(object sender, EventArgs e)
        {
            OrderBy = string.Empty;
            OrderColumn = string.Empty;
            OrderDirection = string.Empty;

            ddlSortColumn.SelectedIndex = 0;
            ddlSortDirection.SelectedIndex = 0;

            this.GoToFirstPage();
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
                            var deleteComments = ctx.UserProfileCommentRepo.Getter.getQueryable
                                (c => c.ForAccount.Equals(user.UserName) || c.UpdatedBy.Equals(user.UserName));
                            var deletedProfile = ctx.UserProfileRepo.Getter.getOne(u => u.Account.Equals(user.UserName));
                            ctx.UserProfileCommentRepo.Setter.deleteMany(deleteComments);
                            ctx.UserProfileRepo.Setter.deleteOne(deletedProfile);
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

        private void GoToFirstPage()
        {
            int pageSize = int.Parse(ddlPageSize.SelectedValue);
            GoToPage(1, pageSize);
        }

        private void GoToPage(int pageIndex, int pageSize)
        {
            this.GenerateDataPager(pageSize);
            this.CheckSorting();
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
                    .Where(u => Roles.IsUserInRole(u.UserName, "guest"))
                    .Skip((pageIndex - 1) * pageSize).Take(pageSize);

                var profiles = ctx.UserProfileRepo.Getter
                    .getSortedList(ctx.UserProfileRepo.Getter.getQueryable(), OrderBy).AsEnumerable();

                rptUserList.DataSource = profiles.Join(users, p => p.Account, u => u.UserName, (p, u) => new
                {
                    p.Account,
                    p.Name,
                    p.Nickname,
                    NamedGender = ApplicationKeyValueRef.GetKeyValue("Dropdown.Gender", p.Gender.Value.ToString()),
                    p.Email,
                    p.UpdatedOn,
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

        private void CheckSorting()
        {
            btnClearSort.Visible = !string.IsNullOrEmpty(OrderBy);

            var sb = new StringBuilder();

            if (!string.IsNullOrEmpty(OrderBy))
            {
                sb.AppendFormat("Đang sắp xếp theo: <b>{0}</b>", ddlSortColumn.SelectedItem.Text);
                sb.AppendFormat(", chiều: <b>{0}</b>", ddlSortDirection.SelectedItem.Text);
            }

            string infoText = sb.ToString();

            if (!string.IsNullOrEmpty(infoText))
            {
                ltrInfo.Text = string.Format(InfoBar, infoText);
            }
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