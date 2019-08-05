using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using AutoMapper;
using Newtonsoft.Json.Linq;
using TCC.Brands.Dto;
using TCC.Models;

namespace TCC.Brands
{
    public class BrandsService : TCCAppServiceBase, IBrandsService 
    {
        private readonly IRepository<Brand> _brandRepository;

        public BrandsService(IRepository<Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<int> CreateBrand(CreateBrandDto input)
        {
            
            var brand = ObjectMapper.Map<Brand>(input);
            var brandId = await _brandRepository.InsertAndGetIdAsync(brand);
            return brandId;
        }

        public async Task<int> DeleteBrand(EntityDto input)
        {
            if(input == null)
            {
                return 0;
            }
            await _brandRepository.DeleteAsync(input.Id);
            return 1;
        }

        public async Task<BrandJSONDto> GetBrand(int id)
        {
            var brand = await _brandRepository.FirstOrDefaultAsync(c => c.Id == id);
            //var brandDto = ObjectMapper.Map<BrandDto>(brand).ToString();
            string json = $"{{\"content\": \"{brand.Name}\"}}" + $"\"language_code\": \"{brand.Name}\"}}";
            string json2 = $"{{\"content\": \"{brand.Description}\"}}" + $"{{\"language_code\": \"{brand.Description}\"}}";
            var lol = brand.Name;
            var loll = brand.Description;
            brand.Name = json;
            brand.Description = json2;
            var brandToReturn = await MapToJson(brand);
            return brandToReturn;
            //return ObjectMapper.Map<BrandDto>(brand);
        }

        public async Task<BrandDto> GetBrandbyName(string name)
        {
            var brand = await _brandRepository.FirstOrDefaultAsync(c => c.Name == name);
            return ObjectMapper.Map<BrandDto>(brand);
        }

        public async Task<ListResultDto<BrandDto>> GetBrands()
        {
            var brands = await _brandRepository.GetAllListAsync(c => c.Name != null);
            return new ListResultDto<BrandDto>(ObjectMapper.Map<List<BrandDto>>(brands));
        }

        public async Task<BrandJSONDto> UpdateBrand(dynamic input)
        {
            if (input == null)
            {
                return null;
            }
            var brand = ObjectMapper.Map<Brand>(input);
            var updatedBrand = await _brandRepository.UpdateAsync(brand);
            var brandToReturn = await MapToJson(updatedBrand);
            return brandToReturn;
            //return ObjectMapper.Map<BrandDto>(updatedBrand);
        }

        private async Task<BrandJSONDto> MapToJson(Brand input)
        {
            var brandToReturn = new BrandJSONDto
            {
                Name = JObject.Parse(input.Name),
                Description = JObject.Parse(input.Description),
                Url = input.Url,
                Logo = input.Logo,
                CoverImage = input.CoverImage,
            };
            System.Diagnostics.Debug.WriteLine(brandToReturn.Name);
            System.Diagnostics.Debug.WriteLine(brandToReturn.ToString());
            return brandToReturn;
        }
    }
}
