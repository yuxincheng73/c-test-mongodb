using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using TCC.Models;

namespace TCC.Brands.Dto
{
    [AutoMap(typeof(Brand))]
    public class BrandDto 
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Logo { get; set; }
        public string CoverImage { get; set; }
    }
}
