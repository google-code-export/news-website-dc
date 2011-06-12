using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsVn.Web.Modules
{
    public partial class DetailedPostItem : BaseUI.BaseModule
    {
        public Data.Post Datasource { get; set; }
        public bool AllowComment { get; set; }
        public int CountedComment { get; set; }
        public string SeoUrl { get; set; }
        public string strTitle { get; set; }
        
        protected override void OnDataBinding(EventArgs e)
        {
            lblTitle.Text = Datasource.Title;
            strTitle = Server.UrlEncode(Datasource.Title);
            lblApprovedOn.Text = string.Format("{0:dddd, dd/MM/yyyy HH:mm}", Datasource.ApprovedOn) + " GMT+7";
            lblNumberComments.Text = CountedComment.ToString();
            lblDescription.Text = Datasource.Description;
            ltrContent.Text = Datasource.Content;
            lblApprovedOnbtm.Text = lblApprovedOn.Text;
            lblNumberCommentbot.Text = lblNumberComments.Text;
            SeoUrl = HostName.Remove(HostName.Length - 1, 1) + Request.RawUrl.ToString();
        }
    }
}