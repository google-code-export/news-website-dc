using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Linq.Expressions;

namespace Vietstream.Data.Service
{
    public class DataGetter<E> : ICallable<E>, IPageable<E>, ISortable<E>, IDisposable where E : Model.Base
    {
        DataContext _ctx;

        public DataGetter(DataContext context)
        {
            _ctx = context;
        }

        public E getFirst()
        {
            return this.getFirst(e => true);
        }

        public E getFirst(Func<E, bool> predicate)
        {
            return this.getTable().Where(predicate).FirstOrDefault();
        }

        public E getLast()
        {
            return this.getLast(e => true);
        }

        public E getLast(Func<E, bool> predicate)
        {
            return this.getTable().Where(predicate).LastOrDefault();
        }

        public E getAtIndex(int index)
        {
            return this.getAtIndex(index, e => true);
        }

        public E getAtIndex(int index, Func<E, bool> predicate)
        {
            return this.getTable().Where(predicate).ElementAtOrDefault(index);
        }

        public E getOne(Func<E, bool> predicate)
        {
            return this.getTable().Where(predicate).SingleOrDefault();
        }

        public Table<E> getTable()
        {
            return _ctx.GetTable<E>();
        }

        public IEnumerable<E> getEnumerable()
        {
            return this.getEnumerable(e => true);
        }

        public IEnumerable<E> getEnumerable(Func<E, bool> predicate)
        {
            return this.getTable().Where(predicate);
        }

        public IQueryable<E> getQueryable()
        {
            return this.getQueryable(e => true);
        }

        public IQueryable<E> getQueryable(Expression<Func<E, bool>> expression)
        {
            return this.getTable().Where(expression);
        }

        public IEnumerable<E> getSubList(int fromIndex, int toIndex)
        {
            return this.getSubList(null, fromIndex, toIndex);
        }

        public IEnumerable<E> getSubList(int fromIndex, int toIndex, Expression<Func<E, bool>> expression)
        {
            var list = this.getQueryable(expression).AsEnumerable();
            return this.getSubList(list, fromIndex, toIndex);
        }

        public IEnumerable<E> getSubList(IEnumerable<E> originalList, int fromIndex, int toIndex)
        {
            var list = originalList != null ? originalList : this.getTable().AsEnumerable();
            return list.Skip(fromIndex - 0).Take(toIndex - fromIndex);
        }

        public IEnumerable<E> getPagedList(int pageIndex, int pageSize)
        {
            return this.getPagedList(null, pageIndex, pageSize);
        }

        public IEnumerable<E> getPagedList(int pageIndex, int pageSize, Expression<Func<E, bool>> expression)
        {
            var list = this.getQueryable(expression).AsEnumerable();
            return this.getPagedList(list, pageIndex, pageSize);
        }

        public IEnumerable<E> getPagedList(IEnumerable<E> originalList, int pageIndex, int pageSize)
        {
            var list = originalList != null ? originalList : this.getTable().AsEnumerable();
            return list.Skip(pageSize * (pageIndex - 1)).Take(pageSize);
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }        
    }
}
