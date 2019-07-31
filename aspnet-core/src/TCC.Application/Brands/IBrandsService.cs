using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TCC.Brands.Dto;
using TCC.Models;

namespace TCC.Brands
{
    public interface IBrandsService : IApplicationService
    {
        Task<BrandDto> GetBrands();
        Task<BrandDto> GetBrand(int id);
        Task<BrandDto> CreateBrand(CreateBrandDto input);
        Task<BrandDto> UpdateBrand(BrandDto input);
        Task<BrandDto> DeleteBrand(EntityDto input);
    }
}
