using NewsVn.Impl.PostFetch;
using NewsVn.Impl.PostFetch.Models;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Linq;
using NewsVn.Impl.PostFetch.Settings;
using System.Xml.Linq;
using System;
using HtmlAgilityPack;
using Fizzler.Systems.HtmlAgilityPack;
using NewsVn.Impl.Context;
using NewsVn.Impl.Entity;
using System.Threading;
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
                        SiteUrl = siteSetting.Url,
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
        public virtual IList<PostItemModel> RequestPostItemList(PostSettingModel postSetting, NewsVnContext ctx)
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

            var oldLinks = RequestOldPostLinks(ctx);
            
            if (oldLinks != null)
            {
                itemList = itemList.Where(x => !oldLinks.Contains(x.Url.Trim().ToLower())).ToList();    
            }

            return itemList;
        }

        /// <summary>
        /// Requests a query of fetched links
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns></returns>
        protected virtual IQueryable<string> RequestOldPostLinks(NewsVnContext ctx)
        {
            var links = ctx.PostRepo.Getter.getQueryable();

            if (links != null)
            {
                return links.Select(x => x.AutoFetchUrl);
            }
            return null;
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
                    Description = GetDescriptionValue(x.Element("description")),
                    Url = GetXElementValue(x.Element("link")),
                    Avatar = GetAvatarValue(x.Element("description"))//,
                    //PubDate = DateTime.Parse(GetXElementValue(x.Element("pubDate")))
                }).ToList();
            }

            return itemList;
        }

        private string GetDescriptionValue(XElement elem)
        {
            string htmlString = GetXElementValue(elem);
            var html = new HtmlDocument();
            html.LoadHtml(htmlString);
            var doc = html.DocumentNode;
            return doc.InnerText;
        }

        private string GetAvatarValue(XElement elem)
        {
            string htmlString = GetXElementValue(elem);
            var html = new HtmlDocument();
            html.LoadHtml(htmlString);
            var doc = html.DocumentNode;
            doc = doc.QuerySelector("img");

            if (doc != null)
            {
                return doc.Attributes["src"].Value;
            }
            return string.Empty;            
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
                string linkSelector = GetSelector(postSetting.Filters, Constants.FetchValue, Constants.LinkValue);

                if (!string.IsNullOrEmpty(listSelector) && !string.IsNullOrEmpty(itemSelector))
                {
                    itemList = new List<PostItemModel>();

                    var web = new HtmlWeb();
                    var html = web.Load(postSetting.Url);

                    var doc = html.DocumentNode;
                    var resultDocs = doc.QuerySelectorAll(listSelector + " " + itemSelector);

                    foreach (var resultDoc in resultDocs)
                    {
                        var postItem = new PostItemModel
                        {
                            Title = resultDoc.QuerySelector(titleSelector).InnerText,
                            Description = resultDoc.QuerySelector(descriptionSelector).InnerText,
                            Avatar = postSetting.SiteUrl + resultDoc.QuerySelector(avatarSelector).Attributes["src"].Value,
                            Url = postSetting.SiteUrl + resultDoc.QuerySelector(linkSelector).Attributes["href"].Value
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
        /// 
        /// </summary>
        /// <param name="rules"></param>
        /// <param name="type"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private string[] GetConditions(IList<RuleSetting> rules, string type, string target)
        {
            IList<string> conditionList = new List<string>();

            if (rules != null)
            {
                var ruleSet = rules.Where(x => type.Equals(x.Type) && target.Equals(x.Target));

                if (ruleSet != null)
                {
                    foreach (var rule in ruleSet)
                    {
                        conditionList.Add(rule.Condition);
                    }
                }
            }

            return conditionList.ToArray();
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
            PostItemModel item = null;

            try
            {
                string titleSelector = GetSelector(postSetting.Filters, Constants.PostValue, Constants.TitleValue);
                //string avatarSelector = GetSelector(postSetting.Filters, Constants.PostValue, Constants.AvatarValue);
                string descriptionSelector = GetSelector(postSetting.Filters, Constants.PostValue, Constants.DescriptionValue);
                string contentSelector = GetSelector(postSetting.Filters, Constants.PostValue, Constants.ContentValue);

                var web = new HtmlWeb();
                var html = web.Load(itemUrl);
                var doc = html.DocumentNode;

                item = new PostItemModel
                {
                    Title = doc.QuerySelector(titleSelector).InnerText,
                    //Avatar = doc.QuerySelector(avatarSelector).Attributes["src"].Value,
                    Description = doc.QuerySelector(descriptionSelector).InnerText,
                    Content = doc.QuerySelector(contentSelector).InnerHtml
                };
                item.Avatar = "";

                string[] conditions = GetConditions(postSetting.Rules, Constants.PostValue, Constants.ExcludeValue);
                for (int i = 0; i < conditions.Length; i++)
                {
                    var excludeHtml = doc.QuerySelector(conditions[i]).OuterHtml;
                    item.Content = item.Content.Replace(excludeHtml, string.Empty);
                }
                bool hasHttp = item.Content.Contains("src=\"http");
                if (!hasHttp)
                {
                    item.Content = item.Content.Replace("src=\"", "src=\"" + postSetting.SiteUrl);
                }
            }
            catch (Exception ex)
            {
                item = null;
            }

            return item;
        }

        /// <summary>
        /// Adds post item into database
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual bool AddPostItem(PostItemModel item, NewsVnContext ctx)
        {
            bool success = true;

            try
            {
                var cate = ctx.CategoryRepo.Getter.getFirst(x => x.ID == item.TargetID);

                if (cate != null)
                {
                    var post = item.ToPostEntity();
                    ctx.PostRepo.Setter.addOne(post, true);
                    //post.SeoUrl = string.Format("pt/{0}/{1}/{2}.aspx", cate.SeoName, post.ID, item.RemoveUnicodeMarks(post.Title));
                    //ctx.SubmitChanges();
                }
                else
                {
                    success = false;
                }
            }
            catch (Exception)
            {
                success = false;
            }

            return success;
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

