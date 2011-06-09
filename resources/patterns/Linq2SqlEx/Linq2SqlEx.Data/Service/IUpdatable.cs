using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Linq2SqlEx.Data.Model;

namespace Linq2SqlEx.Data.Service
{
    interface IUpdatable<E, TID> where E : Base<TID>
    {
        int addOne(E enity);

        int addOne(E entity, out TID newId);

        int addMany(IEnumerable<E> entities);

        int editOne(E entity);

        int editMany(IEnumerable<E> entities);

        int mergeOne(E entity);

        int mergeMany(IEnumerable<E> entities);

        int deleteOne(E entity);

        int deleteOne(TID id);

        int deleteOne(E entity, DeleteRule rule);

        int deleteOne(TID id, DeleteRule rule);

        int deleteMany(IEnumerable<E> entities);

        int deleteMany(IEnumerable<int> ids);

        int deleteMany(IEnumerable<E> entities, DeleteRule rule);

        int deleteMany(IEnumerable<int> ids, DeleteRule rule);
    }
}
