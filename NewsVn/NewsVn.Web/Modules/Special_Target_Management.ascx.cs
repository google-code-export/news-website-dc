using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsVn.Web.Modules
{
    public class clsPost {
        public int PostID { get; set; }
        public string Title { get; set; }
        public string Avatar { get; set; }
        public string SeoUrl { get; set; }
        public DateTime ApprovedOn { get; set; }
    }
    public partial class Special_Target_Management : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Load_GridShow(drpCateoryType.SelectedItem.Value);
        }
        protected void Load_GridShow(string CategoryType)
        {
            grvShow.DataSource= Load_Post_From_XML(CategoryType);
            grvShow.DataBind();
        }
        protected List<clsPost> Load_Post_From_XML(string CategoryType)
        {
            XDocument xCategory = XDocument.Load(HttpContext.Current.Server.MapPath(@"~/Resources/Xml/category.xml"));
            var Categories = xCategory.Descendants("Category").Where(c => c.Attribute("Type").Value == CategoryType).Descendants("Post");
            return Categories.Select(p => new clsPost()
            {
                PostID = Convert.ToInt32(p.Attribute("ID").Value),
                Title = p.Element("Title").Value,
                Avatar = p.Element("Avatar").Value,
                SeoUrl = p.Element("SeoUrl").Value,
                ApprovedOn = DateTime.Now// Convert.ToDateTime(p.Attribute("ApprovedOn").Value)
            }).ToList();
        }

        protected void drpCateoryType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_GridShow(drpCateoryType.SelectedItem.Value);
        }
    }
}