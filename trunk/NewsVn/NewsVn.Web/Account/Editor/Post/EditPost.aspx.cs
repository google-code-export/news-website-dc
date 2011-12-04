using System;

namespace NewsVn.Web.Account.Editor.Post
{
    public partial class EditPost : BaseUI.SecuredPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SiteTitle += "Sửa thông tin bài viết";
        }
    }
}