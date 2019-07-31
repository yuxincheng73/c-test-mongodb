using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using System;
using System.Collections.Generic;
using System.Text;

namespace TCC.Models
{
    public class Brand : Entity, IHasCreationTime
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Logo { get; set; }
        public string CoverImage { get; set; }
        public bool Discoverable { get; set; }
        public int SortingOrder { get; set; }
        //CreationTime is used in replacement of LaunchDate due to inheritance of IHasCreationTime
        public DateTime CreationTime { get; set; }
        public string TimeZone { get; set; }

        public Brand()
        {
            CreationTime = Clock.Now;
        }
    }
}
