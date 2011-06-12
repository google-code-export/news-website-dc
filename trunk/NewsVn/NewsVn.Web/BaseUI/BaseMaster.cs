using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewsVn.Data;
using NewsVn.Web;
using NewsVn.Web.Utils;
using System.Text;
namespace NewsVn.Web.BaseUI
{
    public class BaseMaster : System.Web.UI.MasterPage
    {
        public string HostName { get; set; }
        public static string SiteTitle { get; set; }
        public static string MetaKeyWords { get; set; }
        public static string MetaKeyDes { get; set; }

        //protected IQueryable<Data.Category> _Categories;
        //protected IQueryable<Data.Post> _Posts;

        protected override void OnInit(EventArgs e)
        {
            HostName = ApplicationManager.HostName;

            //_Categories = ApplicationManager.Entities.Categories.Where(c => "post".Equals(c.Type, StringComparison.OrdinalIgnoreCase) && c.Actived).ToList().AsQueryable();
            //_Posts = ApplicationManager.Entities.Posts.Where(p => p.Approved && p.Actived && p.Category.Actived);
            base.OnInit(e);
        }
        public static void ExecuteSEO(string title, string metaKeyWords, string metaDes)
        {
            SiteTitle = "- " + title;
            MetaKeyWords = metaKeyWords.Length <= 0 ? "NewsVn,Vietnam news daily,24/7,online,economic,internet,ads,education,rao vat,quang cao,tin hot,tu van,viec lam,works,tim ban,blog,tin tuc,sai gon,ha noi,da nang,du lich,dien anh" : metaKeyWords;
            MetaKeyDes = metaDes.Length <= 0 ? "Cổng thông tin điện tử - thông tin nhanh, chính xác được đăng tải liên tục 24/07 thông tin Việt nam - Thế giới về Kinh tế" : metaDes;
        }
    }
}