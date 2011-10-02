using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsVn.Web.Modules
{
    public partial class UserConversationBox : BaseUI.BaseModule
    {
        public string CurrentAccount { get; set; }
        public object DataSource { get; set; }
        public ListView lvConversation;
        public Panel pnPagerConversationContainer;
        public DataPager dpConversation;
        
        protected void Page_Load(object sender, EventArgs e)
        {
        //    if (!IsPostBack)
        //    {
        //        this.LoadConversation();
        //    }
        }

        protected override void OnDataBinding(EventArgs e)
        {
            
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                lvConversation = lgConversation.FindControl("lvConversation") as ListView;
                pnPagerConversationContainer = lgConversation.FindControl("pnPagerConversationContainer") as Panel;
                dpConversation = lgConversation.FindControl("dpConversation") as DataPager;
                this.LoadConversation();
            }
            
        }

        private void LoadConversation()
        {
            try
            {
                lvConversation.DataSource = DataSource;
                lvConversation.DataBind();
            }
            catch (Exception)
            {
                
                //throw;
            }
            
        }

        protected void lvConversation_PagePropertiesChanged(object sender, EventArgs e)
        {
            LoadConversation();
        }

        protected void lvConversation_DataBound(object sender, EventArgs e)
        {
            pnPagerConversationContainer.Visible = dpConversation.PageSize < dpConversation.TotalRowCount;
        }


    }
}