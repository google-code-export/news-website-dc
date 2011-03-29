using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsVn.Web.Modules
{
    public partial class CategorizedPostList : System.Web.UI.UserControl
    {
       // public IQueryable<Data.Post> Datasource { get; set; }
        public object Datasource { get; set; }
        protected override void OnDataBinding(EventArgs e)
        {
            rptCatePostList.DataSource = Datasource;
            rptCatePostList.DataBind();
        }

        protected void rptCatePostList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (rptCatePostList.Items.Count<=0)
            {
                if (e.Item.ItemType==ListItemType.Footer)
                {
                    Label lblFooter = (Label)e.Item.FindControl("lblEmpty");
                    lblFooter.Visible = true;
                }
               
            }
        }
    }
}