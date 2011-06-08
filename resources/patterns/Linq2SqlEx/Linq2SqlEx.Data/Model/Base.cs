using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linq2SqlEx.Data.Model
{
    public abstract class Base
    {
        public virtual int ID { get; set; }
        
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
