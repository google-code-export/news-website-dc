using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewsVn.Web.Utils;

namespace NewsVn.Web.Modules
{
    public partial class CommentBox : System.Web.UI.UserControl
    {
        public int PostID { get; set; }

        public int ListPageSize { get; set; }
    }
}