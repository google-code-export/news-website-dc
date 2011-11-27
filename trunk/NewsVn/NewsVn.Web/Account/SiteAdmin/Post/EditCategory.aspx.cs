using System;

namespace NewsVn.Web.Account.SiteAdmin.Post
{
    public partial class EditCategory : BaseUI.SecuredPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SiteTitle += "Sửa thông tin chủ đề tin tức";
        }
    }
}