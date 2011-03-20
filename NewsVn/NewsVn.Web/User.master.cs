using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            var CateList = _Categories.Where(c => c.Parent == null)
               .Union(_Categories.Where(c => c.Parent != null));
            CtrMenu.Datasource = CateList;
            CtrMenu.DataBind();
        }
       
        protected void Load_FooterCate()
        {
            var CateList = _Categories.Where(c => c.Parent == null )
               .Select(c => new
               {
                   c.Name,
                   c.SeoName, 
                   c.SeoUrl,
                   c.ID,
                   Figures = c.Posts.Count() + this.CountChildCateFigures(c)
               }).ToList();
            CtrFooterCateList.Datasource = CateList;
            CtrFooterCateList.DataBind();
        }

        private int CountChildCateFigures(Data.Category cate)
        {
            int count = 0;

            var childCates = _Categories.Where(c=> c.Parent != null && c.Parent.ID == cate.ID);
            
            foreach (var item in childCates)
            {
                count += item.Posts.Count();
            }
            
            return count;
        }
    }
}