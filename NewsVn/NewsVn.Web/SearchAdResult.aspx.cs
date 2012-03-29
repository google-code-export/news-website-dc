using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.UI;
using NewsVn.Impl.Context;
using System.Data.SqlClient;
using System.Data;

namespace NewsVn.Web
{
    public partial class SearchAdResult : BaseUI.BasePage
    {
        private string strConnection { get; set; }
        private string connection { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (var ctx = new NewsVnContext(Utils.ApplicationManager.ConnectionString))
                {
                    SiteTitle += "Kết quả tìm kiếm";
                    this.LoadAdSearchResult(ctx);
                    bindBannerRight(ctx);
                }
            }
        }

        private void LoadAdSearchResult(NewsVnContext ctx)
        {
            string requestUrl = Request.QueryString["keysearch"];
            string[] searchArgs = requestUrl.Split('-');

            string searchText = searchArgs[0];
            string location = searchArgs[1];
            double numberofDays = 0;

            string strDateTo = searchArgs[2];
            double.TryParse(strDateTo, out numberofDays);
            DateTime searchDate = DateTime.Now.AddDays(-numberofDays);
            //neu ngay chi co ngay bat dau -> lay ngay bat dau >= fDate
            //neu chi co ngay ket thuc -> lay ngay theo ngay ket thuc <=fDate

            //var _Ads = ctx.AdPostRepo.Getter.getQueryable(a => a.Actived == true);
            //if (location == "0")
            //{
            //    var searchResult = _Ads.Where(a => a.Title.Contains( searchText ) && (a.CreatedOn >= searchDate))
            //      .Select(a => new
            //      {
            //          a.ID,
            //          a.SeoUrl,
            //          a.Title,
            //          a.Content,
            //          a.CreatedOn,
            //          a.CreatedBy,
            //          a.Location,
            //          a.Avatar
            //      }).OrderByDescending(a => a.CreatedOn).ThenByDescending(a => a.ID).ToList();
            //    AdSearchResult1.DataSource = searchResult;
            //}
            //else {
            //    var searchResult = _Ads.Where(a => a.Title.Contains("%" + searchText + "%") && (a.Location == location) && (a.CreatedOn >= searchDate))
            //          .Select(a => new
            //          {
            //              a.ID,
            //              a.SeoUrl,
            //              a.Title,
            //              a.Content,
            //              a.CreatedOn,
            //              a.CreatedBy,
            //              a.Location,
            //              a.Avatar
            //          }).OrderByDescending(a => a.CreatedOn).ThenByDescending(a => a.ID).ToList();
            //    AdSearchResult1.DataSource = searchResult;
            //}

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NewsVnMain"].ToString();

            // Specify the parameter value.
            int paramLocation = 0;
            int.TryParse(location, out paramLocation);
            string paramTitle = searchText;
            DateTime paramCreated = searchDate;
            DataTable dt = new DataTable();
            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
               
                command.Connection = connection;
                command.CommandText = "sp_AdPost_Search";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@title", paramTitle);
                command.Parameters.AddWithValue("@titleAsii", Utils.clsCommon.RemoveDangerousMarks(paramTitle));
                if (paramLocation != 0)
                {
                    command.Parameters.AddWithValue("@location", paramLocation);
                }
                else
                    command.Parameters.AddWithValue("@location", DBNull.Value);

                command.Parameters.AddWithValue("@created", paramCreated);
                
                
                SqlDataAdapter adt = new SqlDataAdapter(command);
                try
                {
                    connection.Open();
                    adt.SelectCommand = command;
                    adt.Fill(dt);
                }
                catch (Exception ex)
                {
                }
            }

            AdSearchResult1.DataSource = dt;
            AdSearchResult1.DataBind();
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
    }
}