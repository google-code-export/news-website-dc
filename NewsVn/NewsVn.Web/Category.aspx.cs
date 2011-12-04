using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using NewsVn.Impl.Context;
using NewsVn.Web.Utils;

namespace NewsVn.Web
{
    public partial class Category : BaseUI.BasePage
    {
        private int intCateID = -1;
        private string CateTitle = "Tin Nổi Bật";
        
        private bool checkCateID_By_SEONAME(string seoNAME, NewsVnContext ctx)
        {
            var _Categories = ctx.CategoryRepo.Getter.getQueryable(c => c.Actived == true);
            var cate = _Categories.Where(c => c.SeoName == seoNAME)
                .Select(c => new { c.ID, c.Name, c.Parent })
                .FirstOrDefault();

            if (cate != null)
            {
                intCateID = cate.ID;
                if (cate.Parent != null)
                {
                    this.CateTitle = cate.Parent.Name + " - " + cate.Name;
                }
                else
                {
                    this.CateTitle = cate.Name;
                }
                return true;
            }
            else
                return false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
                {
                    string strCateName = Request.QueryString["ct"]; //Context.Request.Url.Query;
                    bool realCate = checkCateID_By_SEONAME(strCateName, ctx);
                    this.ExecuteSEO(realCate ? CateTitle : "Cổng thông tin điện tử 24/07", "", "");
                    List<int> lstArrayID = load_pletLatestNews(ctx);
                    load_pletHotNews(lstArrayID, ctx);

                    DateTime searchDate = DateTime.Now;
                    int pageindex = 0;
                    int.TryParse(Request.QueryString["p"], out pageindex);
                    if (Request.QueryString["d"] != null && DateTime.TryParse(Request.QueryString["d"].Replace('_', '/').Trim(), out searchDate))
                    {
                        load_pletCatePostList(lstArrayID, pageindex, true, ctx);
                    }
                    else
                    {
                        load_pletCatePostList(lstArrayID, pageindex, false, ctx);
                    }
                    load_pletFocusPost(ctx);
                    bindBannerRight(ctx);
                }
            }
        }
        void bindBannerRight(NewsVnContext ctx)
        {
            var bannerRightListID = ctx.BannerDetailRepo.Getter.getQueryable(c => c.Activated && c.TypePosition == 2).Select(c => c.ID).ToArray();
            if (bannerRightListID.Length >= 1)
            {   //lay random 1 list right banner
                var lstID = new List<int>();
                for (int i = 0; i <= (bannerRightListID.Length < 5 ? bannerRightListID.Length - 1 : 5); i++)
                {
                    if (bannerRightListID.Length <= 5)
                    {
                        for (int j = 0; j <= bannerRightListID.Length - 1; j++)
                        {
                            lstID.Add(bannerRightListID[j]);
                        }
                        break;
                    }
                    var randon = new Random();
                    int _randomIndex = randon.Next(0, bannerRightListID.Length - 1);
                    if (!lstID.Contains(bannerRightListID[_randomIndex]))
                    {
                        lstID.Add(bannerRightListID[_randomIndex]);
                    }
                }
                Control UC_PortletAdPost = LoadControl("~/Modules/AdBoxList.ascx");
                var bannerRightLists = ctx.BannerDetailRepo.Getter.getQueryable(a => lstID.Contains(a.ID)).OrderByDescending(a => a.Price).ToList();
                var _AdBoxList1 = ((Modules.AdBoxList)UC_PortletAdPost);
                _AdBoxList1.Datasource = bannerRightLists;
                _AdBoxList1.DataBind();
                adboxArea.Controls.Add(_AdBoxList1);
            }
        }
        //lay tin tuc theo chu de
        private void load_pletCatePostList(List<int>lstArrayID, int pageindex, bool isSearchByDate, NewsVnContext ctx)
        {
            var _Posts = ctx.PostRepo.Getter.getQueryable(p => p.Actived == true && p.Approved == true);
            if (isSearchByDate)
            {
                DateTime searchdate = DateTime.Parse(Request.QueryString["d"].Replace('_', '/').Trim());
                //loc theo ngay, lay luon tin moi nhat (neu co)
                pletCatePostList.Datasource = _Posts.Where(p => p.ApprovedOn.Value.Day == searchdate.Day && p.ApprovedOn.Value.Month == searchdate.Month && p.ApprovedOn.Value.Year == searchdate.Year)
                     .Where(p => p.CategoryID == intCateID || (p.Category.Parent != null && p.Category.ParentID == intCateID))
                      .Select(p => new
                      {
                          p.ID,
                          p.Title,
                          p.Description,
                          p.Avatar,
                          p.SeoUrl,
                          p.ApprovedOn,
                          p.AllowComments,
                          Comments = p.PostComments.Count()
                      }).OrderByDescending(p => p.ApprovedOn).ToList();
            }
            else
            {
                pletCatePostList.Datasource = _Posts.Where(p => !lstArrayID.Contains(p.ID))
                     .Where(p => p.CategoryID == intCateID || (p.Category.Parent != null && p.Category.ParentID == intCateID))
                     .Select(p => new
                     {
                         p.ID,
                         p.Title,
                         p.Description,
                         p.Avatar,
                         p.SeoUrl,
                         p.ApprovedOn,
                         p.AllowComments,
                         Comments = p.PostComments.Count()
                     }).OrderByDescending(p => p.ApprovedOn).Skip(pageindex * 20).Take(20).ToList();
            }
            pletCatePostList.DataBind();
        }
        //lay tin_hot theo chu de  va theo pageview cao nhat trong ngay
        void load_pletHotNews(List<int> lstArrayID, NewsVnContext ctx)
        {
            var _Post = ctx.PostRepo.Getter.getQueryable(p => p.Actived == true && p.Approved == true);
            var iPost = _Post.Where(p => !lstArrayID.Contains(p.ID) && p.CategoryID == intCateID || (p.Category.Parent != null && p.Category.ParentID == intCateID));
            var oData = iPost.Select(p => new
            {
                p.Title,
                Description = clsCommon.hintDesc(p.Description, 300),
                p.Avatar,
                SeoUrl = HostName + p.SeoUrl,
                p.ApprovedOn,
                p.PageView
            }).OrderByDescending(p => p.ApprovedOn).ThenByDescending(p => p.PageView).Take(5).ToList();

            pletHotNews.CateTitle = CateTitle;
            pletHotNews.DataSource = oData;
            pletHotNews.DataBind();
        }
        //lay tin_moi_nhat theo chu de
        List<int> load_pletLatestNews(NewsVnContext ctx)
        {
            var _Posts = ctx.PostRepo.Getter.getQueryable(p => p.Actived == true && p.Approved == true);
            var oData = _Posts.Where(p => p.CategoryID == intCateID || (p.Category.Parent != null && p.Category.ParentID == intCateID)).Select(p => new
            {
                p.ID,
                p.Title,
                p.SeoUrl,
                p.ApprovedOn,
                p.AllowComments,
                Cat_Name = p.Category.Parent != null ? p.Category.Parent.Name + ", " + p.Category.Name : p.Category.Name,
                Comments = p.PostComments.Count()
            }).OrderByDescending(p => p.ApprovedOn).Take(7).ToList();
            pletLatestNews.DataSource = oData;
            pletLatestNews.HostName = HostName;
            pletLatestNews.DataBind();
            return oData.Select(p => p.ID).ToList();
        }
        //lay tieu_diem theo chu de, theo Month --> orderby Pageview, lay n record
        void load_pletFocusPost(NewsVnContext ctx)
        {
            var _Posts = ctx.PostRepo.Getter.getQueryable(p => p.Actived == true && p.Approved == true);
            var listData = _Posts.Where(p => p.CheckPageView == true && p.Category.ID == intCateID
                || (p.Category.Parent != null && p.Category.ParentID == intCateID))
                 .Where(p => p.ApprovedOn.Value.AddDays(30) >= DateTime.Now)
            .Select(p => new
            {
                p.ID,
                p.Title,
                p.Description,
                p.Avatar,
                p.SeoUrl,
                p.ApprovedOn,
                p.PageView
            }).OrderByDescending(p => p.PageView).Take(5).ToList();

            pletFocusPost.Datasource = listData;
            pletFocusPost.HostName = HostName;
            pletFocusPost.DataBind();
        }
    }
}