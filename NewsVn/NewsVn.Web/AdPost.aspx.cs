using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsVn.Web
{
    public partial class AdPost : BaseUI.BasePage   
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int AdsID = 0;
                int.TryParse(Request.QueryString["cp"],out AdsID);
                load_pletAdsDetail(AdsID);
            }
        }
        //load Ads details by ID
        private void load_pletAdsDetail(int AdsID)
        {
            var data = _AdPosts.Where(p => p.ID ==AdsID && p.Actived == true && p.ExpiredOn >= DateTime.Now)
                    .Select(p => new
                    {
                        p.ID,
                        p.Title,
                        p.Content,
                        p.Avatar,
                        p.SeoUrl,
                        p.CreatedOn,
                        p.CreatedBy,
                        Location = Utils.clsCommon.getLocationName(int.Parse(p.Location))
                    }).FirstOrDefault();

            if (data != null)
            {
                pletAdsDetail.AdsTitle = data.Title;
                pletAdsDetail.AdsContent = data.Content;
                pletAdsDetail.CreatedBy = data.CreatedBy;
                pletAdsDetail.CreatedOn = data.CreatedOn;
                //Load Ads relation by Created Date and Difference with current ID
                load_pletAdsRelated(data.CreatedOn, AdsID);
            }
            else
            {
                pletAdsDetail.AdsTitle = "N/A";
                pletAdsDetail.AdsContent = "Không tìm thấy bài viết";
                pletAdsDetail.CreatedBy = "N/A";
                pletAdsDetail.CreatedOn = DateTime.Now;
            }
        }

        private void load_pletAdsRelated(DateTime CreatedOn, int AdsID)
        {
            var data = _AdPosts.Where(p => p.CreatedOn<=CreatedOn && p.ID !=AdsID && p.Actived == true && p.ExpiredOn >= DateTime.Now)
                    .Select(p => new
                    {
                        p.ID,
                        p.Title,
                        p.Content,
                        p.Avatar,
                        p.SeoUrl,
                        p.CreatedOn,
                        p.Payment,
                        p.CreatedBy,
                        Location = Utils.clsCommon.getLocationName(int.Parse(p.Location))
                    }).OrderByDescending(p=>p.Payment).ThenByDescending(p=>p.CreatedOn).Take(15).ToList();
            pletAdsRelated.Datasource = data;
            pletAdsRelated.DataBind();
        }
    }
}