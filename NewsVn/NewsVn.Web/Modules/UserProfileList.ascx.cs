using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace NewsVn.Web.Modules
{
    public partial class UserProfileList : BaseUI.BaseModule
    {
        public object DataSource { get; set; }        

        protected override void OnDataBinding(EventArgs e)
        {
            LoadUserProfiles();
        }

        protected void lvProfiles_DataBound(object sender, EventArgs e)
        {
            pagerProfilesContainer.Visible = pagerProfiles.PageSize < pagerProfiles.TotalRowCount;
        }

        protected void lvProfiles_PagePropertiesChanged(object sender, EventArgs e)
        {
            this.LoadUserProfiles();
        }

        private void LoadUserProfiles()
        {
            //Sample List used only for building layout
            //Replace with real data list
            lvProfiles.DataSource = DataSource;
            lvProfiles.DataBind();
        }
    }
}