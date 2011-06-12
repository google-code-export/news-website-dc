using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vietstream.Data.Model
{
    public abstract class Base<TID>
    {
        public virtual TID ID { get; set; }
        
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
