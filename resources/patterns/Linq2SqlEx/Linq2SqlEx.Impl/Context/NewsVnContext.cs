using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Linq2SqlEx.Data.Domain;

namespace Linq2SqlEx.Impl.Context
{
    public class NewsVnContext : DbContext, IDisposable
    {
        public Repository<Entity.Category> CategoryRespo { get; private set; }

        public Repository<Entity.Post> PostRespo { get; private set; }
        
        public NewsVnContext(string connectionString)
        {
            this.ContextName = "NewsVn";
            this.ConnectionString = connectionString;
            
            this.CreateDataContext();

            this.CategoryRespo = new Repository<Entity.Category>(_ctx);
            this.PostRespo = new Repository<Entity.Post>(_ctx);
        }

        public void Dispose()
        {
            this.CategoryRespo.Dispose();
            this.PostRespo.Dispose();
        }
    }
}
