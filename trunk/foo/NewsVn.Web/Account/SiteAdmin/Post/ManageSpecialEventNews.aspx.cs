using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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