using System;
using System.IO;
using System.Linq;
using NewsVn.Impl.Context;
using NewsVn.Web.Utils;

namespace NewsVn.Web.Modules
{
    public partial class AdFormBox : BaseUI.BaseModule
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
                {
                    ddlCategory.DataSource = ctx.CategoryRepo.Getter.getQueryable(c => c.Type=="adpost" && c.Actived == true)
                        .Select(c => new
                    {
                        c.ID,
                        Name = c.Parent == null ? c.Name : c.Parent.Name + " - " + c.Name
                    }).OrderBy(c => c.Name);
                    ddlCategory.DataTextField = "Name";
                    ddlCategory.DataValueField = "ID";
                    ddlCategory.DataBind();
                }
            }
        }

        protected void btnSubmitAdPost_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
                {
                    var adsPost = new Impl.Entity.AdPost();
                    adsPost.Title = txtTitle.Text.Trim();
                    adsPost.Content = txtContent.Text.Trim();
                    adsPost.Avatar = "Ads/" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + "/" + fileAvatar.FileName;
                    adsPost.SeoUrl = "";
                    adsPost.Category = ctx.CategoryRepo.Getter.getOne(c => c.ID == int.Parse(ddlCategory.SelectedValue));
                    adsPost.Location = ddlLocation.SelectedValue;
                    adsPost.Contact = txtContact.Text.Trim();
                    adsPost.ContactEmail = txtContactEmail.Text.Trim();
                    adsPost.ContactAddress = txtContactAddress.Text.Trim();
                    adsPost.ContactPhone = txtContactPhone.Text.Trim();
                    adsPost.CreatedOn = DateTime.Now;
                    adsPost.CreatedBy = txtContact.Text.Trim();
                    adsPost.UpdatedOn = DateTime.Now;
                    adsPost.UpdatedBy = txtContact.Text.Trim();
                    // setting day expired from created day
                    //adsPost.ExpiredOn = DateTime.Now.AddDays(3);
                    // CuongNguyen: Currently, there's no expriration
                    // therefore, add an amount of 100 years ahead
                    adsPost.ExpiredOn = DateTime.Now.AddYears(100);
                    adsPost.Actived = true;
                    uploadImg();

                    ctx.AdPostRepo.Setter.addOne(adsPost);
                    
                    adsPost.SeoUrl = string.Format("rao-nhanh-chi-tiet/{0}/{1}", adsPost.ID, clsCommon.RemoveUnicodeMarks(adsPost.Title));
                    
                    ctx.SubmitChanges();


                    var data = ctx.CategoryRepo.Getter.getOne(c => c.ID == int.Parse(ddlCategory.SelectedValue));
                    Response.Redirect(HostName + data.SeoUrl);
                }
            }
            catch (Exception)
            {

            }
        }
        private bool uploadImg()
        {
            if (fileAvatar.HasFile)
            {
                try
                {
                    if (fileAvatar.PostedFile.ContentType == "image/jpeg")
                    {
                        if (fileAvatar.PostedFile.ContentLength < 1024000)
                        {
                            //file [image name]
                            string filename = Path.GetFileName(fileAvatar.FileName);
                            //create folder if it does not exists
                            string subPath = "Resources/Ads/" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString(); // your code goes here
                            bool IsExists = Directory.Exists(Server.MapPath(subPath));
                            if (!IsExists)
                                Directory.CreateDirectory(Server.MapPath(subPath));
                            fileAvatar.SaveAs(Server.MapPath(subPath + "/") + filename);
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
    }
}