using NewsVn.Impl.PostFetch;
using NewsVn.Impl.PostFetch.Models;
using System.Collections.Generic;

namespace NewsVn.Impl.PostFetch.Services
{
    public class PostFetchServiceAbstract
    {
        private readonly ISettingReader _settingReader;

        /// <summary>
        /// Inits with setting reader as Cache reader
        /// </summary>
        public PostFetchServiceAbstract()
        {
            _settingReader = new XmlSettingReader();
        }

        /// <summary>
        /// Requests specific setting
        /// </summary>
        /// <param name="siteID"></param>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        public virtual PostSettingModel RequestSetting(int siteID, int categoryID)
        {
            return null;
        }

        /// <summary>
        /// Requests a list of wel-formed post items
        /// </summary>
        /// <param name="categoryUrl"></param>
        /// <returns></returns>
        public virtual IList<PostItemModel> RequestPostItemList(string categoryUrl)
        {
            return null;
        }

        /// <summary>
        /// Requests a string contains raw data of post item list
        /// </summary>
        /// <param name="categoryUrl"></param>
        /// <returns></returns>
        public virtual string RequestRawPostItemList(string categoryUrl)
        {
            return null;
        }

        /// <summary>
        /// Filters and removes duplicate post items
        /// </summary>
        /// <param name="itemList"></param>
        /// <returns></returns>
        protected virtual IList<PostItemModel> FilterPostItemList(IList<PostItemModel> itemList)
        {
            return null;
        }

        /// <summary>
        /// Requests a string as raw post item
        /// </summary>
        /// <param name="itemUrl"></param>
        /// <returns></returns>
        public virtual string RequestRawPostItem(string itemUrl)
        {
            return null;
        }

        /// <summary>
        /// Adds post item into database
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual bool AddPostItem(PostItemModel item)
        {
            return false;
        }

        /// <summary>
        /// Checks if this post item has been existed in database
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected virtual bool CheckExist(PostItemModel item)
        {
            return false;
        }
    }
}

