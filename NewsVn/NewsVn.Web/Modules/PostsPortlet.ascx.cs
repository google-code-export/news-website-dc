using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.Entity;
using NewsVn.Web.Utils;

namespace NewsVn.Web.Modules
{
    public partial class PostsPortlet :  BaseUI.BaseModule
    {
        public string Title { get; set; }

        public string SeoUrl { get; set; }

        public string CssClass { get; set; }

        public bool ClearLayout { get; set; }

        public bool NoComments { get; set; }                       

        public Data.Post ActivePost { get; set; }
        public object oActivePost { get; set; }

        public object OtherPosts { get; set; }

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
        public string fnHintDescription(object inputDesc)
        {
            return clsCommon.hintDesc(inputDesc.ToString(),200);
        }

        protected override void OnDataBinding(EventArgs e)
        {
            //load 1st news
            rptFirstItem.DataSource = oActivePost;
            rptFirstItem.DataBind();
            //load 4th news
            rptOtherItems.DataSource = OtherPosts;
            rptOtherItems.DataBind();
            //load 4th avatar
            rptSubAvatar.DataSource = OtherPosts;
            rptOtherItems.DataBind();
        }

        protected void rptFirstItem_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType==ListItemType.Item)
            {
                //load 1st avatar
                this.NoComments =Convert.ToBoolean( DataBinder.Eval(e.Item.DataItem, "AllowComments"));
                imgMain.ImageUrl = DataBinder.Eval(e.Item.DataItem, "Avatar").ToString();
                imgMain.AlternateText = DataBinder.Eval(e.Item.DataItem, "Title").ToString();
                imgMain.ToolTip = DataBinder.Eval(e.Item.DataItem, "Title").ToString();
            }
        }
    }
}