using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsVn.Web.Modules
{
    public partial class AdSearchBox : BaseUI.BaseModule
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
               
        protected void lnkbtnSearchAd_Click(object sender, EventArgs e)
        {
            string SearchText = Server.UrlEncode(Utils.clsCommon.RemoveUnicodeMarks(Utils.clsCommon.RemoveDangerousMarks(txtSearch.Text.Trim()))).Replace('-',' ');
            string Region = ddlLocation.SelectedIndex.ToString ();
            string dateFrom = txtAdFromDate.Text.Replace("/","_");
            string dateTo = txtAdToDate.Text.Replace("/", "_");
            string requestUrl = SearchText + "-" + Region + "-" + dateFrom + "-" + dateTo;
            //Response.Redirect("SearchAdResult.aspx?searchtext=" + SearchText + "&region=" + Region + "&datefrom=" + dateFrom + "&dateto=" + dateTo);
            Response.Redirect(HostName + "rao-nhanh/tim-kiem/" + requestUrl + ".html");
        }
    }
}