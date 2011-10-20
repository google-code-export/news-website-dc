using System;
using System.Web;
using NewsVn.Impl.Context;
using NewsVn.Web.Utils;

namespace NewsVn.Web.Modules
{
    public partial class ProfileCommentBox : BaseUI.BaseModule
    {

        public object Datasource { get; set; }

        public string  AccCommentedUser { get; set; }
        public string UserNickName { get; set; }

        protected static string _accCommentedUser;

        protected static string _accUserNickName;
               

        protected override void OnDataBinding(EventArgs e)
        {
            _accCommentedUser = AccCommentedUser;
            _accUserNickName = UserNickName;
        }

        private void AddNewProfileComment()
        {
            try
            {
                using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
                {
                    var profileComment = new Impl.Entity.UserProfileComment
                    {
                        Title = txtTitle.Text.Trim(),
                        UpdatedBy = HttpContext.Current.User.Identity.Name,
                        UpdatedOn = DateTime.Now,
                        ForAccount = _accCommentedUser,
                        Content = txtContent.Text.Trim()                      
                    };

                    ctx.UserProfileCommentRepo.Setter.addOne(profileComment);
                                        
                    ctx.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void btnAddComment_Click(object sender, EventArgs e)
        {
            AddNewProfileComment();
            Response.Redirect("tinh-yeu-gia-dinh/tim-ban/ho-so/" + _accCommentedUser + ".aspx");
        }
    }
}