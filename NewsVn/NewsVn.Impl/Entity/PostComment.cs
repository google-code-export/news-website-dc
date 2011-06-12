using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;
using Vietstream.Data.Model;
using System.Data.Linq;

namespace NewsVn.Impl.Entity
{
    [Table(Name = "PostComments")]
    public class PostComment : Base<int>, ISerializable
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public override int ID { get; set; }
        //FK
        [Association(OtherKey = "PostID")]
        public EntitySet<Post> Posts { get; set; }
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
