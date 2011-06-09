using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace Linq2SqlEx.Data.Domain
{
    public class Repository<E, TID> : IDisposable where E : Model.Base<TID>
    {
        public Service.DataGetter<E, TID> Getter { get; set; }

        public Service.DataSetter<E, TID> Setter { get; set; }

        public Repository(DataContext context)
        {
            this.Getter = new Service.DataGetter<E, TID>(context);
            this.Setter = new Service.DataSetter<E, TID>(context);
        }

        public void Dispose()
        {
            this.Getter.Dispose();
            this.Setter.Dispose();
        }
    }
}