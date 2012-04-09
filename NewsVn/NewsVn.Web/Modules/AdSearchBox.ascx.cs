using System;

namespace NewsVn.Web.Modules
{
    public partial class AdSearchBox : BaseUI.BaseModule
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ltrError.Text = string.Format(InfoBar, "");
            }
        }
               
        protected void lnkbtnSearchAd_Click(object sender, EventArgs e)
        {
            
            string SearchText = Server.UrlEncode(Utils.clsCommon.RemoveUnicodeMarks(Utils.clsCommon.RemoveDangerousMarks(txtSearch.Text.Trim()))).Replace('-',' ');
            
            if (SearchText == "" || SearchText == "tim rao vat")
            {
                txtSearch.Focus();
            }
            else
            {
                Session["searchAdPost"] = txtSearch.Text.Trim();
                string Region = ddlLocation.SelectedIndex.ToString();
                string dateFrom = ddlFollowday.SelectedItem.Value;
                string requestUrl = SearchText + "-" + Region + "-" + dateFrom;
                //Response.Redirect("SearchAdResult.aspx?searchtext=" + SearchText + "&region=" + Region + "&datefrom=" + dateFrom + "&dateto=" + dateTo);
                //Response.Redirect(HostName + "rao-nhanh/tim-kiem/" + requestUrl + ".aspx");
                Response.Redirect(HostName + "SearchAdResult.aspx?keysearch=" + requestUrl);
            }
          
        }
    }
}