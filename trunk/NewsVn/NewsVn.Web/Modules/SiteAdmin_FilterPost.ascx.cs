using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using NewsVn.Impl.Model;
using NewsVn.Web.Utils;

namespace NewsVn.Web.Modules
{    
    public partial class SiteAdmin_FilterPost : BaseUI.SecuredModule
    {
        public delegate void FilteredEventHandler(object sender, Expression<Func<Impl.Entity.Post, bool>> expression, FilterModel model);
        
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
            var expression = PredicateBuilder.True<Impl.Entity.Post>();
            
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
                expression = FilterAbsoluteLinkAll(token);
            }
            if (method == FilterMethod.Absolute && chain == FilterChain.LinkOne)
            {
                expression = FilterAbsoluteLinkOne(token);
            }
            if (method == FilterMethod.Relative && chain == FilterChain.LinkAll)
            {
                expression = FilterRelativeLinkAll(token);
            }
            if (method == FilterMethod.Relative && chain == FilterChain.LinkOne)
            {
                expression = FilterRelativeLinkOne(token);
            }

            OnFiltered(this, expression, model);

            ClearForm();
        }

        private Expression<Func<Impl.Entity.Post, bool>> FilterAbsoluteLinkAll(Impl.Entity.Post token)
        {
            var expression = PredicateBuilder.True<Impl.Entity.Post>();

            if (!string.IsNullOrEmpty(token.Title))
            {
                expression = expression.And(p => p.Title.Equals(token.Title, StringComparison.OrdinalIgnoreCase));
            }
            if (!string.IsNullOrEmpty(token.Category.Name))
            {
                expression = expression.And(p => p.Category.Name.Equals(token.Category.Name, StringComparison.OrdinalIgnoreCase));
            }
            if (!string.IsNullOrEmpty(token.UpdatedBy))
            {
                expression = expression.And(p => p.UpdatedBy.Equals(token.UpdatedBy, StringComparison.OrdinalIgnoreCase));
            }
            if (token.UpdatedOn != null)
            {
                expression = expression.And(p => p.UpdatedOn.Value.Year == token.UpdatedOn.Value.Year
                    && p.UpdatedOn.Value.Month == token.UpdatedOn.Value.Month
                    && p.UpdatedOn.Value.Day == token.UpdatedOn.Value.Day);
            }
            if (!string.IsNullOrEmpty(token.ApprovedBy))
            {
                expression = expression.And(p => p.ApprovedBy.Equals(token.ApprovedBy, StringComparison.OrdinalIgnoreCase));
            }
            if (token.ApprovedOn != null)
            {
                expression = expression.And(p => p.ApprovedOn.Value.Year == token.ApprovedOn.Value.Year
                    && p.ApprovedOn.Value.Month == token.ApprovedOn.Value.Month
                    && p.ApprovedOn.Value.Day == token.ApprovedOn.Value.Day);
            }

            return expression;
        }

        private Expression<Func<Impl.Entity.Post, bool>> FilterAbsoluteLinkOne(Impl.Entity.Post token)
        {
            var expression = PredicateBuilder.False<Impl.Entity.Post>();

            if (!string.IsNullOrEmpty(token.Title))
            {
                expression = expression.Or(p => p.Title.Equals(token.Title, StringComparison.OrdinalIgnoreCase));
            }
            if (!string.IsNullOrEmpty(token.Category.Name))
            {
                expression = expression.Or(p => p.Category.Name.Equals(token.Category.Name, StringComparison.OrdinalIgnoreCase));
            }
            if (!string.IsNullOrEmpty(token.UpdatedBy))
            {
                expression = expression.Or(p => p.UpdatedBy.Equals(token.UpdatedBy, StringComparison.OrdinalIgnoreCase));
            }
            if (token.UpdatedOn != null)
            {
                expression = expression.Or(p => p.UpdatedOn.Value.Date.Equals(token.UpdatedOn.Value.Date));
            }
            if (!string.IsNullOrEmpty(token.ApprovedBy))
            {
                expression = expression.Or(p => p.ApprovedBy.Equals(token.ApprovedBy, StringComparison.OrdinalIgnoreCase));
            }
            if (token.ApprovedOn != null)
            {
                expression = expression.Or(p => p.ApprovedOn.Value.Date.Equals(token.ApprovedOn.Value.Date));
            }

            return expression;
        }

        private Expression<Func<Impl.Entity.Post, bool>> FilterRelativeLinkAll(Impl.Entity.Post token)
        {
            var expression = PredicateBuilder.True<Impl.Entity.Post>();

            if (!string.IsNullOrEmpty(token.Title))
            {
                expression = expression.And(p => p.Title.Contains(token.Title));
            }
            if (!string.IsNullOrEmpty(token.Category.Name))
            {
                expression = expression.And(p => p.Category.Name.Contains(token.Category.Name));
            }
            if (!string.IsNullOrEmpty(token.UpdatedBy))
            {
                expression = expression.And(p => p.UpdatedBy.Contains(token.UpdatedBy));
            }
            if (token.UpdatedOn != null)
            {
                expression = expression.And(p => p.UpdatedOn.Value.Date <= token.UpdatedOn.Value.Date);
            }
            if (!string.IsNullOrEmpty(token.ApprovedBy))
            {
                expression = expression.And(p => p.ApprovedBy.Contains(token.ApprovedBy));
            }
            if (token.ApprovedOn != null)
            {
                expression = expression.And(p => p.ApprovedOn.Value.Date <= token.ApprovedOn.Value.Date);
            }

            return expression;
        }

        private Expression<Func<Impl.Entity.Post,bool>> FilterRelativeLinkOne(Impl.Entity.Post token)
        {
            var expression = PredicateBuilder.False<Impl.Entity.Post>();
            
            if (!string.IsNullOrEmpty(token.Title))
            {
                expression = expression.Or(p => p.Title.Contains(token.Title));
            }
            if (!string.IsNullOrEmpty(token.Category.Name))
            {
                expression = expression.Or(p => p.Category.Name.Contains(token.Category.Name));
            }
            if (!string.IsNullOrEmpty(token.UpdatedBy))
            {
                expression = expression.Or(p => p.UpdatedBy.Contains(token.UpdatedBy));
            }
            if (token.UpdatedOn != null)
            {
                expression = expression.Or(p => p.UpdatedOn.Value.Date <= token.UpdatedOn.Value.Date);
            }
            if (!string.IsNullOrEmpty(token.ApprovedBy))
            {
                expression = expression.Or(p => p.ApprovedBy.Contains(token.ApprovedBy));
            }
            if (token.ApprovedOn != null)
            {
                expression = expression.Or(p => p.ApprovedOn.Value.Date <= token.ApprovedOn.Value.Date);
            }

            return expression;
        }

        protected void OnFiltered(object sender, Expression<Func<Impl.Entity.Post, bool>> expression, FilterModel model)
        {
            if (Filtered != null) Filtered(sender, expression, model);
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
    }
}