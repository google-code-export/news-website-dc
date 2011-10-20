using System;
using NewsVn.Impl.Model;

namespace NewsVn.Web.Modules
{    
    public partial class SiteAdmin_FilterPost : System.Web.UI.UserControl
    {
        public delegate void FilteringEventHandler(object sender, Impl.Entity.Post token);

        public delegate void FilteredEventHandler(object sender, Func<Impl.Entity.Post, bool> predicate);

        public event FilteringEventHandler Filtering;
        
        public event FilteredEventHandler Filtered;

        public string PostTitle
        {
            get
            {
                return txtTitle.Text.Trim();
            }
            set
            {
                txtTitle.Text = value;
            }
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            Func<Impl.Entity.Post, bool> predicate = p => true;
            
            var method = (FilterMethod)Enum.Parse(typeof(FilterMethod), ddlFilterMethod.SelectedValue, true);
            var chain = (FilterChain)Enum.Parse(typeof(FilterChain), ddlFilterChain.SelectedValue, true);

            var token = new Impl.Entity.Post
            {
                Title = PostTitle,
                Category = new Impl.Entity.Category
                {
                    Name = string.Empty
                }
            };

            //var token = new Impl.Entity.Post();

            //OnFiltering(this, token);

            if (method == FilterMethod.Absolute && chain == FilterChain.LinkAll)
            {
                predicate = p => CheckStringCompare(p.Title, token.Title)
                    && CheckStringCompare(p.Category.Name, token.Category.Name);
            }
            if (method == FilterMethod.Absolute && chain == FilterChain.LinkOne)
            {
                predicate = p => CheckStringCompare(p.Title, token.Title)
                    || CheckStringCompare(p.Category.Name, token.Category.Name);
            }
            if (method == FilterMethod.Relative && chain == FilterChain.LinkAll)
            {
                predicate = p => CheckStringContain(p.Title, token.Title)
                    && CheckStringContain(p.Category.Name, token.Category.Name);
            }
            if (method == FilterMethod.Relative && chain == FilterChain.LinkOne)
            {
                predicate = p => CheckStringContain(p.Title, token.Title)
                    || CheckStringContain(p.Category.Name, token.Category.Name);
            }

            OnFiltered(this, predicate);
        }

        protected void OnFiltering(object sender, Impl.Entity.Post token)
        {
            if (Filtering != null) Filtering(sender, token);
        }

        protected void OnFiltered(object sender, Func<Impl.Entity.Post, bool> predicate)
        {
            if (Filtered != null) Filtered(sender, predicate);
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
    }
}