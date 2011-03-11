using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsVn.Web
{
    public partial class Default : BaseUI.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pletHotNews.DataSource = _Post.Where(p => p.Actived == true && p.Approved == true
                && p.CheckPageView == true).OrderByDescending(p => p.ApprovedOn).Take(5).ToList();
            //thay .ToList() tren = doan code ben duoi , bi loi~, xem giup
                //.Select(p => new
                //{
                //    p.Titlle,
                //    p.Description,
                //    p.Avatar,
                //    p.ID,
                //    p.ApprovedOn
                //}).ToList();
            pletHotNews.DataBind();
        }
    }
}