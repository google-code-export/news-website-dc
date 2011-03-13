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
            DataTable dt = new DataTable();
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
            rptUCPortletPosts.DataBind();
        }
        void load_pletHotNews()
        {
            //Phan nay se load tu xml len// neu xml ko co/ tu dong lay duoi db len
            pletHotNews.DataSource = _Post.Where(p => p.Actived == true && p.Approved == true
                && p.CheckPageView == true).OrderByDescending(p => p.ApprovedOn).Take(5).ToList();
            //thay .ToList() tren = doan code ben duoi , bi loi~, xem giup
            //.Select(p => new
            //{
            //    p.Titlle,
            //    p.Description,
            //    p.Avatar,
            //    p.ID,
            //    p.ApprovedOn
            //}).ToList();
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