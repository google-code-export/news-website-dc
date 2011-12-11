using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml;
using System.Linq;
using NewsVn.Impl.PostFetch.Settings;


namespace NewsVn.Impl.PostFetch
{
    public class XmlSettingReader : ISettingReader
    {
        private const string CacheKey = "Fetch.Settings.Xml";

        private readonly string _xmlPath;

        /// <summary>
        /// Inits this reader as a Cache reader
        /// </summary>
        public XmlSettingReader()
        {
            _xmlPath = string.Empty;
        }

        /// <summary>
        /// Inits this reader by specific XML Path
        /// </summary>
        /// <param name="xmlPath"></param>
        public XmlSettingReader(string xmlPath)
        {
            _xmlPath = xmlPath;
        }

        /// <summary>
        /// Gets category settings from XML
        /// </summary>
        /// <param name="parentNode"></param>
        /// <returns></returns>
        private IList<CategorySetting> GetCategorySettings(XElement parentNode)
        {
            try
            {
                if (parentNode == null)
                {
                    return null;
                }
                var categoryList = from c in parentNode.Descendants("category")
                                   select (new CategorySetting
                                   {
                                       // Add properties here
                                       ID = int.Parse(c.Attribute("id").Value),
                                       TargetID = int.Parse(c.Attribute("target-id").Value),
                                       Type = c.Parent.Attribute("type").Value,
                                       Name = c.Value,
                                       Url = c.Attribute("url").Value
                                       //Site=new SiteSetting ()
                                   });
                return categoryList.ToList();
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Gets filter settings from XML
        /// </summary>
        /// <param name="parentNode"></param>
        /// <returns></returns>
        private IList<FilterSetting> GetFilterSettings(XElement parentNode)
        {
            try
            {
                if (parentNode == null)
                {
                    return null;
                }
                var filterList = from c in parentNode.Descendants("filter")
                                 select (new FilterSetting
                                 {
                                     // Add properties here
                                     Type = c.Parent.Attribute("type").Value,
                                     Selector = c.Value,
                                     Target = c.Attribute("target").Value
                                     //Site=new SiteSetting()
                                 });
                return filterList.ToList();

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Gets rule settings from XML
        /// </summary>
        /// <param name="parentNode"></param>
        /// <returns></returns>
        private IList<RuleSetting> GetRuleSettings(XElement parentNode)
        {
            try
            {
                if (parentNode == null)
                {
                    return null;
                }
                var ruleList = from c in parentNode.Descendants("rule")
                               select (new RuleSetting
                               {
                                   // Add properties here
                                   Type = c.Parent.Attribute("type").Value,
                                   Target = c.Attribute("target").Value,
                                   Condition = c.Value
                                   //Site=new SiteSetting()
                               });
                return ruleList.ToList();
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// @see NewsVn.Impl.PostFetch.ISettingReader#GetSiteSettings()
        /// </summary>
        /// <returns></returns>
        public IList<SiteSetting> GetSiteSettings()
        {
            try
            {
                // Create the query
                var sites = from c in XElement.Load(_xmlPath).Elements("site")
                            select (new SiteSetting
                            {
                                // Add properties here
                                ID = int.Parse(c.Attribute("id").Value),
                                Name = c.Attribute("name").Value,
                                Url = c.Attribute("url").Value,
                                Categories = GetCategorySettings(c),
                                Filters = GetFilterSettings(c),
                                Rules = GetRuleSettings(c)
                            });

                string siteCacheKey = CacheKey + ".sitelist";

                if (!NewsVn.Impl.Caching.HttpContextCache.Exists(siteCacheKey))
                {
                    NewsVn.Impl.Caching.HttpContextCache.Add(siteCacheKey, sites.ToList());
                }

                return sites.ToList();
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// @see NewsVn.Impl.PostFetch.ISettingReader#GetCachedSiteSettings()
        /// </summary>
        /// <returns></returns>
        public IList<SiteSetting> GetCachedSiteSettings()
        {
            try
            {
                string siteCacheKey = CacheKey + ".sitelist";
                if (NewsVn.Impl.Caching.HttpContextCache.Exists(siteCacheKey))
                {
                    return (IList<SiteSetting>)NewsVn.Impl.Caching.HttpContextCache.Get<IList<SiteSetting>>(siteCacheKey);
                }
                else
                {
                    return GetSiteSettings();
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// @see NewsVn.Impl.PostFetch.ISettingReader#CacheSiteSettings()
        /// </summary>
        public void CacheSiteSettings()
        {

        }
    }
}

