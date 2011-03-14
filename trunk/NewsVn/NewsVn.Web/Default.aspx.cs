using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace NewsVn.Web
{
    public partial class Default : BaseUI.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            load_pletHotNews();
            load_pletSpecialEvents();
            load_pletLatestNews();
            load_pletPosts();
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
                if (cate.Parent != null)
                {
                    continue;
                }
                //load 1st news
                ctrPortletPost.oActivePost = _Post.Where(p => p.Category.ID == cate.ID  && cate.Actived==true)
                    .Select(p => new
                    {
                        p.ID,
                        p.Titlle,
                        p.Description,
                        p.Avatar,
                        p.CreatedOn,
                        Comments = p.PostComments.Count
                    }).OrderByDescending(p => p.CreatedOn).Take(1).ToList();
                //load 4th news
                ctrPortletPost.OtherPosts = _Post.Where(p => p.Category.ID == cate.ID  && cate.Actived==true).Select(p => new
                    {
                        p.ID,
                        p.Titlle,
                        p.Description,
                        p.Avatar,
                        p.CreatedOn,
                        Comments = p.PostComments.Count
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
        }
        void load_pletHotNews()
        {
            //Phan nay se load tu xml len// neu xml ko co/ tu dong lay duoi db len

            pletHotNews.DataSource = _Post.Where(p => p.Actived == true && p.Approved == true
                && p.CheckPageView == true).Select(p => new { 
                    p.ID, p.Titlle,
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
            pletSpecialEvents.DataSource = _Post.Where(p => p.Actived == true && p.Approved == true
                && p.CheckPageView == true).OrderByDescending(p => p.ApprovedOn).Take(5).ToList();
            pletSpecialEvents.DataBind();
        }
        void load_pletLatestNews()
        {
            pletLatestNews.DataSource = _Post.Where(p => p.Actived == true && p.Approved == true
                && p.CheckPageView == true).OrderByDescending(p => p.ApprovedOn).Take(5).ToList();
            pletLatestNews.DataBind();

        }
    }
}