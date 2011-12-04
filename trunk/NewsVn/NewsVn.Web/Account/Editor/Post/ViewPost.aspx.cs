using System;

namespace NewsVn.Web.Account.Editor.Post
{
    public partial class ViewPost : BaseUI.SecuredPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.SiteTitle += "Quản lý tin tức";
        }
    }
}