using System;
using System.Collections.Generic;
using System.IO;
using NewsVn.Impl.Context;
using NewsVn.Impl.PostFetch;
using NewsVn.Impl.PostFetch.Settings;
using System.Linq;
using NewsVn.Impl.PostFetch.Services;
using System.Web.UI.WebControls;
using NewsVn.Impl.PostFetch.Models;

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
        private void BindTargetCategoriesDropDowns(DropDownList ddlTargetCategory)
        {
            if (_service != null && ddlTargetCategory != null)
            {
                int selectedSiteID = 0;
                int.TryParse(ddlFetchSite.SelectedValue, out selectedSiteID);

                int selectedCategoryID = 0;
                int.TryParse(ddlFetchCategory.SelectedValue, out selectedCategoryID);

                var setting = _service.RequestSetting(selectedSiteID, selectedCategoryID);
                
                using (var ctx = new NewsVnContext(Utils.ApplicationManager.ConnectionString))
                {
                    var cates = ctx.CategoryRepo.Getter.getQueryable(c => c.Type.Trim().ToLower() == "post")
                        .OrderByDescending(c => c.Parent == null).ThenBy(c => c.Parent.Name);

                    foreach (var cate in cates)
                    {
                        if (cate.Parent == null)
                            ddlTargetCategory.Items.Add(new ListItem(cate.Name, cate.ID.ToString()));
                        else
                            ddlTargetCategory.Items.Add(new ListItem(cate.Parent.Name + " / " + cate.Name, cate.ID.ToString()));
                    }

                    // Set default to Target ID
                    var item = ddlTargetCategory.Items.FindByValue(setting.TargetID.ToString());
                    item.Selected = true;
                }
            }
        }

        protected void ddlFetchSite_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindCategoriesDropDown();
            rptPostList.DataSource = null;
            rptPostList.DataBind();
        }

        protected void ddlFetchCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            rptPostList.DataSource = null;
            rptPostList.DataBind();
        }

        protected void btnGetPostList_Click(object sender, EventArgs e)
        {
            BindPostListRepeater();
        }

        protected void btnAddPostItems_Click(object sender, EventArgs e)
        {
            if (_service != null)
            {
                int selectedSiteID = 0;
                int.TryParse(ddlFetchSite.SelectedValue, out selectedSiteID);

                int selectedCategoryID = 0;
                int.TryParse(ddlFetchCategory.SelectedValue, out selectedCategoryID);

                var setting = _service.RequestSetting(selectedSiteID, selectedCategoryID);

                using (var ctx = new NewsVnContext(Utils.ApplicationManager.ConnectionString))
                {
                    foreach (var item in rptPostList.Items.Cast<RepeaterItem>())
                    {
                        var chkAccept = item.FindControl("chkAccept") as CheckBox;

                        if (chkAccept.Checked)
                        {
                            var ddlTargetCategory = item.FindControl("ddlTargetCategory") as DropDownList;
                            int targetID = int.Parse(ddlTargetCategory.SelectedValue);

                            var hidGetUrl = item.FindControl("hidGetUrl") as HiddenField;
                            string itemUrl = hidGetUrl.Value;

                            var postItem = _service.RequestRawPostItem(itemUrl, setting);

                            if (postItem != null)
                            {
                                postItem.TargetID = targetID;
                                bool success = _service.AddPostItem(postItem, ctx);
                            }
                        }
                    }
                    ctx.SubmitChanges();
                }
            }
        }

        protected void rptPostList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    var ddlTargetCategory = e.Item.FindControl("ddlTargetCategory") as DropDownList;
                    BindTargetCategoriesDropDowns(ddlTargetCategory);

                    var postItem = e.Item.DataItem as PostItemModel;
                    if (postItem != null && string.IsNullOrEmpty(postItem.Avatar))
                    {
                        var imgAvatar = e.Item.FindControl("imgAvatar") as Image;
                        imgAvatar.ImageUrl = "~/resources/images/no_image/no-ads.gif";
                    }
                }
            }
            catch (Exception)
            {
                
            }
        }
    }
}