using System;

namespace NewsVn.Web.Account.SiteAdmin.AdPost
{
    public partial class AddCategory : BaseUI.SecuredPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SiteTitle += "Thêm mới chủ đề rao nhanh";
        }
    }
}