using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewsVn.Web.Utils;

namespace NewsVn.Web.Modules
{
    public partial class CommentBox : System.Web.UI.UserControl
    {
        public object Datasource { get; set; }
        public int PostID { get; set; }
        public string PostTitle { get; set; }
        public int CommentNumbers { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
                //int x = 0;
                //int.TryParse(Request.QueryString["cp"], out x);
                //PostID = x;
                //load_Comments();
        }
        protected override void OnDataBinding(EventArgs e)
        {
            lsvComment.DataSource = Datasource;
            lsvComment.DataBind();
            Button1.PostBackUrl = Context.Request.Url.ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            txtTitle.Text = "fdoaofjdajfad";
        }

        protected void lsvComment_DataBound(object sender, EventArgs e)
        {
            if (DataPager1 != null)
            {
                //lblTrang.Visible = DataPager1.PageSize < DataPager1.TotalRowCount;
                //DataPager1.Visible = DataPager1.PageSize < DataPager1.TotalRowCount;
            }
        }

        protected void lsvComment_PagePropertiesChanged(object sender, EventArgs e)
        {
            //load_Comments();
        }
        void load_Comments()
        {
            var commentData = ApplicationManager.Entities.PostComments.ToList().Where(pc=>pc.Post.ID==PostID).Select(
                pc => new { 
                pc.CreatedOn,
                pc.Content,
                pc.Title,
                pc.CreatedBy,
                }).OrderByDescending(pc => pc.CreatedOn).ToList();
            lsvComment.DataSource = Datasource;
            lsvComment.DataBind();
        }
    }
}