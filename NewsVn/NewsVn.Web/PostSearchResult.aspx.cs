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
        protected override void OnInit(EventArgs e)
        {
            BaseUI.BaseMaster.SiteTitle = "- Tìm Kiếm";
            BaseUI.BaseMaster.MetaKeyWords = "newsvn,Vietnam news daily,24/7,online,economic,internet,ads,education,rao vat,quang cao,tin hot,tu van,viec lam,works,tim ban,blog,tin tuc,sai gon,ha noi,da nang,du lich,dien anh";
            BaseUI.BaseMaster.MetaKeyDes = "Newsvn,Tìm kiếm - Cổng thông tin điện tử - thông tin nhanh, chính xác được đăng tải liên tục 24/07, thông tin Việt nam - Thế giới...";
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                return_SearchResults(Request.QueryString["keysearch"]);
            }
        }
        private void return_SearchResults(string keySearch)
        {
            keySearch = Server.UrlDecode(keySearch);

            string first = keySearch.Substring(0, keySearch.IndexOf(' ') >= 1 ? keySearch.IndexOf(' ') : 1).Trim();
            //string rest = Server.UrlDecode(keySearch); //keySearch.Substring(keySearch.IndexOf(' '), keySearch.Length - keySearch.IndexOf(' ')).Trim();
            var data = _Posts.Where(p => p.Title.ToLower().StartsWith(first.ToLower()))
                .Select(p => new
                {
                    p.Title,
                    p.SeoUrl,
                    p.Description,
                    p.ApprovedOn,
                    p.Avatar,
                    Comments = p.PostComments.Count
                }).OrderByDescending(p=>p.Title).ThenByDescending(p=>p.ApprovedOn).ToList();

            pletSearchResult.Datasource = data;
            pletSearchResult.ItemFounded = data.Count();
            pletSearchResult.keySearch = keySearch;
            pletSearchResult.DataBind();
        }
    }
}