using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsVn.Web.Modules
{
    public partial class DetailedAdPostItem : System.Web.UI.UserControl
    {
        public string AdsTitle { get; set; }
        public string AdsContent { get; set; }
        public string CreateBy { get; set; }
        public int Location { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}