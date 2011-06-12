using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace Linq2SqlEx.Data.Domain
{
    public class Repository<E, TID> : ReadOnlyRespository<E, TID>, IDisposable where E : Model.Base<TID>
    {
        public Service.DataGetter<E, TID> Getter { get; set; }        

        public Repository(DataContext context) : base(context)
        {
            this.Getter = new Service.DataGetter<E, TID>(context);            
        }

        public override void Dispose()
        {
            this.Getter.Dispose();
        }
    }
}