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
        public string CateTitle = "";
        public object Datasource { get; set; }
        public string HostName { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime dt = DateTime.Now;
                if (Request.QueryString["d"] != null && DateTime.TryParse(Request.QueryString["d"].Replace('-','/'), out dt))
                {
                    txtGoldDate.Text = string.Format("{0:dd/MM/yyyy}", dt);
                }
                hidCt.Value = Request.QueryString["ct"];
                hidD.Value = Request.QueryString["d"] == null ? "" : Request.QueryString["d"].ToString().Replace('-', '/');
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
                hplnk.NavigateUrl =HostName+ DataBinder.Eval(e.Item.DataItem, "SeoUrl").ToString();
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
                Response.Redirect("rao-nhanh/" + Request.QueryString["ct"].Trim() + ".aspx");
            }
            else
            {
                Response.Redirect("rao-nhanh/" + Request.QueryString["ct"].Trim() + "/trang-" + page.ToString() + ".aspx");
            }
        }

        protected void lnkbtnNext_Click(object sender, EventArgs e)
        {
            int page = 0;
            int.TryParse(Request.QueryString["p"], out page);
            page += 1;
            if (page == 0)
            {
                Response.Redirect("rao-nhanh/" + Request.QueryString["ct"].Trim() + ".aspx");
            }
            else
            {
                Response.Redirect("rao-nhanh/" + Request.QueryString["ct"].Trim() + "/trang-" + page.ToString() + ".aspx");
            }
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("rao-nhanh/" + Request.QueryString["ct"] + "/{0}.aspx", txtGoldDate.Text.Trim().Replace('/','_')));
        }
        private void disabled_Control_DependOnPage()
        {
            int page = 0;
            int.TryParse(Request.QueryString["p"], out page);
            lnkbtnNext.Enabled = !(rptAdsList.Items.Count < 20);
            DateTime dt = DateTime.Now;
            lnkbtnPrevious.Enabled = !(page == 0);
            if (Request.QueryString["d"] != null && DateTime.TryParse(Request.QueryString["d"].Trim().Replace('_', '/'), out dt))
            {
                lnkbtnPrevious.Enabled = true;
            }
        }
    }
}