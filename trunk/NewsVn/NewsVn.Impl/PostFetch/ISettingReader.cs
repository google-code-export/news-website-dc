using System.Collections.Generic;
using NewsVn.Impl.PostFetch.Settings;

namespace NewsVn.Impl.PostFetch
{
    public interface ISettingReader
    {
        /// <summary>
        /// Gets site settings from configuration source
        /// </summary>
        /// <returns></returns>
        IList<SiteSetting> GetSiteSettings();

        /// <summary>
        /// Gets site settings from cache
        /// </summary>
        /// <returns></returns>
        IList<SiteSetting> GetCachedSiteSettings();

        /// <summary>
        /// Caches all settings to memory
        /// </summary>
        void CacheSiteSettings();
    }
}

