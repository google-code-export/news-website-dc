using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vietstream.Data.Model;

namespace Vietstream.Data.Service
{
    interface IUpdatable<E, TID> where E : Base<TID>
    {
        void addOne(E entity);

        void addOne(E entity, bool wait);

        void addOne(E entity, out TID newId);

        void addMany(IEnumerable<E> entities);

        void editOne(E entity);

        void editOne(E entity, bool wait);

        void editMany(IEnumerable<E> entities);

        void mergeOne(E entity);

        void mergeOne(E entity, bool wait);

        void mergeMany(IEnumerable<E> entities);

        void deleteOne(E entity);

        void deleteOne(E entity, bool wait);

        void deleteOne(TID id);

        void deleteOne(TID id, bool wait);

        void deleteMany(IEnumerable<E> entities);

        void deleteMany(IEnumerable<TID> ids);
    }
}
