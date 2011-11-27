using System;

namespace NewsVn.Web.Account.SiteAdmin.Post
{
    public partial class AddCategory : BaseUI.SecuredPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SiteTitle += "Thêm mới chủ đề tin tức";
        }
    }
}