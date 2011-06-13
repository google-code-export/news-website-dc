using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;
using Vietstream.Data.Model;
using System.Data.Linq;

namespace Vietstream.Test.Entity
{
    [Table(Name = "PostComments")]
    public class PostComment : Base, ISerializable
    {
        public PostComment()
        {
            this._post = default(EntityRef<Post>);
        }
        
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }
        
        //FK
        [Column]
        public int PostID { get; set; }

        private EntityRef<Post> _post;

        [Association(Storage = "_post", ThisKey = "PostID", OtherKey = "ID", IsForeignKey = true)]
        public Post Post
        {
            get { return this._post.Entity; }
            set
            {
                PostID = value.ID;
                
                if (this._post.HasLoadedOrAssignedValue == false)
                {
                    this._post.Entity = value;
                }
            }
        }
        
        [Column]
        public  string Title
        {
            get;
            set;
        }
         [Column]
        public  string Content
        {
            get;
            set;
        }
         [Column]
        public  System.DateTime UpdatedOn
        {
            get;
            set;
        }
         [Column]
        public  string UpdatedBy
        {
            get;
            set;
        }
         [Column]
        public  string Email
        {
            get;
            set;
        }
       

        public override string ToString()
        {
            return "[postComments]";
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
