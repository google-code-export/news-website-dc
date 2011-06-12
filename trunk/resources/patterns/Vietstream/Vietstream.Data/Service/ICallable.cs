using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Linq.Expressions;

namespace Vietstream.Data.Service
{
    public interface ICallable<E, TID> where E : Model.Base<TID>
    {
        E getFirst();

        E getFirst(Func<E, bool> predicate);

        E getLast();

        E getLast(Func<E, bool> predicate);

        E getAtIndex(int index);

        E getAtIndex(int index, Func<E, bool> predicate);

        E getOne(TID id);
        
        E getOne(Func<E, bool> predicate);

        Table<E> getTable();

        IEnumerable<E> getEnumerable();
        
        IEnumerable<E> getEnumerable(Func<E, bool> predicate);

        IQueryable<E> getQueryable();

        IQueryable<E> getQueryable(Expression<Func<E, bool>> expression);
    }
}
