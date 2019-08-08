using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using MongoDB.Bson;

namespace TCC.Models
{
    public class Brand : IHasCreationTime, ISoftDelete
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Name")]
        [Column("name")]
        public string Name { get; set; }
        [BsonElement("Description")]
        [Column("description")]
        public string Description { get; set; }
        [BsonElement("Url")]
        [Column("url")]
        public string Url { get; set; }
        [BsonElement("Logo")]
        [Column("logo")]
        public string Logo { get; set; }
        [BsonElement("CoverImage")]
        [Column("cover_image")]
        public string CoverImage { get; set; }
        [BsonElement("Discoverable")]
        [Column("discoverable")]
        public bool Discoverable { get; set; }
        [BsonElement("SortingOrder")]
        [Column("sorting_order")]
        public string SortingOrder { get; set; }
        [BsonElement("CreationTime")]
        [Column("launch_date")]
        public DateTime CreationTime { get; set; }
        [BsonElement("TimeZone")]
        [Column("time_zone")]
        public string TimeZone { get; set; }
        public bool IsDeleted { get; set; }

        public Brand()
        {
            CreationTime = Clock.Now;
        }
    }
}
