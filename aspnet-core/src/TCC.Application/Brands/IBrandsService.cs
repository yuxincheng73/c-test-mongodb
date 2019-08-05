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
        Task<ListResultDto<BrandDto>> GetBrands();
        Task<BrandJSONDto> GetBrand(int id);
        Task<BrandDto> GetBrandbyName(string name);
        Task<int> CreateBrand(CreateBrandDto input);
        Task<BrandJSONDto> UpdateBrand(dynamic input);
        Task<int> DeleteBrand(EntityDto input);
    }
}
