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
            try
            {
            if (!IsPostBack)
            {
                string strAcc = Request.QueryString["acc"];
                load_UserProfileDetailsByAccount(strAcc);
                myProfileCommentBox.AccCommentedUser = strAcc;
                myProfileCommentBox.DataBind();
                load_UserConversation(strAcc);
                myConversation.CurrentAccount = strAcc;
                myConversation.DataBind();
            }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void load_UserProfileDetailsByAccount(string Account)
        {
            try
            {
            using (var ctx=new NewsVnContext(ApplicationManager.ConnectionString))
            {
                var _UserProfiles = ctx.UserProfileRepo.Getter.getOne(u => u.Account==Account);
               //var _UserProfiles = ctx.UserProfileRepo.Getter.getQueryable().Where(u=>u.Account=="1").ToList();
                myProfileCommentBox.UserNickName = _UserProfiles.Nickname;
                myProfileCommentBox.DataBind();
                pletUserProfileDetails.Datasource = _UserProfiles;
                pletUserProfileDetails.DataBind();
                BaseUI.BaseMaster.ExecuteSEO("Thông tin hồ sơ " + Account, "newsvn, newsvn.vn, ket noi ban be, tim ban 4 phuong," + clsCommon.RemoveUnicodeMarks(_UserProfiles.Description).Replace('-', ' ') + " - " + clsCommon.RemoveUnicodeMarks(_UserProfiles.Expectation).Replace('-', ' '), Account + " - " + _UserProfiles.Description + " - " + _UserProfiles.Expectation);
                _UserProfiles = null;

            }
            }
            catch (Exception ex)
            {
                var e = ex.Message.ToString();  
            }
        }

        private void load_UserConversation(string Account)
        {
            using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
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
                        SenderAvatar = this.GetInfoByAccount(p.UpdatedBy,"avatar"),
                        SenderNickName = this.GetInfoByAccount(p.UpdatedBy, "nickname")  
                    }).OrderByDescending(p => p.ID).ToList();

                myConversation.DataSource = _conversationResult;
                myConversation.DataBind();

            }
        }

        private string GetInfoByAccount(string Account, string returnValue)
        {
            try
            {
            using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
            {
                var _UserProfile = ctx.UserProfileRepo.Getter.getQueryable(c => c.Account==Account )
                    .Select(p => new
                    {
                        p.Nickname,
                        p.Avatar 
                    }).FirstOrDefault();

                if (returnValue == "avatar")
                {
                    string abcd = _UserProfile.Avatar;
                    return _UserProfile.Avatar;
                }
                else
                {
                    string abcdef = _UserProfile.Nickname ;
                    return _UserProfile.Nickname; 
                }
            }
            }
            catch (Exception)
            {

                return "";
            }

        }
    }
}