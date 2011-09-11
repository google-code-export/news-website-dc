using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace NewsVn.Web.Modules
{
    public partial class ResultProfilesearchResult : System.Web.UI.UserControl
    {
        public object DataSource { get; set; }

        protected void Page_Load(object sender, EventArgs args)
        {
            if (!IsPostBack)
            {
                this.LoadResultProfiles();
            }
        }

        protected void lvResultProfiles_DataBound(object sender, EventArgs e)
        {
            pagerResultProfilesContainer.Visible = pagerResultProfiles.PageSize < pagerResultProfiles.TotalRowCount;
        }

        protected void lvResultProfiles_PagePropertiesChanged(object sender, EventArgs e)
        {
            this.LoadResultProfiles();
        }

        private void LoadResultProfiles()
        {
            ////Sample List used only for building layout
            ////Replace with real data list
            //var sampleList = new ArrayList();
            //for (int i = 0; i < 205; i++) sampleList.Add(i.ToString());

            //lvResultProfiles.DataSource = sampleList;
            //lvResultProfiles.DataBind();
            lvResultProfiles.DataSource = DataSource;
            lvResultProfiles.DataBind();
        }

    }
}