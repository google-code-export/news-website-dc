﻿using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsVn.Web.Modules
{
    public partial class MenuBar : BaseUI.BaseModule
    {
        public IQueryable<Impl.Entity.Category> Datasource { get; set; }
        
        protected override void OnDataBinding(EventArgs e)
        {
            rptMenu.DataSource = Datasource.Where(c => c.Parent == null).ToList();
            rptMenu.DataBind();
        }

        protected void rptMenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType==ListItemType.Item ||e.Item.ItemType==ListItemType.AlternatingItem)
            {
                Repeater rptSubMenu = (Repeater)e.Item.FindControl("rptSubMenu");
                var subDatasource = Datasource.Where(c => c.Parent != null).Where(c => c.Parent.ID == (int)DataBinder.Eval(e.Item.DataItem, "ID"));
                rptSubMenu.DataSource = subDatasource;
                rptSubMenu.DataBind();
            }
        }
        
    }
}