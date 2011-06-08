using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace Linq2SqlEx.Data.Service
{
    public class DataSetter<E> : IUpdatable<E>, IDisposable where E : Model.Base
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
    }
}
