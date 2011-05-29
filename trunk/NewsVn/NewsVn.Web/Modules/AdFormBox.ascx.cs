using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewsVn.Web.Utils;
using System.IO;

namespace NewsVn.Web.Modules
{
    public partial class AdFormBox : BaseUI.BaseModule
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlCategory.DataSource = ApplicationManager.Entities.AdCategories.Where(c => c.Actived == true)
                    .Select(c => new
                    {
                        c.ID,
                        Name = c.Parent == null ? c.Name : c.Parent.Name + " - " + c.Name
                    }).OrderBy(c => c.Name).ToList();
                ddlCategory.DataTextField = "Name";
                ddlCategory.DataValueField = "ID";
                ddlCategory.DataBind();
            }
        }

        protected void btnSubmitAdPost_Click(object sender, EventArgs e)
        {
            try
            {
                Data.AdPost adsPost = new Data.AdPost();
                adsPost.Title = txtTitle.Text.Trim();
                adsPost.Content = txtContent.Text.Trim();
                adsPost.Avatar = "Ads/" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + "/" + fileAvatar.FileName;
                adsPost.SeoUrl = "";
                adsPost.AdCategory = _AdCategories.FirstOrDefault(c => c.ID == int.Parse(ddlCategory.SelectedValue));
                adsPost.Location = ddlLocation.SelectedValue;
                adsPost.Contact = txtContact.Text.Trim();
                adsPost.ContactEmail = txtContactEmail.Text.Trim();
                adsPost.ContactAddress = txtContactAddress.Text.Trim();
                adsPost.ContactPhone = txtContactPhone.Text.Trim();
                adsPost.CreatedOn = DateTime.Now;
                adsPost.CreatedBy = txtContact.Text.Trim();
                adsPost.ExpiredOn = DateTime.Now.AddDays(3);//setting day expired from created day
                adsPost.Actived = true;
                uploadImg();

                ApplicationManager.Entities.AddToAdPosts(adsPost);
                ApplicationManager.Entities.SaveChanges();
                ApplicationManager.UpdateCacheData<Data.AdPost>(ApplicationManager.Entities.AdPosts.Where(p => p.Actived == true && p.ExpiredOn >= DateTime.Now));
                var data = _AdCategories.FirstOrDefault(c => c.ID == int.Parse(ddlCategory.SelectedValue));
                    //.Select(p => new {p.SeoUrl }).FirstOrDefault();
                Response.Redirect("AdSubCategory.aspx?ct=" + data.SeoUrl);
                
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
                            string subPath ="Resources/Ads/"+ DateTime.Now.Month.ToString()+"_"+ DateTime.Now.Year.ToString(); // your code goes here
                            bool IsExists = Directory.Exists(Server.MapPath(subPath));
                            if (!IsExists)
                                Directory.CreateDirectory(Server.MapPath(subPath));
                            fileAvatar.SaveAs(Server.MapPath( subPath+"/") + filename);
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