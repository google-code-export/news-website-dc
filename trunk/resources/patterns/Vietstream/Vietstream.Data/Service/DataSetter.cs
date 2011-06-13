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

        /*public void addOne(E entity, out TID newId)
        {
            this.addOne(entity, false);
            newId = entity.ID;
        }*/

        public void addMany(IEnumerable<E> entities)
        {
            _entityTable.InsertAllOnSubmit(entities);
            _ctx.SubmitChanges();
        }

        public void editOne(E entity)
        {
            this.editOne(entity, false);
        }

        public void editOne(E entity, bool wait)
        {
            /*var original = _entityTable.SingleOrDefault(e => e.ID.Equals(entity.ID));
            _entityTable.Attach(entity, original);

            if (!wait)
            {
                _ctx.SubmitChanges();
            }*/
        }

        public void editMany(IEnumerable<E> entities)
        {
            foreach (var entity in entities)
            {
                this.editOne(entity, true);
            }
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
                this.editOne(entity, wait);
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

        /*public void deleteOne(TID id)
        {
            this.deleteOne(id, false);
        }

        public void deleteOne(TID id, bool wait)
        {
            var entity = _entityTable.SingleOrDefault(e => e.ID.Equals(id));
            this.deleteOne(entity, wait);
        }*/

        public void deleteMany(IEnumerable<E> entities)
        {
            _entityTable.DeleteAllOnSubmit(entities);
            _ctx.SubmitChanges();
        }

        /*public void deleteManyByIds(IEnumerable<TID> ids)
        {
            var entities = _entityTable.Where(e => ids.Contains(e.ID)).AsEnumerable();
            this.deleteMany(entities);
        }*/

        public void Dispose()
        {
            _ctx.Dispose();
        }
    }
}
