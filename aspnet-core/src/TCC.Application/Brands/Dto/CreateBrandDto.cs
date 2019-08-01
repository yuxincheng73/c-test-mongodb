using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TCC.Models;

namespace TCC.Brands.Dto
{
    [AutoMapTo(typeof(Brand))]
    public class CreateBrandDto : EntityDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Logo { get; set; }
        public string CoverImage { get; set; }
    }
}
