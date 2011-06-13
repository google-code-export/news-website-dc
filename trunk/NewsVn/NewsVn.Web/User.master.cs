using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewsVn.Impl.Context;

namespace NewsVn.Web
{
    public partial class User : BaseUI.BaseMaster
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Fix: thay <%= %> bang <%# %> sau do dung  Page.Header.DataBind();
                //Error: The Controls collection cannot be modified because the control contains code blocks (i.e. <% ... %>).
                Page.Header.DataBind();
                //Error--------------
                Generate_SeoMeta();
                Load_Menu();
                Load_FooterCate();
            }
        }
        
        public void Generate_SeoMeta()
        {
            Page.Header.Controls.Add(new LiteralControl("\n"));
            System.Web.UI.HtmlControls.HtmlMeta metaKeyWords = new System.Web.UI.HtmlControls.HtmlMeta();
            metaKeyWords.Name="Keywords";
            metaKeyWords.Content = MetaKeyWords;

            System.Web.UI.HtmlControls.HtmlMeta metaKeyDescription = new System.Web.UI.HtmlControls.HtmlMeta();
            metaKeyDescription.Name = "Description";
            metaKeyDescription.Content =  MetaKeyDes;

            Page.Header.Controls.Add(metaKeyWords);
            Page.Header.Controls.Add(new LiteralControl("\n"));
            Page.Header.Controls.Add(metaKeyDescription);

        }

        private void Load_Menu()
        {
            using (var ctx = new NewsVnContext(Utils.ApplicationManager.ConnectionString) )
            {
                var Catechildren = ctx.CategoryRespo.Getter.getQueryable(c => c.Parent != null && c.Type.Trim().ToLower() == "post");
                var CateList = ctx.CategoryRespo.Getter.getQueryable(c => c.Parent == null && c.Type.Trim().ToLower() == "post").Union(Catechildren);
                CtrMenu.Datasource = CateList;
                CtrMenu.DataBind();
            }
        }

        protected void Load_FooterCate()
        {
            using (var ctx = new NewsVnContext(Utils.ApplicationManager.ConnectionString))
            {
                //var Catechildren = ctx.CategoryRespo.Getter.getQueryable(c => c.Parent != null && c.Type.Trim().ToLower() == "post");
                var CateList = ctx.CategoryRespo.Getter.getQueryable(c => c.Parent == null && c.Type.Trim().ToLower() == "post")
                    .Select(c => new
               {
                   c.Name,
                   c.SeoName,
                   SeoUrl = HostName + c.SeoUrl,
                   c.ID,
                   //khong the thuc hien count toan bo item trong he thong dc/ bad performance
                   //Waston: Test thử với pattern mới
                   PostCount = this.CountChildCateFigures(c)
               }).ToList();
                CtrFooterCateList.Datasource = CateList;
                CtrFooterCateList.DataBind();
            }
        }

        private int CountChildCateFigures(Impl.Entity.Category cate)
        {
            using (var ctx = new NewsVnContext(Utils.ApplicationManager.ConnectionString))
            {
                int count = cate.Posts.Count;

                foreach (var child in cate.Children)
                {
                    count += child.Posts.Count;
                }

                return count;
            }
        }
    }
}