using System;
using System.Web.UI.WebControls;

namespace NewsVn.Web.Modules
{
    public partial class RelatedAdPostList :BaseUI.BaseModule
    {
        public object Datasource { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected override void OnDataBinding(EventArgs e)
        {
            rptAdsRelated.DataSource = Datasource;
            rptAdsRelated.DataBind();
        }

        protected void rptAdsRelated_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //handler empty value
            if (rptAdsRelated.Items.Count <= 0)
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