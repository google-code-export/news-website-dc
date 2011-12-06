using System;
using System.Collections.Generic;
using System.IO;
using NewsVn.Impl.PostFetch;
using NewsVn.Impl.PostFetch.Settings;

namespace NewsVn.Web.Account.SiteAdmin.Post
{
    public partial class AutoFetchPost : BaseUI.SecuredPage
    {
        private readonly ISettingReader _settingReader;
        
        private IList<SiteSetting> _siteSettings;

        public AutoFetchPost()
        {
            string xmlPath = Server.MapPath("~/Config/PostFetchSites.xml");
            var xmlFile = new FileInfo(xmlPath);

            if (xmlFile.Exists)
            {
                _settingReader = new XmlSettingReader(xmlPath);
            }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            this.SiteTitle += "Lấy tin tự động";
        }

        /// <summary>
        /// Inits site settings from SettingReader
        /// </summary>
        private void InitSiteSettings()
        {
            if (_settingReader != null)
            {
                
            }
        }

        /// <summary>
        /// Binds site list to dropdown
        /// </summary>
        private void BindSitesDropDown()
        {
            if (_siteSettings != null)
            {
                
            }
        }

        /// <summary>
        /// Binds category list to dropdown
        /// </summary>
        private void BindCategoriesDropDown()
        {
            if (_siteSettings != null)
            {

            }
        }

        /// <summary>
        /// Binds category from database to dropdowns
        /// </summary>
        public void BindTargetCategoriesDropDowns()
        {
            if (_siteSettings != null)
            {

            }
        }
    }
}