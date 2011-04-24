using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace NewsVn.Web.Modules
{
    public partial class AdPostsPortlet : System.Web.UI.UserControl
    {
        public string Title { get; set; }

        public string SeoName { get; set; }
        
        public string SeoUrl { get; set; }

        public string CssClass { get; set; }

        public bool ClearLayout { get; set; }

        public string indexCtrl { get; set; }

        public object Datasource { get; set; }
        public object subDatasource { get; set; }

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
            //load sub Categories Main >> Sub
            rptsubCategories.DataSource = subDatasource;
            rptsubCategories.DataBind();
            //load adPosts
            rptListAds.DataSource = Datasource;
            rptListAds.DataBind();
        }

        protected void rptListAds_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //handler free ads
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType==ListItemType.AlternatingItem)
            {
                HyperLink hplnk = (HyperLink)e.Item.FindControl("hplnk");
                hplnk.NavigateUrl = "../AdPost.aspx?cp="+ DataBinder.Eval(e.Item.DataItem, "ID").ToString();
                hplnk.Text = DataBinder.Eval(e.Item.DataItem, "Title").ToString();
                if (!Convert.ToBoolean(DataBinder.Eval(e.Item.DataItem, "isFree")))
                {
                    hplnk.Font.Bold = true;                    
                }
            }
            //handler empty value
            if (rptListAds.Items.Count <= 0)
            {
                if (e.Item.ItemType == ListItemType.Footer)
                {
                    Label lblFooter = (Label)e.Item.FindControl("lblEmpty");
                    lblFooter.Visible = true;
                }
            }
        }

    }
}