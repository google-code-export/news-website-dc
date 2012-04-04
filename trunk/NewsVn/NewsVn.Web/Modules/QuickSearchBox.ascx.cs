using System;

namespace NewsVn.Web.Modules
{
    public partial class QuickSearchBox : BaseUI.BaseModule
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void lnkbtnSearch_Click(object sender, EventArgs e)
        {
            string search = "";
            //RemoveUnicodeMarks_Whitespace
            search = Utils.clsCommon.RemoveDangerousMarks(Utils.clsCommon.RemoveUnicodeMarks(txtSearch.Text.Trim()));
            Session["searchNews"] = txtSearch.Text.Trim();
            Response.Redirect(HostName + "tim-kiem/" + Server.UrlEncode(search) + ".aspx");
            
        }
    }
}