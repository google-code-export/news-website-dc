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
            base.OnInit(e);

            SiteTitle = "NewsVN - Cổng thông tin điện tử 24/07 ::: ";

            _Categories = ApplicationManager.Entities.Categories.Where(c => "post".Equals(c.Type, StringComparison.OrdinalIgnoreCase)).ToList().AsQueryable();
            _AdCategories = ApplicationManager.Entities.Categories.Where(c => "adpost".Equals(c.Type, StringComparison.OrdinalIgnoreCase)).ToList().AsQueryable();
            _VideoCategories = ApplicationManager.Entities.Categories.Where(c => "video".Equals(c.Type, StringComparison.OrdinalIgnoreCase)).ToList().AsQueryable();
            _Posts = ApplicationManager.Entities.Posts.AsQueryable();
        }
    }
}