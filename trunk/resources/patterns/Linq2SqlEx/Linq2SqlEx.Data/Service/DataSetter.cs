using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace Linq2SqlEx.Data.Service
{
    public class DataSetter<E, TID> : IUpdatable<E, TID>, IDisposable where E : Model.Base<TID>
    {
        DataContext _ctx;

        public DataSetter(DataContext context)
        {
            _ctx = context;
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }

        public int addOne(E enity)
        {
            throw new NotImplementedException();
        }

        public int addOne(E entity, out TID newId)
        {
            throw new NotImplementedException();
        }

        public int addMany(IEnumerable<E> entities)
        {
            throw new NotImplementedException();
        }

        public int editOne(E entity)
        {
            throw new NotImplementedException();
        }

        public int editMany(IEnumerable<E> entities)
        {
            throw new NotImplementedException();
        }

        public int mergeOne(E entity)
        {
            throw new NotImplementedException();
        }

        public int mergeMany(IEnumerable<E> entities)
        {
            throw new NotImplementedException();
        }

        public int deleteOne(E entity)
        {
            throw new NotImplementedException();
        }

        public int deleteOne(TID id)
        {
            throw new NotImplementedException();
        }

        public int deleteOne(E entity, Model.DeleteRule rule)
        {
            throw new NotImplementedException();
        }

        public int deleteOne(TID id, Model.DeleteRule rule)
        {
            throw new NotImplementedException();
        }

        public int deleteMany(IEnumerable<E> entities)
        {
            throw new NotImplementedException();
        }

        public int deleteMany(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public int deleteMany(IEnumerable<E> entities, Model.DeleteRule rule)
        {
            throw new NotImplementedException();
        }

        public int deleteMany(IEnumerable<int> ids, Model.DeleteRule rule)
        {
            throw new NotImplementedException();
        }
    }
}
