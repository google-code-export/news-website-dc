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
    [Table(Name = "UserMessages")]
    public class UserMessage : Base<int>, ISerializable
    {
        public UserMessage()
        {
            this._userProfile = default(EntityRef<UserProfile>);
        }
        
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public override int ID { get; set; }

        [Column]
        public string From
        {
            get;
            set;
        }
        //FK
        [Column]
        public string To { get; set; }

        private EntityRef<UserProfile> _userProfile;

        [Association(Storage = "_userProfile", ThisKey = "To", OtherKey = "ID", IsForeignKey = true)]
        public UserProfile UserProfile
        {
            get { return this._userProfile.Entity; }
            set
            {
                To = value.ID;

                if (this._userProfile.HasLoadedOrAssignedValue == false)
                {
                    this._userProfile.Entity = value;
                }
            }
        }

        [Column]
        public string Title
        {
            get;
            set;
        }
        [Column]
        public string Content
        {
            get;
            set;
        }
        [Column]
        public System.DateTime UpdatedOn
        {
            get;
            set;
        }
        [Column]
        public bool Read
        {
            get;
            set;
        }

        public override string ToString()
        {
            return "[UserMessage] ID: " + ID + ", Content: " + Content;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
