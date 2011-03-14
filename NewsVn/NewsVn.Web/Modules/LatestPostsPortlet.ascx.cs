using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace NewsVn.Web.Modules
{
    public partial class LatestPostsPortlet : System.Web.UI.UserControl
    {
        public List<Data.Post> DataSource { get; set; }

        public string CssClass { get; set; }

        public bool ClearLayout { get; set; }

        protected override void OnLoad(EventArgs e)
        {
            if (!string.IsNullOrEmpty(CssClass))
            {
                container.CssClass += " " + CssClass;
            }

            if (ClearLayout)
            {
                var clearDiv = new HtmlGenericControl("div");
                clearDiv.Attributes.Add("class", "clear");
                this.Controls.Add(clearDiv);
            }
        }
        
        protected override void OnDataBinding(EventArgs e)
        {
            rptLatestNews.DataSource = DataSource;
            rptLatestNews.DataBind();
        }

       
    }
}