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
                using (var ctx = new NewsVnContext(Utils.ApplicationManager.ConnectionString))
                {
                    //check status of AutoFetchPost / allow or not allow button set auto Mode
                    var AutoFetchPostIsRunning = ctx.SettingRepo.Getter.getQueryable(c => c.Name == "AutoFetchPostIsRunning").FirstOrDefault();
                    if (AutoFetchPostIsRunning != null)
                    {
                        lnkbtnAutoMode.Visible = AutoFetchPostIsRunning.Value == "True" ? false : true;
                        lnkbtnOffAutoMode.Visible = AutoFetchPostIsRunning.Value == "True" ? true : false;
                        //
                        btnGetPostList.Enabled = AutoFetchPostIsRunning.Value == "True" ? false : true;
                        btnAddPostItems.Enabled = AutoFetchPostIsRunning.Value == "True" ? false : true;
                        ddlFetchCategory.Enabled = AutoFetchPostIsRunning.Value == "True" ? false : true;
                        ddlFetchSite.Enabled = AutoFetchPostIsRunning.Value == "True" ? false : true;
                        int setting=int.Parse(System.Configuration.ConfigurationManager.AppSettings["AutoPostFetch_TimeValue"].ToString())/1000;

                        lblCurrentSetting.Text = (setting / 3600).ToString();
                    }
                }
                BindSitesDropDown();
                BindCategoriesDropDown();
                ltrInfo.Text = string.Format(InfoBar, "Vui lòng nhấn '<b>Lấy tin</b>' để hiện danh sách.");
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
            IList<PostItemModel> postList = new List<PostItemModel>();
            
            if (_service != null)
            {
                int selectedSiteID = 0;
                int.TryParse(ddlFetchSite.SelectedValue, out selectedSiteID);

                int selectedCategoryID = 0;
                int.TryParse(ddlFetchCategory.SelectedValue, out selectedCategoryID);

                var setting = _service.RequestSetting(selectedSiteID, selectedCategoryID);

                if (setting != null)
                {
                    using (var ctx = new NewsVnContext(Utils.ApplicationManager.ConnectionString))
                    {
                        postList = _service.RequestPostItemList(setting, ctx);
                    }                    
                }
            }

            if (postList.Count > 0)
            {
                rptPostList.DataSource = postList;
            }
            else
            {
                rptPostList.DataSource = null;
                ltrInfo.Text = string.Format(InfoBar, "Danh sách không tồn tại tin nào hoặc tin đã được cập nhật");
            }
            rptPostList.DataBind();
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
            ltrInfo.Text = string.Format(InfoBar, "Vui lòng nhấn '<b>Lấy tin</b>' để hiện danh sách.");
        }

        protected void ddlFetchCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            rptPostList.DataSource = null;
            rptPostList.DataBind();
            ltrInfo.Text = string.Format(InfoBar, "Vui lòng nhấn '<b>Lấy tin</b>' để hiện danh sách.");        
        }

        protected void btnGetPostList_Click(object sender, EventArgs e)
        {
            try
            {
                BindPostListRepeater();
            }
            catch (Exception ex)
            {
                ltrError.Text = string.Format(ErrorBar, "Có lỗi xảy ra trong quá trình lấy tin" + ex.Message.ToString());
            }
        }

        protected void btnAddPostItems_Click(object sender, EventArgs e)
        {
            try
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
                                    var hidAvatar = item.FindControl("hidAvatar") as HiddenField;

                                    postItem.Url = itemUrl;
                                    postItem.Avatar = hidAvatar.Value;
                                    if (string.IsNullOrEmpty(postItem.Avatar))
                                    {
                                        postItem.Avatar = HostName + "resources/images/no_image/no-ads.gif";
                                    }
                                    postItem.TargetID = targetID;
                                    bool success = _service.AddPostItem(postItem, ctx);
                                }
                            }
                        }
                        ctx.SubmitChanges();

                        BindPostListRepeater();

                        ltrInfo.Text = string.Format(InfoBar, "Đã cập nhập thành công tin đã chọn");
                    }
                }
            }
            catch (Exception)
            {
                ltrError.Text = string.Format(ErrorBar, "Có lỗi xảy ra trong quá trình cập nhật tin");
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
                if (e.Item.ItemType == ListItemType.Header)
                {
                    var ltrListName = e.Item.FindControl("ltrListName") as Literal;
                    ltrListName.Text = ddlFetchSite.SelectedItem.Text + " - " + ddlFetchCategory.SelectedItem.Text;
                }
            }
            catch (Exception)
            {
                
            }
        }

        protected void lnkbtnAutoMode_Click(object sender, EventArgs e)
        {
            SwitchAutoMode("True");
        }

        protected void lnkbtnOffAutoMode_Click(object sender, EventArgs e)
        {
            SwitchAutoMode("False");
        }

        protected void SwitchAutoMode(string allow) {
            //Turn the autoFetchPost to off status
            using (var ctx = new NewsVnContext(Utils.ApplicationManager.ConnectionString))
            {
                //check status of AutoFetchPost / allow or not allow!
                var AutoFetchPostIsRunning = ctx.SettingRepo.Getter.getQueryable(c => c.Name == "AutoFetchPostIsRunning").FirstOrDefault();
                if (AutoFetchPostIsRunning != null)
                {
                    if (AutoFetchPostIsRunning.Value == "True")
                    {
                        AutoFetchPostIsRunning.Value = allow;//off=false ? on=true
                        ctx.SubmitChanges();
                    }
                }
            }
            Response.Redirect(Request.Url.ToString());
        }
    }
    
}