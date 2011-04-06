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

namespace NewsVn.Web
{
    public partial class Default : BaseUI.BasePage
    {
        protected override void OnInit(EventArgs e)
        {
            BaseUI.BaseMaster.SiteTitle = "- Báo điện tử 24/07";
            BaseUI.BaseMaster.MetaKeyWords = "NewsVn,Vietnam news daily,24/7,online,economic,internet,ads,education,rao vat,quang cao,tin hot,tu van,viec lam,works,tim ban,blog,tin tuc,sai gon,ha noi,da nang,du lich,dien anh";
            BaseUI.BaseMaster.MetaKeyDes = "Tờ báo điện tử - thông tin nhanh, chính xác được đăng tải liên tục 24/07 thông tin Việt nam - Thế giới về Kinh tế";
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                load_pletSpecialEvents();
                load_pletHotNews();
                load_pletLatestNews();
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
            for (int i = 0; i < _Categories.Count(); i++)
            {
                var cate = _Categories.ElementAt(i);
                Control UC_PortletPost = LoadControl("~/Modules/PostsPortlet.ascx");
                var ctrPortletPost = ((Modules.PostsPortlet)UC_PortletPost);
                ctrPortletPost.Title = cate.Name;
                ctrPortletPost.SeoName = cate.SeoName;
                if (cate.Parent != null)
                {
                    continue;
                }
                //load 1st news
                var oActivePost = _Posts.Where(p => p.Category.ID == cate.ID  || (p.Category.Parent != null && p.Category.Parent.ID == cate.ID) && cate.Actived == true)
                    .Select(p => new
                    {
                        p.ID,
                        p.Title,
                        p.Description,
                        p.Avatar,
                        p.SeoUrl,
                        p.CreatedOn,
                        p.AllowComments,
                        Comments = p.PostComments.Count
                    }).OrderByDescending(p => p.CreatedOn).Take(1).ToList();

                ctrPortletPost.oActivePost = oActivePost;
                //load 4th news
                ctrPortletPost.OtherPosts = _Posts.Where(p => p.Category.ID == cate.ID || (p.Category.Parent != null && p.Category.Parent.ID == cate.ID) && cate.Actived == true)
                    .Select(p => new
                    {
                        p.ID,
                        p.Title,
                        p.Description,
                        p.Avatar,
                        p.SeoUrl,
                        p.CreatedOn,
                        p.AllowComments,
                        Comments = p.PostComments.Count()
                    }).OrderByDescending(p => p.CreatedOn).Skip(1).Take(4).ToList();
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
            Control UC_PortletPost_Ad = LoadControl("~/Modules/PostsPortlet.ascx");
            var ctrPortletPost_Ad = ((Modules.PostsPortlet)UC_PortletPost_Ad);
            ctrPortletPost_Ad.Title = "Rao Nhanh";
            ctrPortletPost_Ad.SeoName = "../AdCategory.aspx";
            ctrPortletPost_Ad.CssClass = "right";
            ctrPortletPost_Ad.ClearLayout = true;
            //bind control
            ctrPortletPost_Ad.oActivePost = _AdPosts.Where(adp => adp.Actived == true && adp.ExpiredOn >= DateTime.Now)
                .Select(adp => new
                {
                    adp.ID,
                    adp.Title,
                    Description=adp.Content,
                    adp.Avatar,
                    adp.SeoUrl,
                    adp.CreatedOn,
                    AllowComments = false,
                    adp.Payment,
                    Comments = 0
                }).OrderByDescending(adp => adp.Payment).ThenByDescending(adp => adp.CreatedOn).Take(5).ToList();
                
            ctrPortletPost_Ad.DataBind();
            postArea.Controls.Add(ctrPortletPost_Ad);
        }
        void load_pletHotNews()
        {
            //Phan nay se load tu xml len// neu xml ko co/ tu dong lay duoi db len||
            pletHotNews.CateTitle = "Tin Nổi Bật";
            pletHotNews.DataSource = _Posts.Where(p => p.Actived == true && p.Approved == true).Select(p => new { 
                    p.ID, p.Title,
                    p.Description,
                    p.Avatar, 
                    p.SeoUrl,
                    p.ApprovedOn
           }).OrderByDescending(p => p.ApprovedOn).Take(5).ToList();

            //DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            ds.ReadXml(Server.MapPath(@"resources/Xml/TinMoiNong_Newsvn.xml").ToString());
            pletHotNews.DataSource = ds.Tables[0];
            pletHotNews.DataBind();
        }
        void load_pletSpecialEvents()
        {
            pletSpecialEvents.DataSource = clsPost.Load_Post_From_XML("Special", -1);
            pletSpecialEvents.DataBind();
        }
        void load_pletLatestNews()
        {
            pletLatestNews.DataSource = _Posts.Where(p => p.Actived == true && p.Approved == true).Select(p => new {
                    p.ID,
                    p.Title,
                    p.ApprovedOn,
                    p.SeoUrl,
                    p.AllowComments,
                    Cat_Name = p.Category.Parent != null ? p.Category.Parent.Name + ", " + p.Category.Name : p.Category.Name,
                    Comments = p.PostComments.Count()
                }).OrderByDescending(p => p.ApprovedOn).Take(7).ToList();
            pletLatestNews.DataBind();

        }
    }
}