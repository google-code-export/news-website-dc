using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace NewsVn.Web.Modules
{
    public partial class SpecialPostsPortlet : BaseUI.BaseModule
    {
        public object DataSource { get; set; }
        
        public string CssClass { get; set; }
        
        public bool ClearLayout { get; set; }
        protected override void OnDataBinding(EventArgs e)
        {
            rptHotNews.DataSource = DataSource;
            rptHotNews.DataBind();
           
        }
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
    }
}