using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TCC.Models
{
    public class Brand : Entity, IHasCreationTime, ISoftDelete
    {
        [Column("name")]
        public string Name { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("url")]
        public string Url { get; set; }
        public string Logo { get; set; }
        [Column("cover_image")]
        public string CoverImage { get; set; }
        [Column("discoverable")]
        public bool Discoverable { get; set; }
        [Column("sorting_order")]
        public int SortingOrder { get; set; }
        //CreationTime is used in replacement of LaunchDate due to inheritance of IHasCreationTime
        [Column("launch_date")]
        public DateTime CreationTime { get; set; }
        [Column("time_zone")]
        public string TimeZone { get; set; }
        public bool IsDeleted { get; set; }

        public Brand()
        {
            CreationTime = Clock.Now;
        }
    }
}
