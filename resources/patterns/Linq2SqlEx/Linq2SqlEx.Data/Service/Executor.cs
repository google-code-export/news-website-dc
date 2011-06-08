using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace Linq2SqlEx.Data.Service
{
    public class Executor : ICallable, IDisposable
    {
        string _connectionString;
        
        DataContext _ctx;
        
        public Executor(string connectionString)
        {
            _connectionString = connectionString;
        }

        public E getFirst<E>() where E : Entity.Base
        {
            return this.getTable<E>().FirstOrDefault();
        }

        public E getLast<E>() where E : Entity.Base
        {
            return this.getTable<E>().LastOrDefault();
        }

        public E getAtIndex<E>(int index) where E : Entity.Base
        {
            return this.getTable<E>().ElementAtOrDefault(index);
        }

        public E getOne<E>(Func<E, bool> predicate) where E : Entity.Base
        {
            return this.getTable<E>().FirstOrDefault(predicate);
        }

        public Table<E> getTable<E>() where E : Entity.Base
        {
            _ctx = new DataContext(_connectionString);
            return _ctx.GetTable<E>();
        }

        public IEnumerable<E> getEnumerable<E>(Func<E, bool> predicate) where E : Entity.Base
        {
            return this.getTable<E>().Where(predicate);
        }

        public IQueryable<E> getQueryable<E>(System.Linq.Expressions.Expression<Func<E, bool>> expression) where E : Entity.Base
        {
            return this.getTable<E>().Where(expression);
        }

        public void Dispose()
        {
            //Dispose all unused resources here
            _ctx.Dispose();
        }
    }
}
