﻿using System;
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
            if (!IsPostBack)
            {
                DateTime dt = DateTime.Now;
                if (Request.QueryString["d"] != null && DateTime.TryParse(Request.QueryString["d"], out dt))
                {
                    txtGoldDate.Text = string.Format("{0:dd/MM/yyyy}", dt);
                }
                hidCt.Value = Request.QueryString["ct"];
                hidD.Value = Request.QueryString["d"];
                hidP.Value = Request.QueryString["p"];
                txtGoldDate.Attributes.Add("readOnly", "true");
                disabled_Control_DependOnPage();
            }
        }
        protected override void OnDataBinding(EventArgs e)
        {
            txtGoldDate.Text = string.Format("{0:dd/MM/yyyy}", DateTime.Now);    
            rptAdsList.DataSource = Datasource;
            rptAdsList.DataBind();
        }
        protected void rptAdsList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //handler free ads
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HyperLink hplnk = (HyperLink)e.Item.FindControl("hplnk");
                hplnk.NavigateUrl ="../AdPost.aspx?cp="+ DataBinder.Eval(e.Item.DataItem, "ID").ToString();
                hplnk.Text = DataBinder.Eval(e.Item.DataItem, "Title").ToString();
                if (!Convert.ToBoolean(DataBinder.Eval(e.Item.DataItem, "isFree")))
                {
                    hplnk.Font.Bold = true;
                }
            }
            //handler empty value
            if (rptAdsList.Items.Count <= 0)
            {
                if (e.Item.ItemType == ListItemType.Footer)
                {
                    Label lblFooter = (Label)e.Item.FindControl("lblEmpty");
                    lblFooter.Visible = true;
                }
            }
        }

        protected void lnkbtnPrevious_Click(object sender, EventArgs e)
        {
            int page = 0;
            int.TryParse(Request.QueryString["p"], out page);
            page -= 1;
            page = page <= 0 ? 0 : page;
            if (page == 0)
            {
                Response.Redirect("AdSubCategory.aspx?ct=" + Request.QueryString["ct"]);
            }
            else
            {
                Response.Redirect(string.Format("AdSubCategory.aspx?ct=" + Request.QueryString["ct"] + "&p={0}", page.ToString()));
            }
        }

        protected void lnkbtnNext_Click(object sender, EventArgs e)
        {
            int page = 0;
            int.TryParse(Request.QueryString["p"], out page);
            page += 1;
            if (page == 0)
            {
                Response.Redirect("AdSubCategory.aspx?ct=" + Request.QueryString["ct"]);
            }
            else
            {
                Response.Redirect(string.Format("AdSubCategory.aspx?ct=" + Request.QueryString["ct"] + "&p={0}", page.ToString()));
            }
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            string[] arrDateTime = txtGoldDate.Text.Split('/');
            Response.Redirect(string.Format("AdSubCategory.aspx?ct=" + Request.QueryString["ct"] + "&d={0}", arrDateTime[1] + "/" + arrDateTime[0] + "/" + arrDateTime[2]));
        }
        private void disabled_Control_DependOnPage()
        {
            int page = 0;
            int.TryParse(Request.QueryString["p"], out page);
            lnkbtnPrevious.Enabled = !(page == 0);
            lnkbtnNext.Enabled = !(rptAdsList.Items.Count < 20);
            DateTime dt = DateTime.Now;
            lnkbtnPrevious.Enabled = (page == 0 && rptAdsList.Items.Count < 20 && DateTime.TryParse(Request.QueryString["d"], out dt));
        }
    }
}