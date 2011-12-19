using NewsVn.Impl.PostFetch;
using NewsVn.Impl.PostFetch.Models;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Linq;
using XCSS3SE;
using NewsVn.Impl.PostFetch.Settings;
using System.Xml.Linq;
using System;

namespace NewsVn.Impl.PostFetch.Services
{
    public class PostFetchServiceAbstract
    {
        private readonly ISettingReader _settingReader;

        /// <summary>
        /// Inits with setting reader as Cache reader
        /// </summary>
        public PostFetchServiceAbstract(ISettingReader settingReader)
        {
            _settingReader = settingReader;
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
        public virtual IList<PostItemModel> RequestPostItemList(PostSettingModel postSetting)
        {
            IList<PostItemModel> itemList = null;

            if (postSetting.Type == Constants.RssValue)
            {
                itemList = RequestRssPostItemList(postSetting);
            }
            else
            {
                itemList = RequestRawPostItemList(postSetting);
            }

            return itemList;
        }

        /// <summary>
        /// Requests a list of wel-formed post items from Rss
        /// </summary>
        /// <param name="categoryUrl"></param>
        /// <param name="postSetting"></param>
        /// <returns></returns>
        protected virtual IList<PostItemModel> RequestRssPostItemList(PostSettingModel postSetting)
        {
            IList<PostItemModel> itemList = null;

            var feedDoc = XDocument.Load(postSetting.Url);

            if (feedDoc != null)
            {
                itemList = feedDoc.Descendants("item").Select(x => new PostItemModel
                {
                    Title = GetXElementValue(x.Element("title")),
                    Description = GetXElementValue(x.Element("description")),
                    Url = GetXElementValue(x.Element("link")),
                    Avatar = GetXElementValue(x.Element("avatar")),
                    PubDate = DateTime.Parse(GetXElementValue(x.Element("pubDate")))
                }).ToList();
            }

            return itemList;
        }

        private string GetXElementValue(XElement elem)
        {
            if (elem != null)
            {
                return elem.Value;
            }
            return null;
        }

        /// <summary>
        /// Requests a list of wel-formed post items from a raw HTML string
        /// </summary>
        /// <param name="categoryUrl"></param>
        /// <param name="postSetting"></param>
        /// <returns></returns>
        protected virtual IList<PostItemModel> RequestRawPostItemList(PostSettingModel postSetting)
        {
            IList<PostItemModel> itemList = null;

            if (postSetting != null)
            {
                string listSelector = GetSelector(postSetting.Filters, Constants.FetchValue, Constants.ListValue);
                string itemSelector = GetSelector(postSetting.Filters, Constants.FetchValue, Constants.ItemValue);
                string titleSelector = GetSelector(postSetting.Filters, Constants.FetchValue, Constants.TitleValue);
                string avatarSelector = GetSelector(postSetting.Filters, Constants.FetchValue, Constants.AvatarValue);
                string descriptionSelector = GetSelector(postSetting.Filters, Constants.FetchValue, Constants.DescriptionValue);

                if (!string.IsNullOrEmpty(listSelector) && !string.IsNullOrEmpty(itemSelector))
                {
                    itemList = new List<PostItemModel>();

                    var sq = new SharpQuery(postSetting.Url);

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
        /// 
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="type"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private string GetSelector(IList<FilterSetting> filters, string type, string target)
        {
            string selector = string.Empty;
            
            if (filters != null)
            {
                var filter = filters.FirstOrDefault(x => type.Equals(x.Type) && target.Equals(x.Target));

                if (filter != null)
                {
                    selector = filter.Selector;
                }
            }

            return selector;
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

