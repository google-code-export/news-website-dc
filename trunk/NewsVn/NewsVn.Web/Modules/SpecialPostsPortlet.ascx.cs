using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsVn.Web.Modules
{
    public partial class SpecialPostsPortlet : BaseUI.BaseModule
    {
        public List<Data.Post> DataSource { get; set; }

        protected override void OnDataBinding(EventArgs e)
        {
            rptHotNews.DataSource = DataSource;
            rptHotNews.DataBind();
           
        }
    }
}