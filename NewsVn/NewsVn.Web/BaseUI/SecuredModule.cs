using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewsVn.Web.Utils;

namespace NewsVn.Web.BaseUI
{
    public class SecuredModule : BaseModule
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            _Categories = ApplicationManager.SetCacheData<Data.Category>(ApplicationManager.Entities.Categories, p => p.Actived);
            _Posts = ApplicationManager.Entities.Posts.AsQueryable();
        }
    }
}