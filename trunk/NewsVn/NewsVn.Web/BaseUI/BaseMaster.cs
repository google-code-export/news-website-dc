using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewsVn.Data;
using NewsVn.Web;
using NewsVn.Web.Utils;
namespace NewsVn.Web.BaseUI
{
    public class BaseMaster : System.Web.UI.MasterPage
    {
        public string HostName { get; set; }
        public static string SiteTitle { get; set; }
        public static string MetaKeyWords { get; set; }
        public static string MetaKeyDes { get; set; }

        protected IQueryable<Data.Category> _Categories;

        protected override void OnInit(EventArgs e)
        {
            HostName = ApplicationManager.HostName;

            _Categories = ApplicationManager.SetCacheData<Data.Category>(ApplicationManager.Entities.Categories, p => p.Actived);
            
            base.OnInit(e);
        }
    }
}