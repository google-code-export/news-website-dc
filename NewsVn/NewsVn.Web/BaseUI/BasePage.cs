using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data.Objects.DataClasses;
using NewsVn.Data;
using NewsVn.Core.Caching;
using System.Text;
using NewsVn.Web.Utils;
using System.Threading;
using System.Globalization;

namespace NewsVn.Web.BaseUI
{
    public class BasePage : System.Web.UI.Page
    {        
        public string SiteTitle { get; set; }
       
        public string InfoBar { get; set; }
        public string ErrorBar { get; set; }
        
        public string HostName { get; set; }

        protected string _CacheName;
        
        protected IQueryable<Data.AdBox> _AdBoxes;
        protected IQueryable<Data.AdCategory> _AdCategories;
        protected IQueryable<Data.AdPost> _AdPosts;
        protected IQueryable<Data.Category> _Categories;
        protected IQueryable<Data.PostComment> _PostComments;
        protected IQueryable<Data.Post> _Posts;
        protected IQueryable<Data.UserMessage> _UserMessages;
        protected IQueryable<Data.UserProfileComment> _UserProfileComments;
        protected IQueryable<Data.UserProfile> _UserProfiles;            
        
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

            HostName = ApplicationManager.HostName;

            _AdBoxes = ApplicationManager.SetCacheData<Data.AdBox >(ApplicationManager.Entities.AdBoxes , t => t.Actived);
            _AdCategories = ApplicationManager.SetCacheData<Data.AdCategory >(ApplicationManager.Entities.AdCategories , p => p.Actived);
            //_AdPosts = ApplicationManager.SetCacheData<Data.AdPost >(ApplicationManager.Entities.AdPosts , p => p.Actived);
            _Categories = ApplicationManager.SetCacheData<Data.Category>(ApplicationManager.Entities.Categories, p=> p.Actived);
            _PostComments = ApplicationManager.SetCacheData<Data.PostComment>(ApplicationManager.Entities.PostComments, null);
            //_Posts = ApplicationManager.SetCacheData<Data.Post>(ApplicationManager.Entities.Posts, t => t.Approved && t.Actived );
            _UserMessages = ApplicationManager.SetCacheData<Data.UserMessage>(ApplicationManager.Entities.UserMessages, null);
            _UserProfileComments = ApplicationManager.SetCacheData<Data.UserProfileComment>(ApplicationManager.Entities.UserProfileComments, null);
            _UserProfiles = ApplicationManager.SetCacheData<Data.UserProfile>(ApplicationManager.Entities.UserProfiles, null);

            _Posts = ApplicationManager.Entities.Posts.ToList().AsQueryable();
            _AdPosts = ApplicationManager.Entities.AdPosts.ToList().AsQueryable();
            
            base.OnInit(e);
        }
    }
}