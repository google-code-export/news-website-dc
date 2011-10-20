﻿using System;
using System.Collections.Generic;

namespace NewsVn.Web.Modules
{
    public partial class NewVideoPortlet : BaseUI.BaseModule
    {
        public List<Impl.Entity.Video> DataSource { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rptVideoList.DataSource = this.DataSource;
                rptVideoList.DataBind();
            }
        }
    }
}