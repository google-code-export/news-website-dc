using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linq2SqlEx.Data.Service
{
    public interface IPageable<E> where E : Model.Base
    {
        List<E> getSubList(int fromIndex, int toIndex);

        List<E> getSubList(IEnumerable<E> originalList, int fromIndex, int toIndex);

        List<E> getPagedList(int pageIndex, int pageSize);

        List<E> getPagedList(IEnumerable<E> originalList, int pageIndex, int pageSize);
    }
}
