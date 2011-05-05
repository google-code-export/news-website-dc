using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsVn.Web
{
    public partial class AdSubCategory : BaseUI.BasePage
    {
        private int intCateID = -1;
        private string CateTitle = "Rao Nhanh";
        //check and set Ads CateID , Ads CateTitle
        private bool checkCateID_By_SEONAME(string seoNAME)
        {
            var cate = _AdCategories.Where(c => c.SeoName == seoNAME && c.Actived == true).Select(c => new { c.ID, c.Name }).ToList();
            if (cate.Count() > 0)
            {
                intCateID = cate[0].ID;
                this.CateTitle = cate[0].Name;
                return true;
            }
            else
                return false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                checkCateID_By_SEONAME(Request.QueryString["ct"].ToString());
                DateTime searchDate = DateTime.Now;
                int pageindex = 0;
                int.TryParse(Request.QueryString["p"], out pageindex);
                if (Request.QueryString["d"]!= null && DateTime.TryParse(Request.QueryString["d"].Replace('-','/'), out searchDate))
                {
                    load_pletAdsList(pageindex, true);
                }
                else
                {
                    load_pletAdsList(pageindex, false);
                }
            }
        }
        //Load List Ads by Ads Category
        private void load_pletAdsList(int pageindex, bool isSearchByDate)
        {
            if (isSearchByDate)
            {
                pletCatAdsPost.Datasource = _AdPosts.Where(p => p.AdCategory.ID == intCateID || (p.AdCategory.Parent != null && p.AdCategory.Parent.ID == intCateID) && p.Actived == true
                    ).Where(p => p.CreatedOn.ToShortDateString() == DateTime.Parse(Request.QueryString["d"].Replace('-','/')).ToShortDateString())
                    .Select(p => new
                    {
                        p.ID,
                        p.Title,
                        p.Content,
                        p.Avatar,
                        p.SeoUrl,
                        p.CreatedOn,
                        p.Payment,
                        isFree = p.Payment <= 0 ? true : false,
                        Location = Utils.clsCommon.getLocationName(int.Parse(p.Location))
                    }).OrderByDescending(p => p.Payment).ToList();
                pletCatAdsPost.CateTitle = CateTitle;//bind Ads CateTitle
                pletCatAdsPost.HostName = this.HostName;
            }
            else
            {
                pletCatAdsPost.Datasource = _AdPosts.Where(p => p.AdCategory.ID == intCateID || (p.AdCategory.Parent != null && p.AdCategory.Parent.ID == intCateID) && p.Actived == true)
                    .Select(p => new
                    {
                        p.ID,
                        p.Title,
                        p.Content,
                        p.Avatar,
                        p.SeoUrl,
                        p.CreatedOn,
                        p.Payment,
                        isFree = p.Payment <= 0 ? true : false,
                        Location = Utils.clsCommon.getLocationName(int.Parse(p.Location))
                    }).OrderByDescending(p => p.Payment).Skip(pageindex * 20).Take(20).ToList();
                pletCatAdsPost.CateTitle = CateTitle;//bind Ads CateTitle
                pletCatAdsPost.HostName = this.HostName;
            }
            pletCatAdsPost.DataBind();
            
        }
    }
}