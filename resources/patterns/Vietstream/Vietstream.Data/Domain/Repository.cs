using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace Vietstream.Data.Domain
{
    public class Repository<E> : ReadOnlyRespository<E>, IDisposable where E : Model.Base
    {
        public Service.DataGetter<E> Getter { get; set; }        

        public Repository(DataContext context) : base(context)
        {
            this.Getter = new Service.DataGetter<E>(context);            
        }        

        public override void Dispose()
        {
            this.Getter.Dispose();
        }
    }
}