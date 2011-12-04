using System;
using System.IO;
using NewsVn.Impl.Context;

namespace NewsVn.Web.Modules
{
    public partial class SiteAdmin_AddNewBanner : BaseUI.SecuredModule
    {
        int intPositionID;
        int intTypeID;
        protected void Page_Load(object sender, EventArgs e)
        {
            intPositionID = int.Parse( Request.QueryString["pid"]);
            intTypeID = int.Parse(Request.QueryString["tid"]);
            if (!IsPostBack)
            {
                imgBanner.ImageUrl = HostName + "Resources/Images/No_Image/no-ads.gif";
                Utils.ApplicationKeyValueRef.BindingDataToComboBox(ddlPositionType, "Dropdown.BannerPosition");
                Utils.ApplicationKeyValueRef.BindingDataToComboBox(ddlObjectType, "Dropdown.BannerType");
            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ctx = new NewsVnContext(Utils.ApplicationManager.ConnectionString))
                {
                    var bannerdtl = new Impl.Entity.BannerDetail
                    {
                        TypeBanner = int.Parse(ddlObjectType.SelectedValue),
                        TypePosition = int.Parse(ddlPositionType.SelectedValue),
                        BannerID = intPositionID,
                        Width = int.Parse(txtWidth.Text),
                        Height = int.Parse(txtHeight.Text),
                        Title = txtTitle.Text,
                        Url = txtUrl.Text,
                        LinkUrl = string.IsNullOrEmpty(txtUrlLinkTo.Text) ? "" : txtUrlLinkTo.Text.Trim(),
                        Created = DateTime.Now,
                        Price = decimal.Parse(string.IsNullOrEmpty(txtPrice.Text) ? "0" : txtPrice.Text.Trim()),
                        CustomerName = string.IsNullOrEmpty(txtCustomer.Text) ? "" : txtCustomer.Text.Trim(),
                        CustomerDescription = string.IsNullOrEmpty(txtCustomerDesc.Text) ? "" : txtCustomerDesc.Text.Trim(),
                        Activated = chkActivated.Checked
                    };

                    ctx.BannerDetailRepo.Setter.addOne(bannerdtl);

                    ctx.SubmitChanges();

                    Response.Redirect(HostName + "account/siteadmin/misc/ViewAdBox.aspx");
                }
            }
            catch
            {
            }
        }
        private bool uploadImg()
        {
            if (fileAvatar.HasFile)
            {
                try
                {
                    if (fileAvatar.PostedFile.ContentType.Contains ("image"))
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
                            fileAvatar.SaveAs( Server.MapPath("~/" + subPath) + "/" + filename);
                            txtUrl.Text =HostName+ subPath +"/"+ filename;
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
    }
}