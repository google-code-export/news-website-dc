using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;
using Vietstream.Data.Model;

namespace NewsVn.Impl.Entity
{
    [Table(Name = "BannerDetail")]
    public class BannerDetail : Base, ISerializable
    {

        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }

        [Column]
        public int BannerID { get; set; }

        [Column]
        public int Width { get; set; }

        [Column]
        public int Height { get; set; }

        [Column]
        public string Title { get; set; }

        [Column]
        public string Url { get; set; }

        [Column]
        public string LinkUrl { get; set; }

        [Column]
        public DateTime? Created { get; set; }

        [Column]
        public decimal? Price { get; set; }

        [Column]
        public string CustomerName { get; set; }

        [Column]
        public string CustomerDescription { get; set; }

        [Column]
        public bool Activated { get; set; }

        [Column]
        public int? TypeBanner { get; set; }

        [Column]
        public int? TypePosition { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }

    }

}
