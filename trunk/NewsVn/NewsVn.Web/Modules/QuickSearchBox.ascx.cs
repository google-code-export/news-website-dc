﻿using System;

namespace NewsVn.Web.Modules
{
    public partial class QuickSearchBox : BaseUI.BaseModule
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void lnkbtnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(HostName + "tim-kiem/" + Server.UrlEncode( Utils.clsCommon.RemoveDangerousMarks(txtSearch.Text.Trim())) + ".aspx");
            //Response.Redirect(HostName + "tim-kiem/" + txtSearch.Text.Trim() + ".aspx");//PostSearchResult.aspx
        }
    }
}