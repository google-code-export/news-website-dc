using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;
using Vietstream.Data.Model;

namespace NewsVn.Impl.Entity
{
    [Table(Name = "Posts")]
    public class Post : Base<int>, ISerializable
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public override int ID { get; set; }

        [Column]
        public string Title { get; set; }

        [Column]
        public string Content { get; set; }

        [Column]
        public int CategoryID { get; set; }

        public override string ToString()
        {
            return "[Post] ID: " + ID + ", Title: " + Title + ", CategoryID: " + CategoryID;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
