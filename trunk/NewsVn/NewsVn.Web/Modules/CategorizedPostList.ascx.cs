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
                disabled_Control_DependOnPage();
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
                Response.Redirect("Category.aspx?ct=" + Request.QueryString["ct"]);
            }
            else
            {
                Response.Redirect(string.Format("Category.aspx?ct=" + Request.QueryString["ct"] + "&p={0}", page.ToString()));
            }
        }

        protected void lnkbtnNext_Click(object sender, EventArgs e)
        {
            int page = 0;
            int.TryParse(Request.QueryString["p"], out page);
            page += 1;
            if (page == 0)
            {
                Response.Redirect("Category.aspx?ct=" + Request.QueryString["ct"]);
            }
            else
            {
                Response.Redirect(string.Format("Category.aspx?ct=" + Request.QueryString["ct"] + "&p={0}", page.ToString()));
            }
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            string[] arrDateTime = txtGoldDate.Text.Split('/');
            Response.Redirect(string.Format("Category.aspx?ct=" + Request.QueryString["ct"] + "&d={0}", arrDateTime[1] + "/" + arrDateTime[0] + "/" + arrDateTime[2]));
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