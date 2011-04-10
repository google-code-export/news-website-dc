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
                if (Request.QueryString["ct"] == null || !checkCateID_By_SEONAME(Request.QueryString["ct"].ToString()))
                {
                    //handler 404 error (page)
                    Response.Redirect("Default.aspx");
                }
                load_pletAdsList();
            }
        }
        //Load List Ads by Ads Category
        private void load_pletAdsList()
        {
            pletCatAdsPost.Datasource = _AdPosts.Where(p =>p.AdCategory.ID == intCateID || (p.AdCategory.Parent != null && p.AdCategory.Parent.ID == intCateID) && p.Actived == true)
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
                    }).OrderByDescending(p => p.Payment).Take(20).ToList();
            pletCatAdsPost.CateTitle = CateTitle;//bind Ads CateTitle
            pletCatAdsPost.DataBind();
            
        }
    }
}