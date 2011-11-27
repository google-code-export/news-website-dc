using System;

namespace NewsVn.Web.Account.SiteAdmin.Post
{
    public partial class AddPost : BaseUI.SecuredPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SiteTitle += "Thêm tin mới";
        }
    }
}