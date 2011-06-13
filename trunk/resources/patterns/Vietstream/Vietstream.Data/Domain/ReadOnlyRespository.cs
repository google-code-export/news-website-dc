using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace Vietstream.Data.Domain
{
    public class ReadOnlyRespository<E> : IDisposable where E : Model.Base
    {
        public Type EntityType { get; private set; }
        
        public Service.DataSetter<E> Setter { get; set; }

        public ReadOnlyRespository(DataContext context)
        {
            this.EntityType = typeof(E);
            this.Setter = new Service.DataSetter<E>(context);
        }

        public virtual void Dispose()
        {
            this.Setter.Dispose();
        }
    }
}
