using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Newtonsoft.Json.Linq;
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
        Task<List<BrandJSONDto>> GetBrands();
        Task<BrandJSONDto> GetBrand(int id);
        Task<BrandJSONDto> GetBrandbyName(string name, string language_code);
        Task<int> CreateBrand(BrandDto input);
        Task<BrandJSONDto> UpdateBrand(BrandDto input);
        Task<int> DeleteBrand(EntityDto input);
    }
}
