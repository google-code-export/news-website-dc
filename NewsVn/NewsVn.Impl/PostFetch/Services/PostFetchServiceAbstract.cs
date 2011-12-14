using NewsVn.Impl.PostFetch;
using NewsVn.Impl.PostFetch.Models;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Linq;
using XCSS3SE;

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
            //string xmlPath = "../../PostFetchSites.xml";
            _settingReader = new XmlSettingReader(xmlPath);
        }

        /// <summary>
        /// Requests specific setting
        /// </summary>
        /// <param name="siteID"></param>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        public virtual PostSettingModel RequestSetting(int siteID, int categoryID)
        {
            PostSettingModel setting = null;
            
            var siteSettings = _settingReader.GetSiteSettings();
            var siteSetting = siteSettings.FirstOrDefault(x => x.ID == siteID);

            if (siteSetting != null && siteSetting.Categories != null)
            {
                var categorySetting = siteSetting.Categories.FirstOrDefault(x => x.ID == categoryID);

                if (categorySetting != null)
                {
                    setting = new PostSettingModel
                    {
                        Type = categorySetting.Type,
                        Url = categorySetting.Url,
                        TargetID = categorySetting.TargetID,
                        Filters = siteSetting.Filters,
                        Rules = siteSetting.Rules
                    };
                }
            }

            return setting;
        }

        /// <summary>
        /// Requests a list of wel-formed post items
        /// </summary>
        /// <param name="categoryUrl"></param>
        /// <param name="postSetting"></param>
        /// <returns></returns>
        public virtual IList<PostItemModel> RequestPostItemList(string categoryUrl, PostSettingModel postSetting)
        {
            IList<PostItemModel> itemList = null;

            if (postSetting.Type == Constants.RssValue)
            {
                itemList = RequestRssPostItemList(categoryUrl, postSetting);
            }
            else
            {
                itemList = RequestRawPostItemList(categoryUrl, postSetting);
            }

            return itemList;
        }

        /// <summary>
        /// Requests a list of wel-formed post items from Rss
        /// </summary>
        /// <param name="categoryUrl"></param>
        /// <param name="postSetting"></param>
        /// <returns></returns>
        protected virtual IList<PostItemModel> RequestRssPostItemList(string categoryUrl, PostSettingModel postSetting)
        {
            return null;
        }

        /// <summary>
        /// Requests a list of wel-formed post items from a raw HTML string
        /// </summary>
        /// <param name="categoryUrl"></param>
        /// <param name="postSetting"></param>
        /// <returns></returns>
        protected virtual IList<PostItemModel> RequestRawPostItemList(string categoryUrl, PostSettingModel postSetting)
        {
            IList<PostItemModel> itemList = null;

            if (postSetting != null && postSetting.Filters != null && postSetting.Rules != null)
            {
                string listSelector = string.Empty;
                string itemSelector = string.Empty;
                string titleSelector = string.Empty;
                string avatarSelector = string.Empty;
                string descriptionSelector = string.Empty;

                var listFilters = postSetting.Filters.Where(x => x.Type == Constants.FetchValue);

                foreach (var filter in listFilters)
                {
                    if (filter.Target == Constants.ListValue)
                    {
                        listSelector = filter.Selector;
                    }
                    else if (filter.Target == Constants.ItemValue)
                    {
                        itemSelector = filter.Selector;
                    }
                    else if (filter.Target == Constants.TitleValue)
                    {
                        titleSelector = filter.Selector;
                    }
                    else if (filter.Target == Constants.AvatarValue)
                    {
                        avatarSelector = filter.Selector;
                    }
                    else if (filter.Target == Constants.DescriptionValue)
                    {
                        descriptionSelector = filter.Selector;
                    }
                }

                if (!string.IsNullOrEmpty(listSelector) && !string.IsNullOrEmpty(itemSelector))
                {
                    itemList = new List<PostItemModel>();

                    var sq = new SharpQuery(categoryUrl);

                    foreach (var el in sq.Find(listSelector + " " + itemSelector + " " + titleSelector))
                    {
                        var postItem = new PostItemModel
                        {
                            Title = el.InnerText
                        };
                        itemList.Add(postItem);
                    }
                }
            }
     
            return itemList;
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
        /// Requests post item from a raw HTML string
        /// </summary>
        /// <param name="itemUrl"></param>
        /// <param name="postSetting"></param>
        /// <returns></returns>
        public virtual PostItemModel RequestRawPostItem(string itemUrl, PostSettingModel postSetting)
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

