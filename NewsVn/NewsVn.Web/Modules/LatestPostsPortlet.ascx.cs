﻿using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace NewsVn.Web.Modules
{
    public partial class LatestPostsPortlet : System.Web.UI.UserControl
    {
        //public List<Data.Post> DataSource { get; set; }
        public string HostName { get; set; }
        public object DataSource { get; set; }

        public bool NoComments { get; set; }                       

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

        protected void rptLatestNews_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item)
            { this.NoComments = Convert.ToBoolean(DataBinder.Eval(e.Item.DataItem, "AllowComments")); }
            
        }

       
    }
}