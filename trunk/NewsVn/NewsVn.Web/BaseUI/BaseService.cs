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
            _AdPosts = ApplicationManager.SetCacheData<Data.AdPost>(ApplicationManager.Entities.AdPosts, p => p.Actived);
            _Categories = ApplicationManager.SetCacheData<Data.Category>(ApplicationManager.Entities.Categories, p => p.Actived);
            _PostComments = ApplicationManager.SetCacheData<Data.PostComment>(ApplicationManager.Entities.PostComments, null);
            _Posts = ApplicationManager.SetCacheData<Data.Post>(ApplicationManager.Entities.Posts, t => t.Approved && t.Actived);
            //_UserMessages = ApplicationManager.SetCacheData<Data.UserMessage>(ApplicationManager.Entities.UserMessages, null);
            //_UserProfileComments = ApplicationManager.SetCacheData<Data.UserProfileComment>(ApplicationManager.Entities.UserProfileComments, null);
            //_UserProfiles = ApplicationManager.SetCacheData<Data.UserProfile>(ApplicationManager.Entities.UserProfiles, null);
            
        }
    }
}