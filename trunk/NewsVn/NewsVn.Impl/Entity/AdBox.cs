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
    [Table(Name = "AdBoxes")]
    public class AdBox : Base, ISerializable
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }

        [Column]
        public string Title
        {
            get;
            set;
        }
        [Column]
        public string SourceUrl
        {
            get;
            set;
        }
        [Column]
        public string SourceEmbed
        {
            get;
            set;
        }
        [Column]
        public string LinkTo
        {
            get;
            set;
        }
        [Column]
        public decimal Payment
        {
            get;
            set;
        }
        [Column]
        public int DisplayOrder
        {
            get;
            set;
        }
        [Column]
        public System.DateTime CreatedOn
        {
            get;
            set;
        }
        [Column]
        public string CreatedBy
        {
            get;
            set;
        }
        [Column]
        public DateTime? UpdatedOn
        {
            get;
            set;
        }
        [Column]
        public string UpdatedBy
        {
            get;
            set;
        }
        [Column]
        public bool Actived
        {
            get;
            set;
        }


        public override string ToString()
        {
            return "[Adbox]";
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
