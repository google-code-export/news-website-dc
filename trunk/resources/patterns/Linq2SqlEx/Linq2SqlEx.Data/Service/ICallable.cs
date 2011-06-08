using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Linq.Expressions;

namespace Linq2SqlEx.Data.Service
{
    public interface ICallable
    {
        E getFirst<E>() where E : Entity.Base;

        E getLast<E>() where E : Entity.Base;

        E getAtIndex<E>(int index) where E : Entity.Base;

        E getOne<E>(Func<E, bool> predicate) where E : Entity.Base;

        Table<E> getTable<E>() where E : Entity.Base;

        IEnumerable<E> getEnumerable<E>(Func<E, bool> predicate) where E : Entity.Base;
        
        IQueryable<E> getQueryable<E>(Expression<Func<E, bool>> expression) where E : Entity.Base;
    }
}
