using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Runtime.Serialization;
using Vietstream.Data.Model;

namespace NewsVn.Impl.Entity
{
    [Table(Name = "Categories")]
    public class Category : Base, ISerializable
    {
        public Category()
        {
            if (this._parent.Entity == null)
                this._parent = new EntityRef<Category>();
            if (this.Children == null)
                this.Children = new EntitySet<Category>();
            if (this.Posts == null)
                this.Posts = new EntitySet<Post>();
            if (this.AdPosts == null)
                this.AdPosts = new EntitySet<AdPost>();
            if (this.Videos == null)
                this.Videos = new EntitySet<Video>();
        }
        
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }

        private EntityRef<Category> _parent;

        [Association(Storage = "_parent", ThisKey = "ParentID", OtherKey = "ID", IsForeignKey = true)]
        public Category Parent
        {
            get { return this._parent.Entity; }
            set
            {
                ParentID = value.ID;
                
                if (this._parent.HasLoadedOrAssignedValue == false)
                {
                    this._parent.Entity = value;
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
        
        [Column]
        public string Type { get; set; }

        [Column]
        public string Name { get; set; }

        [Column]
        public string Description { get; set; }

        [Column]
        public string SeoName { get; set; }

        [Column]
        public string SeoUrl { get; set; }

        [Column]
        public DateTime UpdatedOn { get; set; }

        [Column]
        public bool Actived { get; set; }

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
