using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Xml.Linq;
using NewsVn.Impl.Context;
using NewsVn.Web.Utils;
using System.Diagnostics;
//sql ADO
using System.Data;
using System.Data.SqlClient;
//
using System.Data.Common;



namespace NewsVn.Web
{
    public partial class Default : BaseUI.BasePage
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            SiteTitle += "Cổng thông tin điện tử 24/07 - tin tức online";
            MetaKeyWords = "newsvn,socl,homevn,Vietnam news daily,24/7,online,economic,internet,ads,education,rao vat,quang cao,tin hot,tu van,viec lam,works,tim ban,blog,tin tuc,sai gon,ha noi,da nang,du lich,dien anh";
            MetaKeyDes = "Newsvn, Cổng thông tin điện tử - thông tin nhanh, chính xác được đăng tải liên tục 24/07, thông tin Việt nam - Thế giới... Liên kết Socl, Homevn...";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
                {

                    List<int> lstArrayID = load_pletLatestNews(ctx);
                    load_pletHotNews(lstArrayID, ctx);
                    load_pletSpecialEvents();

                    load_pletPosts(ctx);

                    load_sideTabBar();
                    bindBannerRight(ctx);

                    //result: ~ 12 - 13s   
                }
            }
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

        private void load_sideTabBar()
        {
            //setting sau.
            //load ti gia
            //pletSideTabBar.Datasource = clsCurrency.Get_Currency_From_Bank("http://www.vietcombank.com.vn/ExchangeRates/ExrateXML.aspx");
            //load thoi tiet
            XElement element = XElement.Load(HttpContext.Current.Server.MapPath(@"~/Resources/Xml/category.xml"));
            var City = element.Element("Weather").Elements("City").Select(c => new
            {
                Name = c.Element("Name").Value,
                WOEID = c.Element("WOEID").Value
            }).ToList();
            pletSideTabBar.Datasource_Weather = City;
            pletSideTabBar.DataBind();
        }

        private int CountPostComments(Impl.Entity.Post post, NewsVnContext ctx)
        {
            int count = post.PostComments.Where(p => p.UpdatedOn <= DateTime.Now).Count();
            return count;
        }

        private void load_pletPosts(NewsVnContext ctx)
        {
            int indexArea = 0;
            //128 la ID game |GameCategoryID
            int GameID = int.Parse(System.Configuration.ConfigurationManager.AppSettings["GameCategoryID"].ToString());
            var _Categories = ctx.CategoryRepo.Getter.getQueryable(c => c.Actived == true && c.Type == "post"  && c.Parent == null).AsEnumerable();
            var _Posts = ctx.PostRepo.Getter.getQueryable(p => p.Actived == true && p.Approved == true)
                .OrderByDescending(p => p.ApprovedOn);
            //Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Start();

            EnumerableRowCollection<DataRow> rows = dtPost().AsEnumerable();

            for (int i = 0; i < _Categories.Count(); i++)
            {
                var cate = _Categories.ElementAt(i);

                if (cate.Parent != null)
                {
                    continue;
                }
                Control UC_PortletPost = LoadControl("~/Modules/PostsPortlet.ascx");
                var ctrPortletPost = ((Modules.PostsPortlet)UC_PortletPost);
                ctrPortletPost.Title = cate.Name;
                ctrPortletPost.SeoUrl = HostName + cate.SeoUrl;

                IList<PostT> dtQuery = rows.Where(p => p.Field<int>("CategoryID") == cate.ID || p.Field<int>("PARENTID") == cate.ID)
                   .Select(p => new PostT
                   {
                       ID = p.Field<int>("ID"),
                       Title = p.Field<string>("Title"),
                       Avatar = p.Field<string>("Avatar"),
                       Description = p.Field<string>("Description"),
                       SeoUrl = p.Field<string>("SeoUrl"),
                       AllowComments = p.Field<bool>("AllowComments"),
                       ApprovedOn = p.Field<DateTime>("ApprovedOn"),
                       Comments = p.Field<int>("Comments")
                   }).ToList();
                //load 1st news
                var first = dtQuery.Take(1).ToList();
                ctrPortletPost.oActivePost = first;
                //load 4th news
                ctrPortletPost.OtherPosts = dtQuery.Where(p => p.ID != first[0].ID).ToList();
                //set position
                if (indexArea % 2 == 0)
                    ctrPortletPost.CssClass = "left";
                else
                {
                    ctrPortletPost.CssClass = "right";
                    ctrPortletPost.ClearLayout = true;
                }

                ////bind control
                ctrPortletPost.DataBind();
                postArea.Controls.Add(ctrPortletPost);
                indexArea += 1;
            }
            //stopwatch.Stop();
            //var x = stopwatch.Elapsed.ToString();

            ////Bind Control Quang Cao
            var _AdPosts = ctx.AdPostRepo.Getter.getQueryable(adp => adp.Actived == true);
            Control UC_PortletPost_Ad = LoadControl("~/Modules/PostsPortlet.ascx");
            var ctrPortletPost_Ad = ((Modules.PostsPortlet)UC_PortletPost_Ad);
            ctrPortletPost_Ad.Title = "Rao Nhanh";
            ctrPortletPost_Ad.SeoUrl = HostName + "rao-nhanh.aspx";
            ctrPortletPost_Ad.CssClass = "right";
            ctrPortletPost_Ad.ClearLayout = true;
            ////bind control
            var IOrderQueryableData = _AdPosts//&& adp.ExpiredOn >= DateTime.Now //sau nay se set theo expired
                .Select(p => new PostT
                   {
                       ID =  p.ID,
                       Title = p.Title,
                       Avatar = p.Avatar.Length == 0 ? "/resources/Images/No_Image/no-ads.gif" : HostName + p.Avatar,
                       Description = p.Content,
                       SeoUrl = p.SeoUrl,
                       AllowComments =false,
                       ApprovedOn = p.CreatedOn,
                       Payment=p.Payment,
                       Comments = 0
                   }
                //.Select(adp => new PostT
                //{
                //    adp.ID,
                //    adp.Title,
                //    Description = adp.Content,// clsCommon.hintDesc(adp.Content),
                //    Avatar = adp.Avatar.Length == 0 ? "/resources/Images/No_Image/no-ads.gif" : HostName + adp.Avatar,
                //    adp.SeoUrl,
                //    ApprovedOn = adp.CreatedOn,
                //    AllowComments = false,
                //    adp.Payment,
                //    Comments = 0
                //}
                ).OrderByDescending(adp => adp.Payment).ThenByDescending(adp => adp.ApprovedOn).Take(5).ToList();
            var firstAd = IOrderQueryableData.Take(1).ToList();
            ctrPortletPost_Ad.oActivePost = firstAd;
            ctrPortletPost_Ad.OtherPosts = IOrderQueryableData.Where(p => p.ID != firstAd[0].ID).ToList();
            ctrPortletPost_Ad.DataBind();
            postArea.Controls.Add(ctrPortletPost_Ad);

        }

        //Hot News Tin noi bat
        void load_pletHotNews(List<int> lstArrayID, NewsVnContext ctx)
        {
            pletHotNews.CateTitle = "Tin Nổi Bật";
            var iPost = ctx.PostRepo.Getter.getQueryable(p => !lstArrayID.Contains(p.ID) && p.Approved == true);
            var oData = iPost.Select(p => new
            {
                p.Title,
                p.Description,// = clsCommon.hintDesc(p.Description),
                p.Avatar,
                SeoUrl = HostName + p.SeoUrl,
                p.ApprovedOn,
                p.PageView
            }).OrderByDescending(p => p.ApprovedOn).ThenByDescending(p => p.PageView).Take(5).ToList();
            pletHotNews.DataSource = oData;
            pletHotNews.DataBind();
        }

        //tin su kien
        void load_pletSpecialEvents()
        {
            pletSpecialEvents.DataSource = clsPost.Load_Post_From_XML(10);
            pletSpecialEvents.DataBind();
        }

        List<int> load_pletLatestNews(NewsVnContext ctx)
        {
            var oData = ctx.PostRepo.Getter.getQueryable(p => p.Actived == true && p.Approved == true).Select(p => new
            {
                p.ID,
                p.Title,
                p.ApprovedOn,
                p.SeoUrl,
                p.AllowComments,
                Cat_Name = p.Category.Parent != null ? p.Category.Parent.Name + ", " + p.Category.Name : p.Category.Name,
                Comments = CountPostComments(p, ctx)
            }).OrderByDescending(p => p.ApprovedOn).Take(7);

            pletLatestNews.DataSource = oData.ToList();
            pletLatestNews.HostName = HostName;
            pletLatestNews.DataBind();
            return oData.Select(p => p.ID).ToList();
        }

        private DataTable dtPost()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NewsVnMain"].ToString();

            // Specify the parameter value.
            DataTable dt = new DataTable();
            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();

                command.Connection = connection;
                command.CommandText = "SP_POST_SELECT_PORTLET_POST_BY_MENUID";
                command.CommandType = CommandType.StoredProcedure;
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
            return dt;
        }

    }
}