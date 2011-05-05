using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsVn.Web.Modules
{
    public partial class CategorizedPostList : BaseUI.BaseModule
    {
       // public IQueryable<Data.Post> Datasource { get; set; }
        public object Datasource { get; set; }
        public IQueryable<Data.Post> IDatasource { get; set; }
        public bool NoComments { get; set; }      

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime dt = DateTime.Now;
                if (Request.QueryString["d"]!=null && DateTime.TryParse(Request.QueryString["d"],out dt))
                {
                    txtGoldDate.Text = string.Format("{0:dd/MM/yyyy}", dt);
                }
                txtGoldDate.Attributes.Add("readOnly", "true");
               // disabled_Control_DependOnPage();
            }
        }

        protected override void OnDataBinding(EventArgs e)
        {
            txtGoldDate.Text = string.Format("{0:dd/MM/yyyy}", DateTime.Now);    
            rptCatePostList.DataSource = Datasource;
            rptCatePostList.DataBind();
        }
        
        protected void lnkbtnPrevious_Click(object sender, EventArgs e)
        {
            int page = 0;
            int.TryParse(Request.QueryString["p"], out page);
            page -= 1;
            page = page <= 0 ? 0 : page;
            if (page == 0)
            {
                Response.Redirect(HostName + "ct/" + Request.QueryString["ct"] + ".aspx");
            }
            else
            {
                Response.Redirect(string.Format(HostName + "ct/" + Request.QueryString["ct"] + "/trang-{0}.aspx", page.ToString()));
            }
        }

        protected void lnkbtnNext_Click(object sender, EventArgs e)
        {
            int page = 0;
            int.TryParse(Request.QueryString["p"], out page);
            page += 1;
            if (page == 0)
            {
                Response.Redirect(HostName + "ct/" + Request.QueryString["ct"]+".aspx");
            }
            else
            {
                Response.Redirect(string.Format(HostName + "ct/" + Request.QueryString["ct"] + "/trang-{0}.aspx", page.ToString()));
            }
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format(HostName+"ct/"+  Request.QueryString["ct"] + "/ngay{0}.apsx", txtGoldDate.Text.Trim().Replace('/', '_')));
        }

        protected void rptCatePostList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //handler allowComment
            if (e.Item.ItemType == ListItemType.Item)
            {
                this.NoComments = Convert.ToBoolean(DataBinder.Eval(e.Item.DataItem, "AllowComments"));
            }
            //handler empty value
            if (rptCatePostList.Items.Count <= 0)
            {
                if (e.Item.ItemType == ListItemType.Footer)
                {
                    Label lblFooter = (Label)e.Item.FindControl("lblEmpty");
                    lblFooter.Visible = true;
                }
            }
        }
        private void disabled_Control_DependOnPage()
        {
            int page = 0;
            int.TryParse(Request.QueryString["p"], out page);
            lnkbtnPrevious.Enabled = !(page == 0);
            lnkbtnNext.Enabled = !(rptCatePostList.Items.Count < 20);
            DateTime dt = DateTime.Now;
            lnkbtnPrevious.Enabled = (page == 0 && rptCatePostList.Items.Count < 20 && DateTime.TryParse(Request.QueryString["d"], out dt));
        }
    }
}