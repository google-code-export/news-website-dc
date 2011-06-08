﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsVn.Web.Modules
{
    public partial class CategorizedVideoList : BaseUI.BaseModule
    {
        public string CategoryName { get; set; }

        public List<Data.Video> DataSource { get; set; }
        
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