﻿using System;

namespace NewsVn.Web.Modules
{
    public partial class Account_LoginBar : BaseUI.SecuredModule
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lsNewsVn_LoggedOut(object sender, EventArgs e)
        {
            Session.Clear();
        }
    }
}