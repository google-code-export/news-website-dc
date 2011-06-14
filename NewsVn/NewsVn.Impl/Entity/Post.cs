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
    [Table(Name = "Posts")]
    public class Post : Base, ISerializable
    {
        public Post()
        {
            if (this._category.Entity == null)
                this._category = new EntityRef<Category>();
            if (this.PostComments == null)
                this.PostComments = new EntitySet<PostComment>();
        }
        
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }

        [Column]
        public int CategoryID { get; set; }

        private EntityRef<Category> _category;

        [Association(Storage = "_category", ThisKey = "CategoryID", OtherKey = "ID", IsForeignKey = true)]
        public Category Category
        {
            get { return this._category.Entity; }
            set
            {
                CategoryID = value.ID;

                if (this._category.HasLoadedOrAssignedValue == false)
                {
                    this._category.Entity = value;
                }
            }
        }

        [Association(OtherKey = "PostID")]
        public EntitySet<PostComment> PostComments { get; set; }

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
