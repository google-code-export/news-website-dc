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
            /*DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Cat_Name", Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("Position", Type.GetType("System.String")));
            for (int i = 0; i < 10; i++)
            {
                DataRow row = dt.NewRow();
                if (i % 2 == 0)
                {
                    row["Cat_Name"] = i.ToString();
                    row["Position"] = "Left";
                }
                else
                {
                    row["Cat_Name"] = i.ToString();
                    row["Position"] = "Right";
                }
                dt.Rows.Add(row);
            }
            rptUCPortletPosts.DataSource = dt;
            rptUCPortletPosts.DataBind();*/

            //for (int i = 0; i < _Categories.Count(); i++)
            //{
            //    var cate = _Categories.ElementAt(i);

            //    var postPorlet = new Modules.PostsPortlet
            //    {
            //        Title = cate.Name,
            //        ActivePost = _Post.OrderByDescending(p => p.CreatedOn).ElementAt(0),
            //        OtherPosts = _Post.Where(p => p.Category.ID == cate.ID).Select(p => new
            //        {
            //            p.ID,
            //            p.Titlle,
            //            p.Description,
            //            p.Avatar,
            //            p.CreatedOn,
            //            Comments = p.PostComments.Count
            //        }).OrderByDescending(p => p.CreatedOn).Skip(1).Take(4).ToList()
            //    };

            //    if (i % 2 == 1)
            //    {
            //        postPorlet.CssClass = "right";
            //        postPorlet.ClearLayout = true;
            //    }
            //    else
            //    {
            //        postPorlet.CssClass = "left";
            //    }

            //    postPorlet.DataBind();

            //    Page.Controls.Add(postPorlet);
            //}

            //this.DataBind();
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
            //dt=dt.ReadXml()
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