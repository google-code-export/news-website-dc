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
    [Table(Name = "UserProfiles")]
    public class UserProfile : Base<string>, ISerializable
    {
        [Column(Name = "Account", IsPrimaryKey = true)]
        public override string ID { get; set; }

        [Association(OtherKey = "To")]
        public EntitySet<UserMessage> UserMessages { get; set; }

        [Association(OtherKey = "ForAccount")]
        public EntitySet<UserProfileComment> UserProfileComments { get; set; }
        
        [Column]
        public string Nickname
        {
            get;
            set;
        }
        [Column]
        public string Name
        {
            get;
            set;
        }
        [Column]
        public int Age
        {
            get;
            set;
        }
        [Column]
        public bool Gender
        {
            get;
            set;
        }
        [Column]
        public string Avatar
        {
            get;
            set;
        }
        [Column]
        public string Location
        {
            get;
            set;
        }
        [Column]
        public string Country
        {
            get;
            set;
        }
        [Column]
        public string Email
        {
            get;
            set;
        }
        [Column]
        public string Phone
        {
            get;
            set;
        }
        [Column]
        public bool ShowEmail
        {
            get;
            set;
        }
        [Column]
        public bool ShowPhone
        {
            get;
            set;
        }
        [Column]
        public int? Height
        {
            get;
            set;
        }
        [Column]
        public int? Weight
        {
            get;
            set;
        }
        [Column]
        public string BodyShape
        {
            get;
            set;
        }
        [Column]
        public bool? Drink
        {
            get;
            set;
        }
        [Column]
        public bool? Smoke
        {
            get;
            set;
        }
        [Column]
        public string MaritalStatus
        {
            get;
            set;
        }
        [Column]
        public string Religion
        {
            get;
            set;
        }
        [Column]
        public string Education
        {
            get;
            set;
        }
        [Column]
        public string Career
        {
            get;
            set;
        }
        [Column]
        public string Description
        {
            get;
            set;
        }
        [Column]
        public string Expectation
        {
            get;
            set;
        }
        [Column]
        public DateTime UpdatedOn
        {
            get;
            set;
        }

        public override string ToString()
        {
            return "[userprofiles] ID: " + ID + ", Name: " + Nickname;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
