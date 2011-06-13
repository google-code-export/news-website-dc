using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;
using Vietstream.Data.Model;

namespace Vietstream.Test.Entity
{
    [Table(Name = "Settings")]
    public class Setting : Base, ISerializable
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }

        [Column]
        public string Type
        {
            get;
            set;
        }
        [Column]
        public string Description
        {
            get;
            set;
        }
        [Column]
        public string Name
        {
            get;
            set;
        }
        [Column]
        public string Value
        {
            get;
            set;
        }

        public override string ToString()
        {
            return "[Settings] ID: " + ID + ", Type: " + Type + ", Name: " + Name;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
