using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace Linq2SqlEx.Data.Domain
{
    public class ReadOnlyRespository<E, TID> : IDisposable where E : Model.Base<TID>
    {
        public Service.DataSetter<E, TID> Setter { get; set; }

        public ReadOnlyRespository(DataContext context)
        {
            this.Setter = new Service.DataSetter<E, TID>(context);
        }

        public virtual void Dispose()
        {
            this.Setter.Dispose();
        }
    }
}
