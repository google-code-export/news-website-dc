using System;
using System.Linq;
using NewsVn.Impl.Context;

namespace NewsVn.Web
{
    public partial class User : BaseUI.BaseMaster
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (var ctx = new NewsVnContext(Utils.ApplicationManager.ConnectionString))
                {
                    Load_DB_Data(ctx);
                    LoadTopBanner(ctx);
                }
            }
        }               

        private void Load_DB_Data(NewsVnContext ctx)
        {            
            var categories = Load_Menu(ctx);
            Load_FooterCate(categories);
        }

        private IQueryable<Impl.Entity.Category> Load_Menu(NewsVnContext ctx)
        {
            var CateList = ctx.CategoryRepo.Getter.getQueryable(c => c.Type == "post" && c.Actived == true);

            CtrMenu.Datasource = CateList;
            CtrMenu.DataBind();

            return CateList;
        }

        protected void Load_FooterCate(IQueryable<Impl.Entity.Category> categories)
        {
            var CateList = categories.Where(c => c.Parent == null)
                .Select(c => new
                {
                    c.Name,
                    c.SeoName,
                    SeoUrl = HostName + c.SeoUrl,
                    c.ID
                });
            CtrFooterCateList.Datasource = CateList;
            CtrFooterCateList.DataBind();
        }

        protected void LoadTopBanner(NewsVnContext ctx)
        {
            //lay random 1 top banner  | Typebanner = 1: top banner, 2: righ banner
            var bannerListID = ctx.BannerDetailRepo.Getter.getQueryable(c => c.Activated && c.TypePosition == 1).Select(c => c.ID).ToArray();
            if (bannerListID.Length >= 1)
            {   //lay random 1 list right banner
                var randon = new Random();
                int _randomIndex = randon.Next(0, bannerListID.Length);
                _randomIndex = bannerListID[_randomIndex];
                var BannerLists = ctx.BannerDetailRepo.Getter.getQueryable(a => a.ID == _randomIndex).ToList();
                BannerControlTop.Datasource = BannerLists;
                BannerControlTop.DataBind();
            }
        }

    }
}