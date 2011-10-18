using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq.Expressions;
using NewsVn.Impl;
using NewsVn.Impl.Context;
using NewsVn.Web.Utils;

namespace NewsVn.Web.Modules
{    
    public partial class SiteAdmin_FilterPost : System.Web.UI.UserControl
    {
        public delegate void FilteredEventHandler(object sender, ref Impl.Model.FilterModel filterModel);

        public event FilteredEventHandler Filtered;

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            var filterMethod = (Impl.Model.FilterMethod)Enum.Parse(typeof(Impl.Model.FilterMethod), ddlFilterMethod.SelectedValue, true);
            var filterChain = (Impl.Model.FilterChain)Enum.Parse(typeof(Impl.Model.FilterChain), ddlFilterChain.SelectedValue, true);

            var filterModel = new Impl.Model.FilterModel
            {
                Token = new Impl.Entity.Post
                {
                    Title = txtTitle.Text.Trim(),
                    Category = new Impl.Entity.Category
                    {
                        Name = txtCategoryName.Text.Trim()
                    }
                },
                Method = filterMethod,
                Chain = filterChain
            };

            OnFiltered(this, ref filterModel);
        }

        protected virtual void OnFiltered(object sender, ref Impl.Model.FilterModel filterModel)
        {
            if (Filtered != null) Filtered(sender, ref filterModel);
        }        
    }
}