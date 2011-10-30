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
                    BannerPosition = ApplicationKeyValueRef.GetKeyValue("Dropdown.BannerPosition", c.BannerID.ToString())
                }).First();

                txtHeight.Text = BannerDetail.Height.ToString() ;
                txtWidth.Text = BannerDetail.Width.ToString ();
                txtPosition.Text = BannerDetail.BannerPosition;
                txtUrl.Text = BannerDetail.Url;
                txtTitle.Text = BannerDetail.Title;
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
                            bool IsExists = Directory.Exists(Server.MapPath(subPath));
                            if (!IsExists)
                                Directory.CreateDirectory(Server.MapPath(subPath));
                            fileAvatar.SaveAs(Server.MapPath("~/" + subPath) + "/" + filename);
                            txtUrl.Text = HostName + subPath + "/" + filename;
                            return true;
                        }
                    }
                }
                catch (Exception)
                {
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
                        Banner.Width = int.Parse(txtWidth.Text);
                        Banner.Height = int.Parse(txtHeight.Text);
                        Banner.Title = txtTitle.Text;
                        Banner.Url = txtUrl.Text;

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