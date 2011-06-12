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
    [Table(Name = "UserProfileComments")]
    public class UserProfileComment : Base<int>, ISerializable
    {
        public UserProfileComment()
        {
            this._userProfile = default(EntityRef<UserProfile>);
        }

        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public override int ID { get; set; }
        //FK
        //FK
        [Column]
        public int ForAccount { get; set; }

        private EntityRef<UserProfile> _userProfile;

        [Association(Storage = "_userProfile", ThisKey = "ForAccount", OtherKey = "Account", IsForeignKey = true)]
        public UserProfile UserProfile
        {
            get { return this._userProfile.Entity; }
            set
            {
                if (this._userProfile.HasLoadedOrAssignedValue == false)
                {
                    this._userProfile.Entity = value;
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
       

        public override string ToString()
        {
            return "[UserProfileComments]";
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
