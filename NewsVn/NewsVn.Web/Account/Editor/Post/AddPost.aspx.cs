﻿using System;

namespace NewsVn.Web.Account.Editor.Post
{
    public partial class AddPost : BaseUI.SecuredPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.SiteTitle += "Thêm tin mới";
        }
    }
}