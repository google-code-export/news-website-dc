using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vietstream.Data.Service
{
    public interface IPageable<E, TID> where E : Model.Base<TID>
    {
        List<E> getSubList(int fromIndex, int toIndex);

        List<E> getSubList(IEnumerable<E> originalList, int fromIndex, int toIndex);

        List<E> getPagedList(int pageIndex, int pageSize);

        List<E> getPagedList(IEnumerable<E> originalList, int pageIndex, int pageSize);
    }
}
