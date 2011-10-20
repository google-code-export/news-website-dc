using System;
using System.Collections.Generic;

namespace NewsVn.Web.Modules
{
    public partial class CategorizedVideoList : BaseUI.BaseModule
    {
        public string CategoryName { get; set; }

        public List<Impl.Entity.Video> DataSource { get; set; }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rptVideoList.DataSource = this.DataSource;
                rptVideoList.DataBind();
            }
        }
    }
}