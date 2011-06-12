using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vietstream.Data.Domain;

namespace Linq2SqlEx.Impl.Context
{
    public class NewsVnContext : DbContext, IDisposable
    {
        public Repository<Entity.Category, int> CategoryRespo { get; private set; }

        public Repository<Entity.Post, int> PostRespo { get; private set; }
        
        public NewsVnContext(string connectionString)
        {
            this.ContextName = "NewsVn";
            this.ConnectionString = connectionString;
            
            this.CreateDataContext();

            this.CategoryRespo = new Repository<Entity.Category, int>(_ctx);
            this.PostRespo = new Repository<Entity.Post, int>(_ctx);
        }

        public void Dispose()
        {
            this.CategoryRespo.Dispose();
            this.PostRespo.Dispose();
        }
    }
}
