using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq.Mapping;
using System.Text;
using System.Runtime.Serialization;
using Vietstream.Data.Model;


namespace NewsVn.Impl.Entity
{
    [Table(Name = "MemberProfiles")]
    public class MemberProfile : Base, ISerializable
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = false)]
        public string Account { get; set; }

        [Column]
        public string Name { get; set; }

        [Column]
        public string IdNumber { get; set; }

        [Column]
        public string Phone { get; set; }

        [Column]
        public string Email { get; set; }

        [Column]
        public DateTime? DOB { get; set; }

        [Column]
        public bool? Gender { get; set; }

        [Column]
        public string Location { get; set; }

        [Column]
        public string Education { get; set; }

        [Column]
        public DateTime UpdatedOn { get; set; }

        [Column]
        public string UpdatedBy { get; set; }
        
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
