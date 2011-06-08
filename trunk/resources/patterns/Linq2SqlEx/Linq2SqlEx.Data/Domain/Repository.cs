using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace Linq2SqlEx.Data.Domain
{
    public class Repository<E> : IDisposable where E : Model.Base
    {
        public Service.DataGetter<E> Getter { get; set; }

        public Service.DataSetter<E> Setter { get; set; }

        public Repository(DataContext context)
        {
            this.Getter = new Service.DataGetter<E>(context);
            this.Setter = new Service.DataSetter<E>(context);
        }

        public void Dispose()
        {
            this.Getter.Dispose();
            this.Setter.Dispose();
        }
    }
}
