using System;
using NewsVn.Web.Utils;

namespace NewsVn.Web.Modules
{
    public partial class DetailedAdPostItem : System.Web.UI.UserControl
    {
        public string AdsTitle { get; set; }
        public string Avatar { get; set; }
        public string AdsContent { get; set; }
        public string CreateBy { get; set; }
        public int Location { get; set; }
        public DateTime CreatedOn { get; set; }
        protected void Page_Load(object sender, EventArgs e)

        {
            if (!IsPostBack)
            {
                Image1.ImageUrl = ApplicationManager.HostName+ "images/icons/facebook.png";
                Image2.ImageUrl = ApplicationManager.HostName + "images/icons/twitter.png";
                Image3.ImageUrl = ApplicationManager.HostName + "images/icons/facebook.png";
                Image4.ImageUrl = ApplicationManager.HostName + "images/icons/twitter.png";
            }    
        }
    }
    
}