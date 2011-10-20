using System;

namespace NewsVn.Web.Account.SiteAdmin.Post
{
    public partial class ManageSpecialEventNews : BaseUI.SecuredPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = SiteTitle + "Quản lý sự kiện nổi bật";
        }
    }
}