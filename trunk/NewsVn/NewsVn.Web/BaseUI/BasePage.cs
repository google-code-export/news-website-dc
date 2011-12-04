using System;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using NewsVn.Web.Utils;

namespace NewsVn.Web.BaseUI
{
    public class BasePage : System.Web.UI.Page
    {
        public string SiteTitle { get; set; }
        public string MetaKeyWords { get; set; }
        public string MetaKeyDes { get; set; }

        public string InfoBar { get; set; }
        public string ErrorBar { get; set; }

        public string HostName { get; set; }

        // CuongNguyen: 28/11/2011
        protected bool ExeSeo = true;

        protected override void OnInit(EventArgs e)
        {
            SiteTitle = "NewsVN :: ";

            var sb = new StringBuilder();
            sb.Append("<li><div class=\"ui-widget\"><div class=\"ui-state-highlight ui-corner-all\" style=\"padding: 0 .7em;\">");
            sb.Append("<p><span class=\"ui-icon ui-icon-info\" style=\"float: left; margin: .15em .3em 0 0;\"></span>");
            sb.Append("<b>&raquo;</b> {0}</p></div></div></li>");
            InfoBar = sb.ToString();

            sb = new StringBuilder();
            sb.Append("<li><div class=\"ui-widget\"><div class=\"ui-state-error ui-corner-all\" style=\"padding: 0 .7em;\">");
            sb.Append("<p><span class=\"ui-icon ui-icon-alert\" style=\"float: left; margin: .15em .3em 0 0;\"></span>");
            sb.Append("<b>&raquo;</b> {0}</p></div></div></li>");
            ErrorBar = sb.ToString();

            HostName = ApplicationManager.HostName;

            ExeSeo = true;

            base.OnInit(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.Title = SiteTitle + " :: Cổng thông tin điện tử 24/07";
            
            if (!IsPostBack)
            {
                this.Header.DataBind();

                if (ExeSeo)
                {
                    Generate_SeoMeta();
                }
            }            
        }

        protected void ExecuteSEO(string title, string metaKeyWords, string metaDes)
        {
            SiteTitle += title;
            MetaKeyWords = metaKeyWords.Length <= 0 ? "NewsVn,Vietnam news daily,24/7,online,economic,internet,ads,education,rao vat,quang cao,tin hot,tu van,viec lam,works,tim ban,blog,tin tuc,sai gon,ha noi,da nang,du lich,dien anh" : metaKeyWords;
            MetaKeyDes = metaDes.Length <= 0 ? "Cổng thông tin điện tử - thông tin nhanh, chính xác được đăng tải liên tục 24/07 thông tin Việt nam - Thế giới về Kinh tế" : metaDes;
        }

        private void Generate_SeoMeta()
        {
            this.Header.Controls.Add(new LiteralControl("\n"));
            HtmlMeta metaKeyWords = new HtmlMeta();
            metaKeyWords.Name = "Keywords";
            metaKeyWords.Content = MetaKeyWords;

            HtmlMeta metaKeyDescription = new HtmlMeta();
            metaKeyDescription.Name = "Description";
            metaKeyDescription.Content = MetaKeyDes;

            this.Header.Controls.Add(metaKeyWords);
            this.Header.Controls.Add(new LiteralControl("\n"));
            this.Header.Controls.Add(metaKeyDescription);
        }
    }
}