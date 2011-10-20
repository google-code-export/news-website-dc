using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;
using Vietstream.Data.Model;

namespace NewsVn.Impl.Entity
{
    [Table(Name = "AdPosts")]
    public class AdPost : Base, ISerializable
    {
        public AdPost()
        {
            if (this._category.Entity == null)
                this._category = new EntityRef<Category>();
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

        [Column]
        public string Title { get; set; }

        [Column]
        public string Avatar { get; set; }

        [Column]
        public string Content { get; set; }

        [Column]
        public string Location { get; set; }

        [Column]
        public string SeoUrl { get; set; }

        [Column]
        public string Tag { get; set; }

        [Column]
        public decimal Payment { get; set; }

        [Column]
        public string Contact { get; set; }

        [Column]
        public string ContactEmail { get; set; }

        [Column]
        public string ContactAddress { get; set; }

        [Column]
        public string ContactPhone { get; set; }

        [Column]
        public DateTime CreatedOn { get; set; }

        [Column]
        public string CreatedBy { get; set; }

        [Column]
        public DateTime? UpdatedOn { get; set; }

        [Column]
        public string UpdatedBy { get; set; }

        [Column]
        public DateTime ExpiredOn { get; set; }

        [Column]
        public bool Actived { get; set; }

        [Column]
        public string TitleAscii { get; set; }

        public override string ToString()
        {
            return "[Adpost]";
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
