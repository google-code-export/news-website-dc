using System;

namespace NewsVn.Web.Modules
{
    public partial class AdSearchResult : BaseUI.SecuredModule
    {

        public object DataSource { get; set; }    

        protected override void OnDataBinding(EventArgs e)
        {
            this.LoadResultAds();
        }

        public string excuteAvatar(string pAvatar)
        {
            string Avatar = "";
            Avatar = pAvatar.Length == 0 ? "/resources/Images/No_Image/no-ads.gif" : HostName + pAvatar;
            return Avatar;
        }
        private void LoadResultAds()
        {
            lvAdResult.DataSource = DataSource;
            lvAdResult.DataBind();
        }
       
        protected void lvAdResult_PagePropertiesChanged(object sender, EventArgs e)
        {
            LoadResultAds();
        }

        protected void lvAdResult_DataBound(object sender, EventArgs e)
        {
            pnPagerAdContainer.Visible = dpAdResult.PageSize < dpAdResult.TotalRowCount;
        }

    }
}