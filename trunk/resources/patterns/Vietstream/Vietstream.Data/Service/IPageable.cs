using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace Vietstream.Data.Service
{
    public interface IPageable<E> where E : Model.Base
    {
        IEnumerable<E> getSubList(int fromIndex, int toIndex);

        IEnumerable<E> getSubList(int fromIndex, int toIndex, Expression<Func<E, bool>> expression);

        IEnumerable<E> getSubList(IEnumerable<E> originalList, int fromIndex, int toIndex);

        IEnumerable<E> getPagedList(int pageIndex, int pageSize);

        IEnumerable<E> getPagedList(int pageIndex, int pageSize, Expression<Func<E, bool>> expression);

        IEnumerable<E> getPagedList(IEnumerable<E> originalList, int pageIndex, int pageSize);
    }
}
