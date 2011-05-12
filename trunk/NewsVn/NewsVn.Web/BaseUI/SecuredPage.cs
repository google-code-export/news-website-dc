using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewsVn.Web.Utils;

namespace NewsVn.Web.BaseUI
{
    public class SecuredPage : BasePage
    {
        protected override void OnInit(EventArgs e)
        {
            _Posts = ApplicationManager.Entities.Posts.ToList().AsQueryable();
        }
    }
}