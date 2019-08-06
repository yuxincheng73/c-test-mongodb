using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace TCC.Brands.Dto
{
    public class BrandJSONDto : EntityDto
    {
        public JObject Name { get; set; }
        public JObject Description { get; set; }
        public string Url { get; set; }
        public string Logo { get; set; }
        public string CoverImage { get; set; }
        public override string ToString()
        {
            return $"Name:{Name}, Description:{Description}, Url:{Url}, Logo:{Logo}, CoverImage: {CoverImage}";
        }
    }
}
