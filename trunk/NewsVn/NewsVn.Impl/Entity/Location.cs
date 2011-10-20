using System;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;
using Vietstream.Data.Model;

namespace NewsVn.Impl.Entity
{
    [Table(Name = "Locations")]
    public class Location : Base, ISerializable
    {

        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int LocationID { get; set; }

        [Column]
        public int CountryID { get; set; }

        [Column]
        public string LocationName { get; set; }


        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
