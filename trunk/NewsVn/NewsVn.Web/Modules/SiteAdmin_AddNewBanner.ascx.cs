using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewsVn.Web.Utils;
using NewsVn.Impl.Context;
using System.IO;

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
                txtPosition.Text = ApplicationKeyValueRef.GetKeyValue("Dropdown.BannerPosition", intPositionID.ToString());
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
                        BannerID = intPositionID,
                        Width = int.Parse(txtWidth.Text),
                        Height = int.Parse(txtHeight.Text),
                        Title = txtTitle.Text,
                        Url = txtUrl.Text
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
                            bool IsExists = Directory.Exists(Server.MapPath(subPath));
                            if (!IsExists)
                                Directory.CreateDirectory(Server.MapPath(subPath));
                            fileAvatar.SaveAs(Server.MapPath("~/" + subPath) + "/" + filename);
                            txtUrl.Text =HostName+ subPath +"/"+ filename;
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
    }
}