using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;
using Vietstream.Data.Model;

namespace NewsVn.Impl.Entity
{
    [Table(Name = "UserProfiles")]
    public class UserProfile : Base, ISerializable
    {
        public UserProfile()
        {
            if (this.UserMessages == null)
                this.UserMessages = new EntitySet<UserMessage>();
            if (this.UserProfileComments == null)
                this.UserProfileComments = new EntitySet<UserProfileComment>();
        }
        [Column(IsPrimaryKey = true)]
        public string Account { get; set; }

        [Association(OtherKey = "To")]
        public EntitySet<UserMessage> UserMessages { get; set; }

        [Association(OtherKey = "ForAccount")]
        public EntitySet<UserProfileComment> UserProfileComments { get; set; }
        
        [Column]
        public string Nickname { get; set; }

        [Column]
        public string Name { get; set; }

        [Column]
        public int Age { get; set; }

        [Column]
        public int? Gender { get; set; }

        [Column]
        public string Avatar { get; set; }

        [Column]
        public int? Location { get; set; }

        [Column]
        public int? Country { get; set; }

        [Column]
        public string Email { get; set; }

        [Column]
        public string Phone { get; set; }

        [Column]
        public bool ShowEmail { get; set; }

        [Column]
        public bool ShowPhone { get; set; }

        [Column]
        public int? Height { get; set; }

        [Column]
        public int? Weight { get; set; }

        [Column]
        public string BodyShape { get; set; }

        [Column]
        public bool? Drink { get; set; }

        [Column]
        public bool? Smoke { get; set; }

        [Column]
        public int? MaritalStatus { get; set; }

        [Column]
        public int? Religion { get; set; }

        [Column]
        public int? Education { get; set; }

        [Column]
        public string Career { get; set; }

        [Column]
        public string Description { get; set; }

        [Column]
        public string Expectation { get; set; }

        [Column]
        public DateTime UpdatedOn { get; set; }

        public override string ToString()
        {
            return "[userprofiles] ID: " + Account + ", Name: " + Nickname;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
        //public  void WriteTextLog( string err)
        //{
        //    StreamWriter logFile = File.AppendText("C:\\logfile.txt");
        //    logFile.WriteLine(err);
        //    logFile.Close();
        //}
    }
}
