using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Data.Linq.Mapping;
using Vietstream.Data.Model;

namespace NewsVn.Impl.Entity
{
    [Table(Name = "KeyValueRefs")]
    public class KeyValueRef : Base, ISerializable
    {

        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }

        [Column]
        public string Type { get; set; }

        [Column]
        public string Key { get; set; }

        [Column]
        public string Value { get; set; }

        //public override string ToString()
        //{
        //    return "[KeyValueRef] ID: " + ID + ", Type: " + Type + ", Value: " + Value;
        //}

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }

}
