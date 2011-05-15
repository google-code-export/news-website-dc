using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsVn.Web
{
    public partial class PostSearchResult : BaseUI.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                return_SearchResults(Request.QueryString["keysearch"]);
            }
        }
        private void return_SearchResults(string keySearch)
        {
            var data = _Posts.Where(p => p.Title.ToLower().StartsWith(keySearch.ToLower()) && p.Actived == true)
                .Select(p => new { 
                p.Title,
                p.SeoUrl,
                p.Description,
                p.ApprovedOn,
                p.Avatar,
                Comments=p.PostComments.Count
                }).ToList();
            pletSearchResult.Datasource = data;
            pletSearchResult.ItemFounded = data.Count();
            pletSearchResult.keySearch = keySearch;
            pletSearchResult.DataBind();
        }
    }
}