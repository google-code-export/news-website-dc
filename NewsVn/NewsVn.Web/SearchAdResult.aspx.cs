using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using NewsVn.Impl.Context;
using System.Globalization;

namespace NewsVn.Web
{
    public partial class SearchAdResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.LoadAdSearchResult();
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
    }
}