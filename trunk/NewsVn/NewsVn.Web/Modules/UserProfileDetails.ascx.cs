using System;
using System.Collections.Generic;
using System.Linq;

namespace NewsVn.Web.Modules
{
    public partial class UserProfileDetails : BaseUI.BaseModule
    {
        public Impl.Entity.UserProfile Datasource { get; set; }
        //Sample property used only for building layout
        //Replace with real UserProfile.ShowEmail
        public bool ShowEmail { get; set; }
        //Sample property used only for building layout
        //Replace with real UserProfile.ShowPhone
        public bool ShowPhone { get; set; }
        //Use to set sample properties
        //used only for building layout
        public List<string> arr { get; set; }
        protected override void OnInit(EventArgs e)
        {
            Datasource = new Impl.Entity.UserProfile();
            
        }
        protected override void OnDataBinding(EventArgs e)
        {
            //<%--Every user has maximum 3 avatars, first avatar will be shown on profile list, if user didnt upload an avatar, use default 'No Photo' image in replace--%>
            //<%--In database, each image url will be separated by ';'--%>
            try
            {
                arr = Datasource.Avatar.Split(';').ToList();
                int count = arr.Count();
                while (count <= 2)
                {
                    arr.Add("/resources/Images/No_Image/no_avatar.jpg");
                    count++;
                }
                Image2.ImageUrl = arr[0];
                Image3.ImageUrl = arr[1];
                Image4.ImageUrl = arr[2];
            }
            catch (Exception)
            {

                Image2.ImageUrl = "/resources/Images/No_Image/no_avatar.jpg";
                Image3.ImageUrl = "/resources/Images/No_Image/no_avatar.jpg";
                Image4.ImageUrl = "/resources/Images/No_Image/no_avatar.jpg";
            }
           
            this.ShowEmail = Datasource.ShowEmail;
            this.ShowPhone = Datasource.ShowPhone;
        }
    }
}