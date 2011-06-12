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
        public int CategoryID { get; set; }

        [Column]
        public string Title { get; set; }

        [Column]
        public string Avatar { get; set; }

        [Column]
        public string Description { get; set; }

        [Column]
        public string Content { get; set; }

        [Column]
        public string SeoUrl { get; set; }

        [Column]
        public string Tag { get; set; }

        [Column]
        public int? PageView { get; set; }

        [Column]
        public bool CheckPageView { get; set; }

        [Column]
        public DateTime CreatedOn { get; set; }

        [Column]
        public string CreatedBy { get; set; }

        [Column]
        public DateTime? UpdatedOn { get; set; }

        [Column]
        public string UpdatedBy { get; set; }

        [Column]
        public bool AllowComments { get; set; }

        [Column]
        public bool Approved { get; set; }

        [Column]
        public DateTime? ApprovedOn { get; set; }

        [Column]
        public string ApprovedBy { get; set; }

        [Column]
        public bool Actived { get; set; }

       

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
