using System;
using System.Collections.Generic;
using System.IO;
using NewsVn.Impl.PostFetch;
using NewsVn.Impl.PostFetch.Settings;
using System.Linq;
using NewsVn.Impl.PostFetch.Services;

namespace NewsVn.Web.Account.SiteAdmin.Post
{
    public partial class AutoFetchPost : BaseUI.SecuredPage
    {
        private readonly ISettingReader _settingReader;
        private readonly PostFetchServiceAbstract _service;
        
        private IList<SiteSetting> _siteSettings;

        public AutoFetchPost()
        {
            string xmlPath = Server.MapPath("~/Config/PostFetchSites.xml");
            var xmlFile = new FileInfo(xmlPath);

            if (xmlFile.Exists)
            {
                _settingReader = new XmlSettingReader(xmlPath);
                _service = new DefaultPostFetchService(_settingReader);
            }            
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            this.SiteTitle += "Lấy tin tự động";

            InitSiteSettings();

            if (!IsPostBack)
            {                
                BindSitesDropDown();
                BindCategoriesDropDown();
            }
        }

        /// <summary>
        /// Inits site settings from SettingReader
        /// </summary>
        private void InitSiteSettings()
        {
            if (_settingReader != null)
            {
                _siteSettings = _settingReader.GetSiteSettings();
            }
        }

        /// <summary>
        /// Binds site list to dropdown
        /// </summary>
        private void BindSitesDropDown()
        {
            if (_siteSettings != null)
            {
                ddlFetchSite.DataSource = _siteSettings;
                ddlFetchSite.DataTextField = "Name";
                ddlFetchSite.DataValueField = "ID";
                ddlFetchSite.DataBind();
            }
        }

        /// <summary>
        /// Binds category list to dropdown
        /// </summary>
        private void BindCategoriesDropDown()
        {
            if (_siteSettings != null)
            {
                int selectedSiteID = 0;
                int.TryParse(ddlFetchSite.SelectedValue, out selectedSiteID);
                
                var siteSetting = _siteSettings.FirstOrDefault(x => x.ID == selectedSiteID);

                if (siteSetting != null)
                {
                    ddlFetchCategory.DataSource = siteSetting.Categories;
                    ddlFetchCategory.DataTextField = "Name";
                    ddlFetchCategory.DataValueField = "ID";
                    ddlFetchCategory.DataBind();
                }
            }
        }

        private void BindPostListRepeater()
        {
            if (_service != null)
            {
                int selectedSiteID = 0;
                int.TryParse(ddlFetchSite.SelectedValue, out selectedSiteID);

                int selectedCategoryID = 0;
                int.TryParse(ddlFetchCategory.SelectedValue, out selectedCategoryID);

                var setting = _service.RequestSetting(selectedSiteID, selectedCategoryID);

                if (setting != null)
                {
                    rptPostList.DataSource = _service.RequestPostItemList(setting);
                    rptPostList.DataBind();
                }
            }
        }

        /// <summary>
        /// Binds category from database to dropdowns
        /// </summary>
        private void BindTargetCategoriesDropDowns()
        {
            if (_siteSettings != null)
            {

            }
        }

        protected void ddlFetchSite_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindCategoriesDropDown();
        }

        protected void btnGetPostList_Click(object sender, EventArgs e)
        {
            BindPostListRepeater();
        }

        protected void btnAddPostItems_Click(object sender, EventArgs e)
        {

        }
    }
}