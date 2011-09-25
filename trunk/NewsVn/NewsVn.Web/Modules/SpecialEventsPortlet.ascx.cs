using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace NewsVn.Web.Modules
{
    public partial class SpecialEventsPortlet : BaseUI.BaseModule
    {
        public string CssClass { get; set; }
        public bool ClearLayout { get; set; }
        public object DataSource { get; set; }

        public SpecialEventsPortlet()
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
            rptSpecialEvents.DataSource = DataSource;
            rptSpecialEvents.DataBind();

        }
    }
}