using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using NewsVn.Impl.Caching;
using NewsVn.Impl.PostFetch.Settings;

namespace NewsVn.Impl.PostFetch
{
    public class XmlSettingReader : ISettingReader
    {
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
        /// @see NewsVn.Impl.PostFetch.ISettingReader#GetSiteSettings()
        /// </summary>
        /// <returns></returns>
        public IList<SiteSetting> GetSiteSettings()
        {
            // Get list of settings from cache
            IList<SiteSetting> siteSettings = GetCachedSiteSettings();

            // Return from cache
            if (siteSettings != null)
            {
                return siteSettings;
            }

            // No Cache: Create the query
            var sites = from x in XElement.Load(_xmlPath).Elements(Constants.SiteNode)
                        select (new SiteSetting
                        {
                            ID = int.Parse(x.Attribute(Constants.IdAttr).Value),
                            Name = x.Attribute(Constants.NameAttr).Value,
                            Url = x.Attribute(Constants.UrlAttr).Value,
                            Categories = GetCategorySettings(x.Element(Constants.CategoriesNode)),
                            Filters = GetFilterSettings(x.Element(Constants.FiltersNode)),
                            Rules = GetRuleSettings(x.Element(Constants.RulesNode))
                        });            

            if (sites != null)
            {
                // Order by ID
                sites = from x in sites orderby x.ID select x;
                
                // Define check token
                int idToken = 0;
                // Loop over to validate ID input
                foreach (var site in sites)
                {
                    int id = site.ID; 
                    // Throw XmlException in case IDs are not well-inputted
                    if (id != idToken + 1)
                    {
                        throw new System.Xml.XmlException();
                    }
                    idToken = id;
                }

                // Cache and return
                siteSettings = sites.ToList();
                CacheSiteSettings(siteSettings);
            }

            return siteSettings;
        }

        /// <summary>
        /// @see NewsVn.Impl.PostFetch.ISettingReader#GetCachedSiteSettings()
        /// </summary>
        /// <returns></returns>
        public IList<SiteSetting> GetCachedSiteSettings()
        {
            IList<SiteSetting> siteSettings = null;

            // Return from cache
            if (HttpContextCache.Exists(Constants.XmlCacheKey))
            {
                siteSettings = HttpContextCache.Get<IList<SiteSetting>>(Constants.XmlCacheKey);
            }

            return siteSettings;
        }

        /// <summary>
        /// @see NewsVn.Impl.PostFetch.ISettingReader#CacheSiteSettings()
        /// </summary>
        public void CacheSiteSettings(IList<SiteSetting> siteSettings)
        {
            if (!HttpContextCache.Exists(Constants.XmlCacheKey) && siteSettings != null)
            {
                HttpContextCache.Add(Constants.XmlCacheKey,
                    siteSettings, TimeSpan.FromDays(Constants.CacheDays));
            }
        }

        /// <summary>
        /// Gets category settings from XML
        /// </summary>
        /// <param name="parentNode"></param>
        /// <returns></returns>
        private IList<CategorySetting> GetCategorySettings(XElement parentNode)
        {
            if (parentNode == null)
            {
                return null;
            }

            IList<CategorySetting> categorySettings = null;

            // Create the query
            var categories = from x in parentNode.Descendants(Constants.CategoryNode)
                             select (new CategorySetting
                             {
                                 ID = int.Parse(x.Attribute(Constants.IdAttr).Value),
                                 TargetID = int.Parse(x.Attribute(Constants.TargetIdAttr).Value),
                                 Type = GetTypeAttribute(x),
                                 Name = x.Value,
                                 Url = x.Attribute(Constants.UrlAttr).Value
                             });

            if (categories != null)
            {
                // Order by ID
                categories = from x in categories orderby x.ID select x;

                // Define check token
                int idToken = 0;
                // Loop over to validate ID input
                foreach (var category in categories)
                {
                    int id = category.ID;
                    // Throw XmlException in case IDs are not well-inputted
                    if (id != idToken + 1)
                    {
                        throw new System.Xml.XmlException();
                    }
                    idToken = id;
                }

                // Return
                categorySettings = categories.ToList();
            }

            return categorySettings;
        }

        /// <summary>
        /// Gets filter settings from XML
        /// </summary>
        /// <param name="parentNode"></param>
        /// <returns></returns>
        public IList<FilterSetting> GetFilterSettings(XElement parentNode)
        {
            if (parentNode == null)
            {
                return null;
            }

            IList<FilterSetting> filterSettings = null;

            // Create the query
            var filters = from x in parentNode.Descendants(Constants.FilterNode)
                             select (new FilterSetting
                             {
                                 Type = GetTypeAttribute(x),                                 
                                 Target = x.Attribute(Constants.TargetAttr).Value,
                                 Selector = x.Value
                             });

            if (filters != null)
            {
                filterSettings = filters.ToList();
            }

            return filterSettings;
        }

        /// <summary>
        /// Gets rule settings from XML
        /// </summary>
        /// <param name="parentNode"></param>
        /// <returns></returns>
        public IList<RuleSetting> GetRuleSettings(XElement parentNode)
        {
            if (parentNode == null)
            {
                return null;
            }

            IList<RuleSetting> ruleSettings = null;

            // Create the query
            var rules = from x in parentNode.Descendants(Constants.RuleNode)
                           select (new RuleSetting
                           {
                               Type = GetTypeAttribute(x),
                               Target = x.Attribute(Constants.TargetAttr).Value,
                               Condition = x.Value
                           });

            if (rules != null)
            {
                ruleSettings = rules.ToList();
            }

            return ruleSettings;
        }

        private string GetTypeAttribute(XElement currentNode)
        {
            string type = string.Empty;                       

            XAttribute typeAttr = currentNode.Attribute(Constants.TypeAttr);

            // Get current node attribute if any
            if (typeAttr != null)
            {
                type = typeAttr.Value;
            }
            // Get group node attribute if any
            else
            {
                XElement groupNode = null;
                XElement parentNode = currentNode.Parent;

                if (parentNode != null && parentNode.Name == Constants.GroupNode)
                {
                    groupNode = parentNode;
                }

                if (groupNode != null)
                {
                    type = groupNode.Attribute(Constants.TypeAttr).Value;   
                }
            }

            return type;
        }
    }
}

