using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace Vietstream.Data.Service
{
    public class DataSetter<E> : IUpdatable<E>, IDisposable where E : Model.Base
    {
        DataContext _ctx;

        Table<E> _entityTable;

        public DataSetter(DataContext context)
        {
            _ctx = context;
            _entityTable = _ctx.GetTable<E>();
        }

        public void addOne(E entity)
        {
            this.addOne(entity, false);
        }

        public void addOne(E entity, bool wait)
        {
            _entityTable.InsertOnSubmit(entity);
            
            if (!wait)
            {
                _ctx.SubmitChanges();
            }
        }

        public void addMany(IEnumerable<E> entities)
        {
            _entityTable.InsertAllOnSubmit(entities);
            _ctx.SubmitChanges();
        }        

        public void mergeOne(E entity)
        {
            this.mergeOne(entity, false);
        }

        public void mergeOne(E entity, bool wait)
        {
            if (!_entityTable.Contains(entity))
            {
                this.addOne(entity, wait);
            }
            else
            {
                if (!wait)
                {
                    _ctx.SubmitChanges();
                }
            }
        }

        public void mergeMany(IEnumerable<E> entities)
        {
            foreach (var entity in entities)
            {
                this.mergeOne(entity, true);
            }
            _ctx.SubmitChanges();
        }

        public void deleteOne(E entity)
        {
            this.deleteOne(entity, false);
        }

        public void deleteOne(E entity, bool wait)
        {
            _entityTable.DeleteOnSubmit(entity);

            if (!wait)
            {
                _ctx.SubmitChanges();
            }
        }

        public void deleteMany(IEnumerable<E> entities)
        {
            _entityTable.DeleteAllOnSubmit(entities);
            _ctx.SubmitChanges();
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }
    }
}
