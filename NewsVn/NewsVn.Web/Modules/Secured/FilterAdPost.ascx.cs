using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewsVn.Impl.Model;
using System.Linq.Expressions;
using NewsVn.Web.Utils;

namespace NewsVn.Web.Modules.Secured
{
    public partial class FilterAdPost : BaseUI.SecuredModule
    {
        public delegate void FilteredEventHandler(object sender, Expression<Func<Impl.Entity.AdPost, bool>> expression, FilterModel model);

        public event FilteredEventHandler Filtered;

        protected bool? HasPayment
        {
            get
            {
                bool hasPayment = false;
                if (!bool.TryParse(ddlAdPostType.SelectedValue, out hasPayment))
                {
                    return null;
                }
                return hasPayment;
            }
        }

        protected DateTime? CreatedOn
        {
            get
            {
                DateTime createdOn = DateTime.Now;
                if (!DateTime.TryParse(txtCreatedOn.Text, out createdOn))
                {
                    return null;
                }
                return createdOn;
            }
        }

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

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            var expression = PredicateBuilder.True<Impl.Entity.AdPost>();

            var method = (FilterMethod)Enum.Parse(typeof(FilterMethod), ddlFilterMethod.SelectedValue, true);
            var chain = (FilterChain)Enum.Parse(typeof(FilterChain), ddlFilterChain.SelectedValue, true);

            var token = new Impl.Entity.AdPost
            {
                Title = txtTitle.Text,
                Category = new Impl.Entity.Category
                {
                    Name = txtCategoryName.Text
                },
                CreatedBy = txtCreatedBy.Text,
                UpdatedBy = txtUpdatedBy.Text,
                UpdatedOn = this.UpdatedOn,
            };

            if (CreatedOn.HasValue)
            {
                token.CreatedOn = CreatedOn.Value;
            }

            if (HasPayment.HasValue)
            {
                token.Payment = HasPayment.Value ? 2 : 1;
            }

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

        private Expression<Func<Impl.Entity.AdPost, bool>> FilterAbsoluteLinkAll(Impl.Entity.AdPost token)
        {
            var expression = PredicateBuilder.True<Impl.Entity.AdPost>();

            if (!string.IsNullOrEmpty(token.Title))
            {
                expression = expression.And(p => p.Title.Equals(token.Title, StringComparison.OrdinalIgnoreCase));
            }
            if (!string.IsNullOrEmpty(token.Category.Name))
            {
                expression = expression.And(p => p.Category.Name.Equals(token.Category.Name, StringComparison.OrdinalIgnoreCase));
            }
            if (token.Payment > 0)
            {
                bool hasPayment = token.Payment > 1 ? true : false;

                if (hasPayment)
                {
                    expression = expression.And(p => p.Payment > 0);
                }
                else
                {
                    expression = expression.And(p => p.Payment == 0);
                }
            }
            if (!string.IsNullOrEmpty(token.CreatedBy))
            {
                expression = expression.And(p => p.CreatedBy.Equals(token.CreatedBy, StringComparison.OrdinalIgnoreCase));
            }
            if (token.CreatedOn != default(DateTime))
            {
                expression = expression.And(p => p.CreatedOn.Year == token.CreatedOn.Year
                    && p.CreatedOn.Month == token.CreatedOn.Month
                    && p.CreatedOn.Day == token.CreatedOn.Day);
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

            return expression;
        }

        private Expression<Func<Impl.Entity.AdPost, bool>> FilterAbsoluteLinkOne(Impl.Entity.AdPost token)
        {
            var expression = PredicateBuilder.False<Impl.Entity.AdPost>();

            if (!string.IsNullOrEmpty(token.Title))
            {
                expression = expression.Or(p => p.Title.Equals(token.Title, StringComparison.OrdinalIgnoreCase));
            }
            if (!string.IsNullOrEmpty(token.Category.Name))
            {
                expression = expression.Or(p => p.Category.Name.Equals(token.Category.Name, StringComparison.OrdinalIgnoreCase));
            }
            if (token.Payment > 0)
            {
                bool hasPayment = token.Payment > 1 ? true : false;

                if (hasPayment)
                {
                    expression = expression.Or(p => p.Payment > 0);
                }
                else
                {
                    expression = expression.Or(p => p.Payment == 0);
                }
            }
            if (!string.IsNullOrEmpty(token.CreatedBy))
            {
                expression = expression.Or(p => p.CreatedBy.Equals(token.CreatedBy, StringComparison.OrdinalIgnoreCase));
            }
            if (token.CreatedOn != default(DateTime))
            {
                expression = expression.Or(p => p.CreatedOn.Year == token.CreatedOn.Year
                    && p.CreatedOn.Month == token.CreatedOn.Month
                    && p.CreatedOn.Day == token.CreatedOn.Day);
            }
            if (!string.IsNullOrEmpty(token.UpdatedBy))
            {
                expression = expression.Or(p => p.UpdatedBy.Equals(token.UpdatedBy, StringComparison.OrdinalIgnoreCase));
            }
            if (token.UpdatedOn != null)
            {
                expression = expression.Or(p => p.UpdatedOn.Value.Year == token.UpdatedOn.Value.Year
                    && p.UpdatedOn.Value.Month == token.UpdatedOn.Value.Month
                    && p.UpdatedOn.Value.Day == token.UpdatedOn.Value.Day);
            }

            return expression;
        }

        private Expression<Func<Impl.Entity.AdPost, bool>> FilterRelativeLinkAll(Impl.Entity.AdPost token)
        {
            var expression = PredicateBuilder.True<Impl.Entity.AdPost>();

            if (!string.IsNullOrEmpty(token.Title))
            {
                expression = expression.And(p => p.Title.Contains(token.Title));
            }
            if (!string.IsNullOrEmpty(token.Category.Name))
            {
                expression = expression.And(p => p.Category.Name.Contains(token.Category.Name));
            }
            if (token.Payment > 0)
            {
                bool hasPayment = token.Payment > 1 ? true : false;

                if (hasPayment)
                {
                    expression = expression.And(p => p.Payment > 0);
                }
                else
                {
                    expression = expression.And(p => p.Payment == 0);
                }
            }
            if (!string.IsNullOrEmpty(token.CreatedBy))
            {
                expression = expression.And(p => p.CreatedBy.Contains(token.CreatedBy));
            }
            if (token.CreatedOn != default(DateTime))
            {
                expression = expression.And(p => p.CreatedOn.Date <= token.CreatedOn.Date);
            }
            if (!string.IsNullOrEmpty(token.UpdatedBy))
            {
                expression = expression.And(p => p.UpdatedBy.Contains(token.UpdatedBy));
            }
            if (token.UpdatedOn != null)
            {
                expression = expression.And(p => p.UpdatedOn.Value.Date <= token.UpdatedOn.Value.Date);
            }            

            return expression;
        }

        private Expression<Func<Impl.Entity.AdPost, bool>> FilterRelativeLinkOne(Impl.Entity.AdPost token)
        {
            var expression = PredicateBuilder.False<Impl.Entity.AdPost>();

            if (!string.IsNullOrEmpty(token.Title))
            {
                expression = expression.Or(p => p.Title.Contains(token.Title));
            }
            if (!string.IsNullOrEmpty(token.Category.Name))
            {
                expression = expression.Or(p => p.Category.Name.Contains(token.Category.Name));
            }
            if (token.Payment > 0)
            {
                bool hasPayment = token.Payment > 1 ? true : false;

                if (hasPayment)
                {
                    expression = expression.Or(p => p.Payment > 0);
                }
                else
                {
                    expression = expression.Or(p => p.Payment == 0);
                }
            }
            if (!string.IsNullOrEmpty(token.CreatedBy))
            {
                expression = expression.Or(p => p.CreatedBy.Contains(token.CreatedBy));
            }
            if (token.CreatedOn != default(DateTime))
            {
                expression = expression.Or(p => p.CreatedOn.Date <= token.CreatedOn.Date);
            }
            if (!string.IsNullOrEmpty(token.UpdatedBy))
            {
                expression = expression.Or(p => p.UpdatedBy.Contains(token.UpdatedBy));
            }
            if (token.UpdatedOn != null)
            {
                expression = expression.Or(p => p.UpdatedOn.Value.Date <= token.UpdatedOn.Value.Date);
            }

            return expression;
        }

        protected void OnFiltered(object sender, Expression<Func<Impl.Entity.AdPost, bool>> expression, FilterModel model)
        {
            if (Filtered != null) Filtered(sender, expression, model);
        }

        private void ClearForm()
        {
            txtTitle.Text = string.Empty;
            txtCategoryName.Text = string.Empty;
            txtCreatedBy.Text = string.Empty;
            txtCreatedOn.Text = string.Empty;
            txtUpdatedBy.Text = string.Empty;
            txtUpdatedOn.Text = string.Empty;
            ddlAdPostType.SelectedIndex = 0;
            ddlFilterMethod.SelectedIndex = 0;
            ddlFilterChain.SelectedIndex = 0;
        }
    }
}