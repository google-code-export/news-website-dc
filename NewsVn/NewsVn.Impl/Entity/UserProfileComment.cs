using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;
using Vietstream.Data.Model;

namespace NewsVn.Impl.Entity
{
    [Table(Name = "UserProfileComments")]
    public class UserProfileComment : Base, ISerializable
    {
        public UserProfileComment()
        {
            if (this._userProfile.Entity == null)
                this._userProfile = new EntityRef<UserProfile>();
        }

        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }
        
        [Column]
        public string ForAccount { get; set; }

        private EntityRef<UserProfile> _userProfile;

        [Association(Storage = "_userProfile", ThisKey = "ForAccount", OtherKey = "Account", IsForeignKey = true)]
        public UserProfile UserProfile
        {
            get { return this._userProfile.Entity; }
            set
            {
                ForAccount = value.Account;

                if (this._userProfile.HasLoadedOrAssignedValue == false)
                {
                    this._userProfile.Entity = value;
                }
            }
        }

        [Column]
        public string Title { get; set; }

        [Column]
        public string Content { get; set; }

        [Column]
        public System.DateTime UpdatedOn { get; set; }

        [Column]
        public string UpdatedBy { get; set; }

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
