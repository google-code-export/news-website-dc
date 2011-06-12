using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace Vietstream.Data.Service
{
    public interface IPageable<E, TID> where E : Model.Base<TID>
    {
        List<E> getSubList(int fromIndex, int toIndex);

        List<E> getSubList(int fromIndex, int toIndex, Expression<Func<E, bool>> expression);

        List<E> getSubList(IEnumerable<E> originalList, int fromIndex, int toIndex);

        List<E> getPagedList(int pageIndex, int pageSize);

        List<E> getPagedList(int pageIndex, int pageSize, Expression<Func<E, bool>> expression);

        List<E> getPagedList(IEnumerable<E> originalList, int pageIndex, int pageSize);
    }
}
