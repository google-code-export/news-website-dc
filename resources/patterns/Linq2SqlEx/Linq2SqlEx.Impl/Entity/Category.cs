using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Data.Linq;
using System.Runtime.Serialization;
using Vietstream.Data.Model;

namespace Linq2SqlEx.Impl.Entity
{
    [Table(Name = "Categories")]
    public class Category : Base<int>, ISerializable
    {
        public Category()
        {
            this._Parent = default(EntityRef<Category>);
        }
        
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public override int ID { get; set; }

        [Column]
        public string Name { get; set; }

        private EntityRef<Category> _Parent;

        [Association(Storage = "_Parent", ThisKey = "ParentID", OtherKey = "ID", IsForeignKey = true)]
        public Category Parent
        {
            get { return this._Parent.Entity; }
            set
            {
                if (this._Parent.HasLoadedOrAssignedValue == false)
                {
                    this._Parent.Entity = value;
                }
            }
        }

        [Association(ThisKey = "ID", OtherKey = "ParentID")]
        public EntitySet<Category> Children { get; set; }

        [Association(OtherKey = "CategoryID")]
        public EntitySet<Post> Posts { get; set; }

        [Association(OtherKey = "CategoryID")]
        public EntitySet<AdPost> AdPosts { get; set; }

        [Association(OtherKey = "CategoryID")]
        public EntitySet<Video> Videos { get; set; }

        [Column]
        public int? ParentID { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "[Category] ID: " + ID + ", Name: " + Name + ", Parent: " + (Parent == null) + ", Children: " + Children.Count() +  "\nPostFound: " + Posts.Count() + ", AdPostFound: " + AdPosts.Count();
        }
    }
}
