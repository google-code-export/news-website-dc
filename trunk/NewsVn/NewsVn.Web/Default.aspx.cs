﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Xml.Linq;
using NewsVn.Impl.Context;
using NewsVn.Web.Utils;

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
                    //Stopwatch stopwatch = new Stopwatch();
                    //stopwatch.Start();
                    List<int> lstArrayID = load_pletLatestNews(ctx);
                    load_pletSpecialEvents();
                    load_pletHotNews(lstArrayID, ctx);
                    load_pletPosts(ctx);
                    load_sideTabBar();
                    bindBannerRight(ctx);
                    //stopwatch.Stop();
                    //BaseUI.BaseMaster.SiteTitle = stopwatch.Elapsed.ToString();
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

        private int CountPostComments(Impl.Entity.Post post, NewsVnContext ctx)
        {
            int count = post.PostComments.Where(p => p.UpdatedOn <= DateTime.Now).Count();
            return count;
        }

        private void load_pletPosts(NewsVnContext ctx)
        {
            int indexArea = 0;
            var _Categories = ctx.CategoryRepo.Getter.getQueryable(c => c.Actived == true && c.Type == "post").AsEnumerable();
            var _Posts = ctx.PostRepo.Getter.getQueryable(p => p.Actived == true);
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
                        Comments = CountPostComments(p, ctx)
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
            
            //Bind Control Quang Cao
            var _AdPosts = ctx.AdPostRepo.Getter.getQueryable(adp => adp.Actived == true);
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
                    Avatar = adp.Avatar.Length == 0 ? "/resources/Images/No_Image/no-ads.gif" : HostName + adp.Avatar,
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

        //Hot News Tin noi bat
        void load_pletHotNews(List<int> lstArrayID, NewsVnContext ctx)
        {
            pletHotNews.CateTitle = "Tin Nổi Bật";
            var iPost = ctx.PostRepo.Getter.getQueryable(p => !lstArrayID.Contains(p.ID));
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

            pletLatestNews.DataSource = oData;
            pletLatestNews.HostName = HostName;
            pletLatestNews.DataBind();
            return oData.Select(p => p.ID).ToList();
        }
    }
}