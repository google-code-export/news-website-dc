using System;
using System.Linq;
using System.Web.UI;
using NewsVn.Impl.Context;

namespace NewsVn.Web
{
    public partial class User : BaseUI.BaseMaster
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Fix: thay <%= %> bang <%# %> sau do dung  Page.Header.DataBind();
                //Error: The Controls collection cannot be modified because the control contains code blocks (i.e. <% ... %>).
                Page.Header.DataBind();
                //Error--------------
                Generate_SeoMeta();
                Load_DB_Data();
                LoadTopBanner();
            }
        }
        
        public void Generate_SeoMeta()
        {
            Page.Header.Controls.Add(new LiteralControl("\n"));
            System.Web.UI.HtmlControls.HtmlMeta metaKeyWords = new System.Web.UI.HtmlControls.HtmlMeta();
            metaKeyWords.Name="Keywords";
            metaKeyWords.Content = MetaKeyWords;

            System.Web.UI.HtmlControls.HtmlMeta metaKeyDescription = new System.Web.UI.HtmlControls.HtmlMeta();
            metaKeyDescription.Name = "Description";
            metaKeyDescription.Content =  MetaKeyDes;

            Page.Header.Controls.Add(metaKeyWords);
            Page.Header.Controls.Add(new LiteralControl("\n"));
            Page.Header.Controls.Add(metaKeyDescription);

        }

        private void Load_DB_Data()
        {
            using (var ctx = new NewsVnContext(Utils.ApplicationManager.ConnectionString))
            {
                var categories = Load_Menu(ctx);
                Load_FooterCate(categories);
            }
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

        protected void LoadTopBanner()
        {
            using (var ctx = new NewsVnContext(Utils.ApplicationManager.ConnectionString))
            {
                int BannerPosition = BannerControlTop.BannerPosition;  
                int BannerType = BannerControlTop.BannerType;
                int RepeatDirection = BannerControlTop.RepeatDirection;
                int TopBannerId = ctx.BannerRepo.Getter.getOne(b => b.PositionID == BannerPosition && b.TypeID == BannerType).ID;
                var BannerLists = ctx.BannerDetailRepo.Getter.getQueryable(a=> a.BannerID ==TopBannerId).Select (c=> new
                {
                  c.ID,
                  c.Title,
                  c.Width,
                  c.Height,
                  c.Url,
                  bnDirection = RepeatDirection
                }).ToList();

                
                BannerControlTop.Datasource = BannerLists;
                BannerControlTop.DataBind();
            }

        }

    }
}