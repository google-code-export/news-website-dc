using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewsVn.Impl.Context;
using NewsVn.Web.Utils;
using System.IO;

namespace NewsVn.Web.Modules
{
    public partial class SiteAdmin_UpdateBannerDetail : BaseUI.SecuredModule
    {

        int intBannerId;
        protected void Page_Load(object sender, EventArgs e)
        {
            intBannerId = int.Parse(Request.QueryString["bannerid"]);
            if (!IsPostBack)
            {
                Utils.ApplicationKeyValueRef.BindingDataToComboBox(ddlPositionType, "Dropdown.BannerPosition");
                Utils.ApplicationKeyValueRef.BindingDataToComboBox(ddlObjectType, "Dropdown.BannerType");
                loadBannerDetail();
            }
        }

        private void loadBannerDetail()
        {
            using (var ctx = new NewsVnContext(Utils.ApplicationManager.ConnectionString))
            {
                var BannerDetail = ctx.BannerDetailRepo.Getter.getQueryable(c => c.ID == intBannerId)
                .Select(c => new
                {
                    c.ID,
                    c.Height,
                    c.Width,
                    c.Title,
                    c.Url,
                    c.CustomerName,
                    c.CustomerDescription,
                    c.Created,
                    c.LinkUrl,
                    c.Price,
                    c.TypeBanner,
                    c.Activated,
                    c.TypePosition
                }).First();

                txtHeight.Text = BannerDetail.Height.ToString() ;
                txtWidth.Text = BannerDetail.Width.ToString ();
                ddlPositionType.SelectedValue = BannerDetail.TypePosition.ToString();
                ddlObjectType.SelectedValue = BannerDetail.TypeBanner.ToString();
                txtUrl.Text = BannerDetail.Url;
                txtTitle.Text = BannerDetail.Title;
                txtCustomer.Text = BannerDetail.CustomerName;
                txtCustomerDesc.Text = BannerDetail.CustomerDescription;
                txtPrice.Text = BannerDetail.Price.ToString();
                txtUrlLinkTo.Text = BannerDetail.LinkUrl;
                lblCreated.Text = string.IsNullOrEmpty(BannerDetail.Created.ToString()) ? "" : BannerDetail.Created.ToString();
                chkActivated.Checked = BannerDetail.Activated;
                imgBanner.ImageUrl = BannerDetail.Url;
                imgBanner.DataBind();
            }
        }

        private bool uploadImg()
        {
            if (fileAvatar.HasFile)
            {
                try
                {
                    if (fileAvatar.PostedFile.ContentType.Contains("image"))
                    {
                        if (fileAvatar.PostedFile.ContentLength < 1024000)
                        {
                            //file [image name]
                            string filename = Path.GetFileName(fileAvatar.FileName);
                            //create folder if it does not exists
                            string subPath = "Resources/Ads"; // your code goes here
                            bool IsExists = Directory.Exists(Server.MapPath("~/"+subPath));
                            if (!IsExists)
                                Directory.CreateDirectory(Server.MapPath(subPath));
                            fileAvatar.SaveAs(Server.MapPath("~/" + subPath) + "/" + filename);
                            txtUrl.Text = HostName + subPath + "/" + filename;
                            imgBanner.ImageUrl = HostName + subPath + "/" + filename;
                            return true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    ltrError.Text = ex.Message.ToString();
                    return false;
                }
            }
            return false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            uploadImg();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ctx = new NewsVnContext(Utils.ApplicationManager.ConnectionString))
                {
                    var Banner = ctx.BannerDetailRepo.Getter.getOne(p => p.ID == intBannerId);

                    if (Banner != null)
                    {
                        Banner.TypeBanner = int.Parse(ddlObjectType.SelectedValue);
                        Banner.TypePosition = int.Parse(ddlPositionType.SelectedValue);
                        Banner.Width = int.Parse(txtWidth.Text);
                        Banner.Height = int.Parse(txtHeight.Text);
                        Banner.Title = txtTitle.Text;
                        Banner.Url = txtUrl.Text;
                        Banner.LinkUrl = string.IsNullOrEmpty(txtUrlLinkTo.Text) ? "" : txtUrlLinkTo.Text.Trim();
                        Banner.Created = DateTime.Now;
                        Banner.Price = decimal.Parse(string.IsNullOrEmpty(txtPrice.Text) ? "0" : txtPrice.Text.Trim());
                        Banner.CustomerName = string.IsNullOrEmpty(txtCustomer.Text) ? "" : txtCustomer.Text.Trim();
                        Banner.CustomerDescription = string.IsNullOrEmpty(txtCustomerDesc.Text) ? "" : txtCustomerDesc.Text.Trim();
                        Banner.Activated = chkActivated.Checked;
                        ctx.SubmitChanges();

                        Response.Redirect(HostName + "account/siteadmin/misc/ViewAdBox.aspx");
                    }
                }
            }
            catch
            {
            }
        }
    }
}