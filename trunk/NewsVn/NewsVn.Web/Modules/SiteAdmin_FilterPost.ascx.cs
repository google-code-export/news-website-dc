using System;
using NewsVn.Impl.Model;
using System.Collections.Generic;

namespace NewsVn.Web.Modules
{    
    public partial class SiteAdmin_FilterPost : BaseUI.SecuredModule
    {
        public delegate void FilteredEventHandler(object sender, Func<Impl.Entity.Post, bool> predicate, FilterModel model);
        
        public event FilteredEventHandler Filtered;

        protected DateTime? UpdatedOn
        {
            get
            {
                DateTime updatedOn = DateTime.Now;
                if (!DateTime.TryParse(txtUpdatedOn.Text, out updatedOn))
                {
                    return null;
                }
                return updatedOn;
            }
        }

        protected DateTime? ApprovedOn
        {
            get
            {
                DateTime approvedOn = DateTime.Now;
                if (!DateTime.TryParse(txtApprovedOn.Text, out approvedOn))
                {
                    return null;
                }
                return approvedOn;
            }
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            Func<Impl.Entity.Post, bool> predicate = p => true;
            
            var method = (FilterMethod)Enum.Parse(typeof(FilterMethod), ddlFilterMethod.SelectedValue, true);
            var chain = (FilterChain)Enum.Parse(typeof(FilterChain), ddlFilterChain.SelectedValue, true);

            var token = new Impl.Entity.Post
            {
                Title = txtTitle.Text,                
                Category = new Impl.Entity.Category
                {
                    Name = txtCategoryName.Text
                },
                UpdatedBy = txtUpdatedBy.Text,
                UpdatedOn =  this.UpdatedOn,
                ApprovedBy = txtApprovedBy.Text.Trim(),
                ApprovedOn = this.ApprovedOn
            };

            var model = new FilterModel
            {
                Token = token,
                Data = new Dictionary<string, object>
                {
                    {"ManagePost_FilterMethod", ddlFilterMethod.SelectedItem.Text},
                    {"ManagePost_FilterChain", ddlFilterChain.SelectedItem.Text}
                }
            };

            if (method == FilterMethod.Absolute && chain == FilterChain.LinkAll)
            {
                predicate = p => CheckStringCompare(p.Title, token.Title)
                    && CheckStringCompare(p.Category.Name, token.Category.Name)
                    && CheckStringCompare(p.UpdatedBy, token.UpdatedBy)
                    && CheckDateExact(p.UpdatedOn, token.UpdatedOn)
                    && CheckStringCompare(p.ApprovedBy, token.ApprovedBy)
                    && CheckDateExact(p.ApprovedOn, token.ApprovedOn);
            }
            if (method == FilterMethod.Absolute && chain == FilterChain.LinkOne)
            {
                predicate = p => CheckStringCompare(p.Title, token.Title)
                    || CheckStringCompare(p.Category.Name, token.Category.Name)
                    || CheckStringCompare(p.UpdatedBy, token.UpdatedBy)
                    || CheckDateExact(p.UpdatedOn, token.UpdatedOn)
                    || CheckStringCompare(p.ApprovedBy, token.ApprovedBy)
                    || CheckDateExact(p.ApprovedOn, token.ApprovedOn);
            }
            if (method == FilterMethod.Relative && chain == FilterChain.LinkAll)
            {
                predicate = p => CheckStringContain(p.Title, token.Title)
                    && CheckStringContain(p.Category.Name, token.Category.Name)
                    && CheckStringContain(p.UpdatedBy, token.UpdatedBy)
                    && CheckDateEarly(p.UpdatedOn, token.UpdatedOn)
                    && CheckStringContain(p.ApprovedBy, token.ApprovedBy)
                    && CheckDateEarly(p.ApprovedOn, token.ApprovedOn);
            }
            if (method == FilterMethod.Relative && chain == FilterChain.LinkOne)
            {
                predicate = p => CheckStringContain(p.Title, token.Title)
                    || CheckStringContain(p.Category.Name, token.Category.Name)
                    || CheckStringContain(p.UpdatedBy, token.UpdatedBy)
                    || CheckDateEarly(p.UpdatedOn, token.UpdatedOn)
                    || CheckStringContain(p.ApprovedBy, token.ApprovedBy)
                    || CheckDateEarly(p.ApprovedOn, token.ApprovedOn);
            }

            OnFiltered(this, predicate, model);

            ClearForm();
        }

        protected void OnFiltered(object sender, Func<Impl.Entity.Post, bool> predicate, FilterModel model)
        {
            if (Filtered != null) Filtered(sender, predicate, model);
        }

        private void ClearForm()
        {
            txtTitle.Text = string.Empty;
            txtCategoryName.Text = string.Empty;
            txtUpdatedBy.Text = string.Empty;
            txtUpdatedOn.Text = string.Empty;
            txtApprovedBy.Text = string.Empty;
            txtApprovedOn.Text = string.Empty;
            ddlFilterMethod.SelectedIndex = 0;
            ddlFilterChain.SelectedIndex = 0;
        }

        private bool CheckStringCompare(string strHost, string strCompare)
        {
            if (string.IsNullOrEmpty(strHost) || string.IsNullOrEmpty(strCompare))
            {
                return false;
            }

            strHost = strHost.Trim();
            strCompare = strCompare.Trim();

            return strHost.Equals(strCompare, StringComparison.OrdinalIgnoreCase);
        }

        private bool CheckStringContain(string strHost, string strContain)
        {
            if (string.IsNullOrEmpty(strHost) || string.IsNullOrEmpty(strContain))
            {
                return false;
            }

            strHost = strHost.ToLower().Trim();
            strContain = strContain.ToLower().Trim();

            return strHost.Contains(strContain);
        }

        private bool CheckDateExact(DateTime? datHost, DateTime? datInput)
        {
            if (datHost == null || datInput == null)
            {
                return false;
            }

            return datHost.Value.Year == datInput.Value.Year
                && datHost.Value.Month == datInput.Value.Month
                && datHost.Value.Day == datInput.Value.Day;
        }

        private bool CheckDateEarly(DateTime? datHost, DateTime? datInput)
        {
            return CheckDateExact(datHost, datInput) || datHost <= datInput;
        }
    }
}