using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsVn.Web.Modules
{
    public partial class DetailedPostItem : System.Web.UI.UserControl
    {
        public Data.Post Datasource { get; set; }
        public bool AllowComment { get; set; }
        public int CountedComment { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }
        protected override void OnDataBinding(EventArgs e)
        {
            lblTitle.Text = Datasource.Title;
            lblApprovedOn.Text = string.Format("{0:dddd, dd/MM/yyyy HH:mm}", Datasource.ApprovedOn) + " GMT+7";
            lblNumberComments.Text = CountedComment.ToString();
            lblDescription.Text = Datasource.Description;
            ltrContent.Text = Datasource.Content;
            lblApprovedOnbtm.Text = lblApprovedOn.Text;
            lblNumberCommentbot.Text = lblNumberComments.Text;
        }
    }
}