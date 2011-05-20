using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewsVn.Web.Utils;

namespace NewsVn.Web.BaseUI
{
    public class BaseService : System.Web.Services.WebService
    {
        public string HostName { get; set; }
        public static string[] skyStatus { get; set; }
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

        
        public BaseService()
        {
            skyStatus = ApplicationManager.skyStatus;

            _AdBoxes = ApplicationManager.SetCacheData<Data.AdBox>(ApplicationManager.Entities.AdBoxes, t => t.Actived);
            _AdCategories = ApplicationManager.SetCacheData<Data.AdCategory>(ApplicationManager.Entities.AdCategories, p => p.Actived);
            _Categories = ApplicationManager.SetCacheData<Data.Category>(ApplicationManager.Entities.Categories, p => p.Actived);
            _UserMessages = ApplicationManager.SetCacheData<Data.UserMessage>(ApplicationManager.Entities.UserMessages, null);
            _UserProfileComments = ApplicationManager.SetCacheData<Data.UserProfileComment>(ApplicationManager.Entities.UserProfileComments, null);

            //no cache
            _UserProfiles = ApplicationManager.Entities.UserProfiles.AsQueryable();
            _PostComments = ApplicationManager.Entities.PostComments.AsQueryable();
            _Posts = ApplicationManager.Entities.Posts.Where(p => p.Approved && p.Actived && p.Category.Actived);
            // _AdPosts = ApplicationManager.Entities.AdPosts.Where(a => a.Actived);
            _AdPosts = ApplicationManager.SetCacheData<Data.AdPost>(ApplicationManager.Entities.AdPosts, null);
        }
    }
}