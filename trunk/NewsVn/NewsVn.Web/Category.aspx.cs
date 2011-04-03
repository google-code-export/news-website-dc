using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NewsVn.Web.Utils;

namespace NewsVn.Web
{
    public partial class Category : BaseUI.BasePage
    {
        private int intCateID = -1;
        private bool checkCateID_By_SEONAME(string seoNAME)
        {
            var cate=_Categories.Where(c => c.SeoName == seoNAME && c.Actived == true).Select(c => new { c.ID }).ToList();
            if (cate.Count() > 0)
            {
                intCateID = cate[0].ID;
                return true;
            }
            else
                return false;
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ct"] == null || !checkCateID_By_SEONAME(Request.QueryString["ct"].ToString()))
                {
                    Response.Redirect("Default.aspx");
                }
                load_pletHotNews();
                load_pletLatestNews();
                load_pletCatePostList();
                load_pletFocusPost();
            }
        }
        //lay tin tuc theo chu de
        private void load_pletCatePostList()
        {
            pletCatePostList.Datasource = _Posts.Where(p => p.Actived == true && p.Approved == true
                && p.CheckPageView == true && p.Category.ID == intCateID || (p.Category.Parent != null && p.Category.Parent.ID == intCateID)).Select(p => new
                {
                    p.ID,
                    p.Title,
                    p.Description,
                    p.Avatar,
                    p.SeoUrl,
                    p.ApprovedOn,
                    p.AllowComments,
                    Comments = p.PostComments.Count()
                }).OrderByDescending(p => p.ApprovedOn).Skip(7).Take(20).ToList();
            pletCatePostList.DataBind();
        }
        //lay tin_hot theo chu de
        void load_pletHotNews()
        {
            //Phan nay se load tu xml len// neu xml ko co/ tu dong lay duoi db len
            //var maxdate=_Posts.Where(p => p.Actived == true && p.Approved == true
            //    && p.CheckPageView == true).Select(p => new
            //    {
            //        ApprovedOn=p.ApprovedOn==null?DateTime.Now:p.ApprovedOn
            //    }).OrderByDescending(p => p.ApprovedOn).Take(1).ToList();
            //var listData= _Posts.Where(p => p.Actived == true && p.Approved == true
            //    && p.CheckPageView == true && p.ApprovedOn == maxdate[0].ApprovedOn).Select(p => new
            //    {
            //        p.ID,
            //        p.Title,
            //        p.Description,
            //        p.Avatar,
            //        p.SeoUrl,
            //        p.ApprovedOn,
            //        p.PageView
            //    }).OrderByDescending(p => p.PageView).Take(5).ToList();
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            ds.ReadXml(Server.MapPath(@"resources/Xml/TinMoiNong_Newsvn.xml").ToString());
            pletHotNews.DataSource = ds.Tables[0];
            //pletHotNews.DataSource = listData;
            pletHotNews.DataBind();
        }
        //lay tin_moi_nhat theo chu de
        void load_pletLatestNews()
        {
            //p.PostComments.Count
            pletLatestNews.DataSource = _Posts.Where(p => p.Actived == true && p.Approved == true
                && p.CheckPageView == true && p.Category.ID == intCateID || (p.Category.Parent != null && p.Category.Parent.ID == intCateID)).Select(p => new
                {
                    p.ID,
                    p.Title,
                    p.SeoUrl,
                    p.ApprovedOn,
                    p.AllowComments,
                    Cat_Name = p.Category.Name,
                    Comments = p.PostComments.Count()
                }).OrderByDescending(p => p.ApprovedOn).Take(7).ToList();
            pletLatestNews.DataBind();

        }
        //lay tieu_diem theo chu de, theo Month --> orderby Pageview, lay n record
        void load_pletFocusPost()
        {
            var listData = _Posts.Where(p => p.Actived == true && p.Approved == true
                && p.CheckPageView == true && p.ApprovedOn.Value.Month==DateTime.Now.Month
                && p.Category.ID == intCateID || (p.Category.Parent != null && p.Category.Parent.ID == intCateID)).Select(p => new
                {
                    p.ID,
                    p.Title,
                    p.Description,
                    p.Avatar,
                    p.SeoUrl,
                    p.ApprovedOn,
                    p.PageView
                }).OrderByDescending(p => p.PageView).Take(5).ToList();

            //var data = clsPost.Load_Post_From_XML("Focus",5);
            pletFocusPost.Datasource = listData;
            pletFocusPost.DataBind();
        }
    }
}