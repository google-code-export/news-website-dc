﻿using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;
using Vietstream.Data.Model;

namespace NewsVn.Impl.Entity
{
    [Table(Name = "Videos")]
    public class Video : Base, ISerializable
    {
        public Video()
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
        public string Description { get; set; }

        [Column]
        public string SourceUrl { get; set; }

        [Column]
        public string SourceEmbed { get; set; }

        [Column]
        public string SeoUrl { get; set; }

        [Column]
        public string Tag { get; set; }

        [Column]
        public int PageView { get; set; }

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
            return "[video]";
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
