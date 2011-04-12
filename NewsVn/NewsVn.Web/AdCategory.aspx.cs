using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsVn.Web
{
    public partial class AdCategory : BaseUI.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                load_SpecialAds();
                load_pletAdPosts();
            }
        }
        //load special ads (top payment rate)
        private void load_SpecialAds()
        {
            pletSpecialAds.Datasource = _AdPosts.Where(p => p.ExpiredOn >= DateTime.Now && p.AdCategory.Actived == true && p.Actived == true)
                .Select(p => new
                {
                    p.AdCategory.Name,
                    p.Title,
                    p.Content,
                    p.Payment,
                    Location = Utils.clsCommon.getLocationName(int.Parse(p.Location)),
                    p.CreatedBy,
                    p.CreatedOn
                }).OrderByDescending(p=>p.Payment).Take(5).ToList();
            pletSpecialAds.DataBind();
        }
        private void load_pletAdPosts()
        {
            int indexArea = 0;
            for (int i = 0; i < _AdCategories.Count(); i++)
            {
                var cate = _AdCategories.ElementAt(i);
                Control UC_PortletAdPost = LoadControl("~/Modules/AdPostsPortlet.ascx");
                var ctrPortletPost = ((Modules.AdPostsPortlet)UC_PortletAdPost);
                ctrPortletPost.Title = cate.Name;
                ctrPortletPost.SeoName = cate.SeoName;
                ctrPortletPost.SeoUrl = cate.SeoUrl;
                ctrPortletPost.indexCtrl = i.ToString();
                if (cate.Parent != null)
                {
                    continue;
                }
                //set position
                if (indexArea % 2 == 0)
                    ctrPortletPost.CssClass = "left";
                else
                {
                    ctrPortletPost.CssClass = "right";
                    ctrPortletPost.ClearLayout = true;
                }
                ctrPortletPost.Datasource = _AdPosts.Where(p => p.AdCategory.ID == cate.ID || (p.AdCategory.Parent != null && p.AdCategory.Parent.ID == cate.ID) && cate.Actived == true)
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
                //bind subCategory
                ctrPortletPost.subDatasource = _AdCategories.Where(p =>(p.Parent != null && p.Parent.ID == cate.ID) && cate.Actived == true)
                    .Select(p => new
                    {
                        p.ID,
                        p.Name,
                        p.SeoName,
                        p.SeoUrl,
                    }).ToList();
                //bind control
                ctrPortletPost.DataBind();
                AdPostArea.Controls.Add(ctrPortletPost);
                indexArea += 1;
            }
        }
    }
}