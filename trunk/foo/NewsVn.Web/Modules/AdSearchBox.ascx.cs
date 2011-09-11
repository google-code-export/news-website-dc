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
            string SearchText = Server.UrlEncode(Utils.clsCommon.RemoveUnicodeMarks(Utils.clsCommon.RemoveDangerousMarks(txtSearch.Text.Trim())));
            string Region = ddlLocation.SelectedIndex.ToString ();
            string dateFrom = txtAdFromDate.Text;
            string dateTo = txtAdToDate.Text;
            Response.Redirect("SearchAdResult.aspx?searchtext=" + SearchText + "&region=" + Region + "&datefrom=" + dateFrom + "&dateto="+dateTo );
            //string dateFrom = txtAdFromDate.Text.Replace("/", "-");
            //string dateTo = txtAdToDate.Text.Replace("/", "-");
            //Response.Redirect("~/rao-nhanh/tim-kiem/" + SearchText + "/" + Region + "/" + dateFrom + "/" + dateTo);
        }
    }
}