using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsVn.Web.Modules
{
    public partial class CategorizedAdPostList : System.Web.UI.UserControl
    {
        public  string CateTitle = "";
        public object Datasource { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected override void OnDataBinding(EventArgs e)
        {
            rptAdsList.DataSource = Datasource;
            rptAdsList.DataBind();
        }
        protected void rptAdsList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //handler free ads
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HyperLink hplnk = (HyperLink)e.Item.FindControl("hplnk");
                hplnk.NavigateUrl = DataBinder.Eval(e.Item.DataItem, "SeoUrl").ToString();
                hplnk.Text = DataBinder.Eval(e.Item.DataItem, "Title").ToString();
                if (!Convert.ToBoolean(DataBinder.Eval(e.Item.DataItem, "isFree")))
                {
                    hplnk.Font.Bold = true;
                }
            }
        }
    }
}