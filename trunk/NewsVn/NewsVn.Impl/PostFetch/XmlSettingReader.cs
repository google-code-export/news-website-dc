using System.Collections.Generic;
using System.Xml.Linq;
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
			return null;
		}
		 
		/// <summary>
        /// Gets filter settings from XML
		/// </summary>
		/// <param name="parentNode"></param>
		/// <returns></returns>
		private IList<FilterSetting> GetFilterSettings(XElement parentNode)
		{
			return null;
		}
		 
		/// <summary>
        /// Gets rule settings from XML
		/// </summary>
		/// <param name="parentNode"></param>
		/// <returns></returns>
		private IList<RuleSetting> GetRuleSettings(XElement parentNode)
		{
			return null;
		}
		 
		/// <summary>
		/// @see NewsVn.Impl.PostFetch.ISettingReader#GetSiteSettings()
		/// </summary>
		/// <returns></returns>
        public IList<SiteSetting> GetSiteSettings()
		{
			return null;
		}
		 
		/// <summary>
        /// @see NewsVn.Impl.PostFetch.ISettingReader#GetCachedSiteSettings()
		/// </summary>
		/// <returns></returns>
		public IList<SiteSetting> GetCachedSiteSettings()
		{
			return null;
		}
		 
		/// <summary>
        /// @see NewsVn.Impl.PostFetch.ISettingReader#CacheSiteSettings()
		/// </summary>
		public void CacheSiteSettings()
		{
		    
		}
    }	 
}
 
