using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using TCC.Models;

namespace TCC.Brands.Dto
{ 
    public class BrandJSONDto
    {
        [BsonSerializer(typeof(BsonStringNumericSerializer))]
        public string Id { get; set; }
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
