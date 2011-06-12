﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewsVn.Web.Utils;
using System.Text;

namespace NewsVn.Web.BaseUI
{
    public class BaseService : System.Web.Services.WebService
    {
        public string HostName { get; set; }
        public static string[] skyStatus { get; set; }
        protected string _CacheName;

        public string InfoBar { get; set; }
        public string ErrorBar { get; set; }

        //protected IQueryable<Data.AdBox> _AdBoxes;        
        //protected IQueryable<Data.AdPost> _AdPosts;
        //protected IQueryable<Data.Category> _Categories;
        //protected IQueryable<Data.Category> _AdCategories;
        //protected IQueryable<Data.Category> _VideoCategories;
        //protected IQueryable<Data.PostComment> _PostComments;
        //protected IQueryable<Data.Post> _Posts;
        //protected IQueryable<Data.UserMessage> _UserMessages;
        //protected IQueryable<Data.UserProfileComment> _UserProfileComments;
        //protected IQueryable<Data.UserProfile> _UserProfiles;


        public BaseService()
        {
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

            skyStatus = ApplicationManager.skyStatus;
            HostName = NewsVn.Web.Utils.ApplicationManager.HostName;
            //_AdBoxes = ApplicationManager.SetCacheData<Data.AdBox>(ApplicationManager.Entities.AdBoxes, t => t.Actived);            
            //_Categories = ApplicationManager.Entities.Categories.Where(c => "post".Equals(c.Type, StringComparison.OrdinalIgnoreCase) && c.Actived).ToList().AsQueryable();
            //_AdCategories = ApplicationManager.Entities.Categories.Where(c => "adpost".Equals(c.Type, StringComparison.OrdinalIgnoreCase) && c.Actived).ToList().AsQueryable();
            //_VideoCategories = ApplicationManager.Entities.Categories.Where(c => "video".Equals(c.Type, StringComparison.OrdinalIgnoreCase) && c.Actived).ToList().AsQueryable();
            //_UserMessages = ApplicationManager.SetCacheData<Data.UserMessage>(ApplicationManager.Entities.UserMessages, null);
            //_UserProfileComments = ApplicationManager.SetCacheData<Data.UserProfileComment>(ApplicationManager.Entities.UserProfileComments, null);

            //no cache
            //_UserProfiles = ApplicationManager.Entities.UserProfiles.AsQueryable();
            //_PostComments = ApplicationManager.Entities.PostComments.AsQueryable();
            //_Posts = ApplicationManager.Entities.Posts.Where(p => p.Approved && p.Actived && p.Category.Actived);
            //_AdPosts = ApplicationManager.Entities.AdPosts.Where(a => a.Actived);
            //_AdPosts = ApplicationManager.SetCacheData<Data.AdPost>(ApplicationManager.Entities.AdPosts, null);
        }
    }
}