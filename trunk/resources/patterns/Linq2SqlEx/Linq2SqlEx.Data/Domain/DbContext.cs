using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace Linq2SqlEx.Data.Domain
{
    public abstract class DbContext
    {
        protected DataContext _ctx;
        
        public string ContextName { get; set; }

        public string ConnectionString { get; set; }

        public bool DeferredLoadingEnabled
        {
            get { return _ctx.DeferredLoadingEnabled; }
            set { _ctx.DeferredLoadingEnabled = value; }
        }

        protected void CreateDataContext()
        {
            _ctx = new DataContext(this.ConnectionString);
        }
    }
}
