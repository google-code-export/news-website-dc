using System;
using System.Linq;
using NewsVn.Impl.Context;
using NewsVn.Web.Utils;
namespace NewsVn.Web
{
    public partial class Profile : BaseUI.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
                {
                    string strAcc = Request.QueryString["acc"];
                    load_UserProfileDetailsByAccount(strAcc, ctx);
                    myProfileCommentBox.AccCommentedUser = strAcc;
                    myProfileCommentBox.DataBind();
                    load_UserConversation(strAcc, ctx);
                    myConversation.CurrentAccount = strAcc;
                    myConversation.DataBind();
                }
            }
        }

        private void load_UserProfileDetailsByAccount(string Account, NewsVnContext ctx)
        {
            var _UserProfiles = ctx.UserProfileRepo.Getter.getOne(u => u.Account == Account);

            if (_UserProfiles != null)
            {
                //var _UserProfiles = ctx.UserProfileRepo.Getter.getQueryable().Where(u=>u.Account=="1").ToList();
                myProfileCommentBox.UserNickName = _UserProfiles.Nickname;
                myProfileCommentBox.DataBind();
                pletUserProfileDetails.Datasource = _UserProfiles;
                pletUserProfileDetails.DataBind();
                this.ExecuteSEO("Thông tin hồ sơ " + Account, "newsvn, newsvn.vn, ket noi ban be, tim ban 4 phuong," + clsCommon.RemoveUnicodeMarks(_UserProfiles.Description).Replace('-', ' ') + " - " + clsCommon.RemoveUnicodeMarks(_UserProfiles.Expectation).Replace('-', ' '), Account + " - " + _UserProfiles.Description + " - " + _UserProfiles.Expectation);
                _UserProfiles = null;   
            }
            else
            {
                Response.Redirect(HostName);
            }
        }

        private void load_UserConversation(string Account, NewsVnContext ctx)
        {
            var _UserConversation = ctx.UserProfileCommentRepo.Getter.getQueryable(c => c.ForAccount == Account);

            var _conversationResult = _UserConversation.Select(p => new
            {
                p.ID,
                p.Title,
                p.Content,
                p.ForAccount,
                p.UpdatedBy,
                p.UpdatedOn,
                SenderAvatar = this.GetInfoByAccount(p.UpdatedBy, "avatar", ctx),
                SenderNickName = this.GetInfoByAccount(p.UpdatedBy, "nickname", ctx)
            }).OrderByDescending(p => p.ID).ToList();

            myConversation.DataSource = _conversationResult;
            myConversation.DataBind();
        }

        private string GetInfoByAccount(string Account, string returnValue, NewsVnContext ctx)
        {
            var _UserProfile = ctx.UserProfileRepo.Getter.getQueryable(c => c.Account == Account)
                    .Select(p => new
                    {
                        p.Nickname,
                        p.Avatar
                    }).FirstOrDefault();

            // CuongNguyen: Add 28/11/2011
            if (_UserProfile != null)
            {
                if (returnValue == "avatar")
                {
                    string abcd = _UserProfile.Avatar;
                    return _UserProfile.Avatar;
                }
                else
                {
                    string abcdef = _UserProfile.Nickname;
                    return _UserProfile.Nickname;
                }
            }

            // CuongNguyen: Add 28/11/2011
            return string.Empty;
        }
    }
}