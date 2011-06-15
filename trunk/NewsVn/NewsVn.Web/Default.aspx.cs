using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NewsVn.Web.Utils;
using System.Xml;
using System.Xml.Linq;
using NewsVn.Impl.Context;

namespace NewsVn.Web
{
    public partial class Default : BaseUI.BasePage
    {
        //private static log4net.ILog  log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected override void OnInit(EventArgs e)
        {
            BaseUI.BaseMaster.SiteTitle = "- Cổng thông tin điện tử 24/07";
            BaseUI.BaseMaster.MetaKeyWords = "newsvn,Vietnam news daily,24/7,online,economic,internet,ads,education,rao vat,quang cao,tin hot,tu van,viec lam,works,tim ban,blog,tin tuc,sai gon,ha noi,da nang,du lich,dien anh";
            BaseUI.BaseMaster.MetaKeyDes = "Newsvn, Cổng thông tin điện tử - thông tin nhanh, chính xác được đăng tải liên tục 24/07, thông tin Việt nam - Thế giới...";
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<int> lstArrayID = load_pletLatestNews();
                load_pletSpecialEvents();
                load_pletHotNews(lstArrayID);
                load_pletPosts();
                load_sideTabBar();
            }
        }

        private void load_sideTabBar()
        {
            //setting sau.
            //load ti gia
            pletSideTabBar.Datasource = clsCurrency.Get_Currency_From_Bank("http://www.vietcombank.com.vn/ExchangeRates/ExrateXML.aspx");
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

        private void load_pletPosts()
        {

            int indexArea = 0;
            using (var ctx = new NewsVnContext(Utils.ApplicationManager.ConnectionString))
            {
                var _Categories = ctx.CategoryRespo.Getter.getQueryable(c => c.Actived == true && c.Type=="post").AsEnumerable();
                var _Posts = ctx.PostRespo.Getter.getQueryable(p => p.Actived == true);
                for (int i = 0; i < _Categories.Count(); i++)
                {
                    var cate = _Categories.ElementAt(i);
                    Control UC_PortletPost = LoadControl("~/Modules/PostsPortlet.ascx");
                    var ctrPortletPost = ((Modules.PostsPortlet)UC_PortletPost);
                    ctrPortletPost.Title = cate.Name;
                    ctrPortletPost.SeoUrl = HostName + cate.SeoUrl;
                    if (cate.Parent != null)
                    {
                        continue;
                    }
                    //load 1st news
                    var oActivePost = _Posts.Where(p => p.CategoryID == cate.ID || (p.Category.Parent != null && p.Category.ParentID == cate.ID) && cate.Actived == true)
                        .Select(p => new
                        {
                            p.ID,
                            p.Title,
                            p.Description,// = clsCommon.hintDesc(p.Description),
                            p.Avatar,
                            p.SeoUrl,
                            p.ApprovedOn,
                            p.AllowComments,
                            Comments = p.PostComments.Count
                        }).OrderByDescending(p => p.ApprovedOn);

                    ctrPortletPost.oActivePost = oActivePost.Take(1).ToList();
                    //load 4th news
                    ctrPortletPost.OtherPosts = oActivePost.Skip(1).Take(4).ToList();
                    //set position
                    if (indexArea % 2 == 0)
                        ctrPortletPost.CssClass = "left";
                    else
                    {
                        ctrPortletPost.CssClass = "right";
                        ctrPortletPost.ClearLayout = true;
                    }

                    //bind control
                    ctrPortletPost.DataBind();
                    postArea.Controls.Add(ctrPortletPost);
                    indexArea += 1;
                }
            }
            //Bind Control Quang Cao
            using (var ctx = new NewsVnContext(Utils.ApplicationManager.ConnectionString))
            {
                var _AdPosts = ctx.AdPostRespo.Getter.getQueryable(adp => adp.Actived == true);
                Control UC_PortletPost_Ad = LoadControl("~/Modules/PostsPortlet.ascx");
                var ctrPortletPost_Ad = ((Modules.PostsPortlet)UC_PortletPost_Ad);
                ctrPortletPost_Ad.Title = "Rao Nhanh";
                ctrPortletPost_Ad.SeoUrl = HostName + "rao-nhanh.aspx";
                ctrPortletPost_Ad.CssClass = "right";
                ctrPortletPost_Ad.ClearLayout = true;
                //bind control
                var IOrderQueryableData = _AdPosts//&& adp.ExpiredOn >= DateTime.Now //sau nay se set theo expired
                    .Select(adp => new
                    {
                        adp.ID,
                        adp.Title,
                        Description = adp.Content,// clsCommon.hintDesc(adp.Content),
                        Avatar = adp.Avatar.Length == 0 ? "/resources/Images/No_Image/no-ads.gif" : "/resources/Images/" + adp.Avatar,
                        adp.SeoUrl,
                        ApprovedOn = adp.CreatedOn,
                        AllowComments = false,
                        adp.Payment,
                        Comments = 0
                    }).OrderByDescending(adp => adp.Payment).ThenByDescending(adp => adp.ApprovedOn);
                ctrPortletPost_Ad.oActivePost = IOrderQueryableData.Take(1).ToList();
                ctrPortletPost_Ad.OtherPosts = IOrderQueryableData.Skip(1).Take(4).ToList();
                ctrPortletPost_Ad.DataBind();
                postArea.Controls.Add(ctrPortletPost_Ad);
            }
        }
        //Hot News Tin noi bat
        void load_pletHotNews(List<int> lstArrayID)
        {
            using (var ctx = new NewsVnContext(Utils.ApplicationManager.ConnectionString))
            {
                pletHotNews.CateTitle = "Tin Nổi Bật";
                var iPost = ctx.PostRespo.Getter.getQueryable(p => !lstArrayID.Contains(p.ID));
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
        }
        //tin su kien
        void load_pletSpecialEvents()
        {
            pletSpecialEvents.DataSource = clsPost.Load_Post_From_XML(10);
            pletSpecialEvents.DataBind();
        }
        List<int> load_pletLatestNews()
        {
            using (var ctx= new NewsVnContext(Utils.ApplicationManager.ConnectionString))
            {
                var oData =ctx.PostRespo.Getter.getQueryable(p => p.Actived == true && p.Approved == true).Select(p => new
                {
                    p.ID,
                    p.Title,
                    p.ApprovedOn,
                    p.SeoUrl,
                    p.AllowComments,
                    Cat_Name = p.Category.Parent != null ? p.Category.Parent.Name+ ", " + p.Category.Name : p.Category.Name,
                    Comments = p.PostComments.Count()
                }).OrderByDescending(p => p.ApprovedOn).Take(7).ToList();

                pletLatestNews.DataSource = oData;
                pletLatestNews.HostName = HostName;
                pletLatestNews.DataBind();
                return oData.Select(p => p.ID).ToList();
            }
            //return null;
        }
    }
}