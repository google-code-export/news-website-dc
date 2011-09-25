using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewsVn.Impl.Context;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Web.Configuration;
using NewsVn.Web.Utils;

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
           string rawkeySearch = keySearch;
           keySearch = Server.UrlDecode(keySearch);
           string keySearchAscii =  keySearch;

           if (keySearchAscii != null)
           {
               keySearchAscii = clsCommon.RemoveDangerousMarks(clsCommon.RemoveUnicodeMarks(keySearchAscii));
           }
                  //koha chinh sua ngay 21/08/2011
            using (var ctx =new NewsVnContext(Utils.ApplicationManager.ConnectionString))
            {
           //chua tim dc giai phap RemoveDangerousMarks(p.title) so sanh voi keysearch
                var _Posts = ctx.PostRepo.Getter.getQueryable(p => p.Actived == true && p.Approved == true);
                string first = keySearch.Substring(0, keySearch.IndexOf(' ') >= 1 ? keySearch.IndexOf(' ') : 1).Trim();
                //string rest = Server.UrlDecode(keySearch); //keySearch.Substring(keySearch.IndexOf(' '), keySearch.Length - keySearch.IndexOf(' ')).Trim();
               // Utils.clsCommon.RemoveDangerousMarks(txtSearch.Text.Trim())
                var data = _Posts.Where(p => p.TitleAscii.Contains(keySearchAscii))
                    .Select(p => new
                    {
                        p.Title,
                        SeoUrl=HostName+ p.SeoUrl,
                        p.Description,
                        p.ApprovedOn,
                        p.Avatar,
                        Comments = p.PostComments.Count
                    }).OrderByDescending(p => p.Title).ThenByDescending(p => p.ApprovedOn).ToList();

                pletSearchResult.Datasource = data;
                pletSearchResult.ItemFounded = data.Count();
                pletSearchResult.keySearch = keySearch ;
                pletSearchResult.DataBind();
            }
            //string strConn = WebConfigurationManager.ConnectionStrings["NewsVnMain"].ConnectionString;
            //sau nay cho vao cai webconfig | xai cay tren thi sua lai roi comment cai duoi lai cho tao 
            //using (SqlConnection conn = new SqlConnection("Data source=.\\SQLEXPRESS; Initial Catalog=NEWSVN; Persist Security Info=True;User ID=sa;Password=sa"))
            //using (SqlConnection conn = new SqlConnection(strConn))
            //{
            //    using (SqlCommand cmd = new SqlCommand())
            //    {
            //        StringBuilder sb = new StringBuilder();
            //        try
            //        {
            //            cmd.CommandText = "select titleascii, title,seourl,description,approvedon,avatar,(select count(id) from postcomments where postid=p.id) as Comments from Posts p where approved=1 and TitleAscii like @SearchText + '%' order by approvedon desc";
            //            cmd.Parameters.AddWithValue("@SearchText", keySearchAscii);
            //            cmd.Connection = conn;
            //            if (conn.State != ConnectionState.Open)
            //                conn.Open();
            //            SqlDataReader sdr = cmd.ExecuteReader();
            //            DataTable dt = new DataTable();
            //            dt.Load(sdr);
            //            pletSearchResult.Datasource = dt;
            //            pletSearchResult.ItemFounded = dt.Rows.Count;
            //            pletSearchResult.keySearch = keySearch;
            //            pletSearchResult.DataBind();
            //        }
            //        catch (Exception ex)
            //        {
            //            pletSearchResult.Datasource = null;
            //            pletSearchResult.ItemFounded =0;
            //            pletSearchResult.keySearch = keySearch;
            //            pletSearchResult.DataBind();
            //        }
            //        conn.Close();
            //    }
            //}
        }
    }
}