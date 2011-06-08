using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Data.Linq.Mapping;
using System.Data.Linq;

namespace Linq2SqlEx.Data.Entity
{
    [Table(Name = "Categories")]
    public class Category : Base, ISerializable
    {
        [Column(IsPrimaryKey = true)]
        public int ID { get; set; }

        [Column]
        public string Name { get; set; }

        [Association(OtherKey = "CategoryID")]
        public EntitySet<Post> Posts { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "[Category] ID: " + ID + ", Name: " + Name + ", PostFound: " + Posts.Count();
        }
    }
}
