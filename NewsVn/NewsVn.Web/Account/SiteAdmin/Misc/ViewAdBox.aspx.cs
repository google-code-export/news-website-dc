using System;
using System.Linq;
using NewsVn.Impl.Context;
using NewsVn.Web.Utils;

namespace NewsVn.Web.Account.SiteAdmin.Misc
{
    public partial class ViewAdBox : BaseUI.SecuredPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack )
            {
                loadBannerPositionList();
                loadCurrentBannerList(); 
            }
        }
        protected void loadCurrentBannerList()
        {
            using (var ctx = new NewsVnContext(Utils.ApplicationManager.ConnectionString))
            {
                var BannerLists = ctx.BannerDetailRepo.Getter.getQueryable()
                .Select(c=>new{
                c.ID ,
                c.Height,
                c.Width,
                c.Title,
                c.Url,
                c.BannerID,
                BannerPosition= ApplicationKeyValueRef.GetKeyValue("Dropdown.BannerPosition",c.BannerID.ToString())
                }) ;
                
                rptCurrentBannerList.DataSource = BannerLists;
                rptCurrentBannerList.DataBind();
            }
        }

        protected void loadBannerPositionList()
        {
            using (var ctx = new NewsVnContext(Utils.ApplicationManager.ConnectionString))
            {
                var BannerPositionLists = ctx.BannerRepo.Getter.getQueryable() 
                    .Select(
                    c => new {
                    c.PositionID,
                    c.TypeID,
                    bannerPosition=  ApplicationKeyValueRef.GetKeyValue("Dropdown.BannerPosition",c.PositionID.ToString()),
                    bannerType = ApplicationKeyValueRef.GetKeyValue("Dropdown.BannerType", c.TypeID.ToString()),
                    }
                    );
                rptBannerPositon.DataSource = BannerPositionLists;
                rptBannerPositon.DataBind();
            }
        }
    }
}