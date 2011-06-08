using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;

namespace Linq2SqlEx.Data.Entity
{
    [Table(Name = "Posts")]
    public class Post : Base, ISerializable
    {
        [Column(IsPrimaryKey = true)]
        public int ID { get; set; }

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
