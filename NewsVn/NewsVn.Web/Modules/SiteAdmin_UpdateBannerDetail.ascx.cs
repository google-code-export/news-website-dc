using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewsVn.Impl.Context;
using NewsVn.Web.Utils;

namespace NewsVn.Web.Modules
{
    public partial class SiteAdmin_UpdateBannerDetail : BaseUI.SecuredModule
    {

        int intBannerId;
        protected void Page_Load(object sender, EventArgs e)
        {
            intBannerId = int.Parse(Request.QueryString["bannerid"]);
            if (!IsPostBack)
            {
                loadBannerDetail();
            }
        }

        private void loadBannerDetail()
        {
            using (var ctx = new NewsVnContext(Utils.ApplicationManager.ConnectionString))
            {
                var BannerDetail = ctx.BannerDetailRepo.Getter.getEnumerable(c => c.ID == intBannerId)
                .Select(c => new
                {
                    c.ID,
                    c.Height,
                    c.Width,
                    c.Title,
                    c.Url,
                    BannerPosition = ApplicationKeyValueRef.GetKeyValue("Dropdown.BannerPosition", c.BannerID.ToString())
                }).First();

                txtHeight.Text = BannerDetail.Height.ToString() ;
                txtWidth.Text = BannerDetail.Width.ToString ();
                txtPosition.Text = BannerDetail.BannerPosition;
                txtUrl.Text = BannerDetail.Url;
                txtTitle.Text = BannerDetail.Title;
                imgBanner.ImageUrl = BannerDetail.Url;
                imgBanner.DataBind();
            }
        }
    }
}