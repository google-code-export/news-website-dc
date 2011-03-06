using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using NewsVn.Web.Utils;

namespace NewsVn.Web.BaseUI
{
    public class BasePage : System.Web.UI.Page
    {
        public string SiteTitle { get; set; }
        public string InfoBar { get; set; }
        public string ErrorBar { get; set; }
        public string HostName { get; set; }

        protected IQueryable<Data.AdBox> _AdBoxes;
        protected IQueryable<Data.AdCategory> _AdCategories;
        protected IQueryable<Data.AdPost> _AdPosts;
        protected IQueryable<Data.Category> _Categories;
        protected IQueryable<Data.PostComment> _PostComment;
        protected IQueryable<Data.Post> _Post;
        protected IQueryable<Data.UserMessage> _UserMessage;
        protected IQueryable<Data.UserProfileComment> _UserProfileComment;
        protected IQueryable<Data.UserProfile> _UserProfile; 

        protected override void OnInit(EventArgs e)
        {
            SiteTitle = "NewsVN - xxx :: ";

            var sb = new StringBuilder();
            sb.Append("<li><div class=\"ui-widget\"><div class=\"ui-state-highlight ui-corner-all\" style=\"padding: 0 .7em;\">");
            sb.Append("<p><span class=\"ui-icon ui-icon-info\" style=\"float: left; margin: .15em .3em 0 0;\"></span>");
            sb.Append("<b>Thông báo:</b> {0}</p></div></div></li>");
            InfoBar = sb.ToString();

            sb = new StringBuilder();
            sb.Append("<li><div class=\"ui-widget\"><div class=\"ui-state-error ui-corner-all\" style=\"padding: 0 .7em;\">");
            sb.Append("<p><span class=\"ui-icon ui-icon-alert\" style=\"float: left; margin: .15em .3em 0 0;\"></span>");
            sb.Append("<b>Cảnh báo:</b> {0}</p></div></div></li>");
            ErrorBar = sb.ToString();

            HostName = NewsVn.Web.Utils.ApplicationManager.HostName;

            _AdBoxes = ApplicationManager.SetCacheData<Data.AdBox >(ApplicationManager.Entities.AdBoxes , t => !t.Actived );
            _AdCategories = ApplicationManager.SetCacheData<Data.AdCategory >(ApplicationManager.Entities.AdCategories , p => p.Actived);
            _AdPosts = ApplicationManager.SetCacheData<Data.AdPost >(ApplicationManager.Entities.AdPosts , null);
            //_slides = ApplicationManager.SetCacheData<Data.Slide>(ApplicationManager.Entities.Slides, null);
            //_albums = ApplicationManager.SetCacheData<Data.Album>(ApplicationManager.Entities.Albums, null);
            //_cust = ApplicationManager.SetCacheData<Data.Customer>(ApplicationManager.Entities.Customers, t => !t.Deleted);
            //_waterconsump = ApplicationManager.SetCacheData<Data.WaterComsumption>(ApplicationManager.Entities.WaterComsumptions, t => !t.Deleted);
            //_docs = ApplicationManager.SetCacheData<Data.CONGVAN>(ApplicationManager.Entities.CONGVANs, t => !t.Hidden);
            //_dscq = ApplicationManager.SetCacheData<Data.DSCQ>(ApplicationManager.Entities.DSCQs, null);
            //_tlvb = ApplicationManager.SetCacheData<Data.TLVB>(ApplicationManager.Entities.TLVBs, null);
            //_dsdv = ApplicationManager.SetCacheData<Data.DSDV>(ApplicationManager.Entities.DSDVs, null);
            //_bgd = ApplicationManager.SetCacheData<Data.BGD>(ApplicationManager.Entities.BGDs, null);
            
            base.OnInit(e);
        }
    }
}