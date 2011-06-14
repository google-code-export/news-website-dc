using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vietstream.Data.Model;

namespace Vietstream.Data.Service
{
    interface IUpdatable<E> where E : Base
    {
        void addOne(E entity);

        void addOne(E entity, bool wait);

        void addMany(IEnumerable<E> entities);

        void mergeOne(E entity);

        void mergeOne(E entity, bool wait);

        void mergeMany(IEnumerable<E> entities);

        void deleteOne(E entity);

        void deleteOne(E entity, bool wait);

        void deleteMany(IEnumerable<E> entities);
    }
}
