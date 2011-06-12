using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Data.Linq;
using System.Runtime.Serialization;
using Linq2SqlEx.Data.Model;

namespace Linq2SqlEx.Impl.Entity
{
    [Table(Name = "Categories")]
    public class Category : Base<int>, ISerializable
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public override int ID { get; set; }

        [Column]
        public string Name { get; set; }

        [Association(ThisKey = "ParentID", OtherKey = "ID", IsForeignKey = true)]
        public Category Parent { get; set; }

        [Association(ThisKey = "ID", OtherKey = "ParentID")]
        public EntitySet<Category> Children { get; set; }

        [Association(OtherKey = "CategoryID")]
        public EntitySet<Post> Posts { get; set; }

        [Column]
        public int? ParentID { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "[Category] ID: " + ID + ", Name: " + Name + ", Parent: " + (Parent == null) + ", Children: " + Children.Count() +  ", PostFound: " + Posts.Count();
        }
    }
}
