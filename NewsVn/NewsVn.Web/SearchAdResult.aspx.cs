using System;
using System.Globalization;
using System.Linq;
using NewsVn.Impl.Context;
using System.Collections.Generic;
using System.Web.UI;

namespace NewsVn.Web
{
    public partial class SearchAdResult : BaseUI.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.LoadAdSearchResult();
                bindBannerRight();
            }
        }

        private void LoadAdSearchResult()
        {
            try
            {

                string requestUrl = Request.QueryString["keysearch"];
                string [] searchArgs  = requestUrl.Split('-');

                string searchText = searchArgs[0];
                string location = searchArgs[1];
                string strDateFrom = searchArgs[2].Replace('_','/');
                string strDateTo = searchArgs[3].Replace('_', '/');
                strDateFrom = (strDateFrom != "") ? strDateFrom : "01/01/1970";
                strDateTo = (strDateTo != "") ? strDateTo : DateTime.Now.ToShortDateString();

                IFormatProvider format = new CultureInfo("vi-VN");


                DateTime fDate = DateTime.Parse(strDateFrom, format);

                DateTime tDate = DateTime.Parse(strDateTo, format);

                using (var ctx = new NewsVnContext(Utils.ApplicationManager.ConnectionString))
                {
                    var _Ads = ctx.AdPostRepo.Getter.getQueryable(a => a.Actived == true);
                    
                    if (location == "0")
                    {
                       var searchResult = _Ads.Where(a => a.TitleAscii.Contains(searchText) && a.CreatedOn >= fDate && a.CreatedOn <= tDate)
                         .Select(a => new
                         {
                             a.ID,
                             a.SeoUrl,
                             a.Title,
                             a.Content,
                             a.CreatedOn,
                             a.CreatedBy,
                             a.Location,
                             a.Avatar
                         }).OrderByDescending(a => a.CreatedOn).ThenByDescending(a => a.ID).ToList();
                       AdSearchResult1.DataSource = searchResult;
                    }
                    else
                    {
                        var searchResult = _Ads.Where(a => a.TitleAscii.Contains(searchText) && a.Location == location && a.CreatedOn >= fDate && a.CreatedOn <= tDate)
                         .Select(a => new
                         {
                             a.ID,
                             a.SeoUrl,
                             a.Title,
                             a.Content,
                             a.CreatedOn,
                             a.CreatedBy,
                             a.Location,
                             a.Avatar
                         }).OrderByDescending(a => a.CreatedOn).ThenByDescending(a => a.ID).ToList();
                        AdSearchResult1.DataSource = searchResult;
                    }
                    
                    AdSearchResult1.DataBind();
                }
            }
            catch 
            {
            }


        }
        void bindBannerRight()
        {
            using (var ctx = new NewsVnContext(Utils.ApplicationManager.ConnectionString))
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
        }
    }
}