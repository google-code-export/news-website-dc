using System;
using System.Web.UI.WebControls;

namespace NewsVn.Web.Modules
{
    public partial class UserProfileList : BaseUI.BaseModule
    {
        public object Datasource { get; set; }
        public string MyProperty { get; set; }
        protected void Page_Load(object sender, EventArgs args)
        {
            if (!IsPostBack)
            {
                this.LoadUserProfiles();
            }
        }
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
            lvProfiles.DataSource = Datasource;
            lvProfiles.DataBind();
        }

        protected void lvProfiles_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            
            //if (e.Item.ItemType==ListViewItemType.DataItem )
            //{
            //    ListViewDataItem Item = (ListViewDataItem)(e.Item);
            //    Image img = (Image)e.Item.FindControl("Image1");
            //    var test= Item.GetType().GetProperties();
                
            //}
        }
    }
}