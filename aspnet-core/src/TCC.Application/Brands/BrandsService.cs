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

        public async Task<int> CreateBrand(BrandDto input)
        {
            var brand = ObjectMapper.Map<Brand>(input);
            brand.Discoverable = false;
            brand.SortingOrder = brand.Id;
            brand.TimeZone = DateTime.UtcNow.ToString();
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
            var brandToReturn = await MapToJson(brand);
            return brandToReturn;
            //return ObjectMapper.Map<BrandDto>(brand);
        }

        public async Task<BrandJSONDto> GetBrandbyName(string name, string language_code)
        {
            var jsonName = "{\"content\":\"" + name + "\",\"language_code\":\"" + language_code + "\"}";
            var brand = await _brandRepository.FirstOrDefaultAsync(c => c.Name == jsonName);
            var brandToReturn = await MapToJson(brand);
            return brandToReturn;
            //return ObjectMapper.Map<BrandDto>(brand);
        }

        public async Task<List<BrandJSONDto>> GetBrands()
        {
            var brands = await _brandRepository.GetAllListAsync(c => c.Name != null);
            var brandsToReturn = new List<BrandJSONDto>();
            foreach(Brand brand in brands)
            {
                brandsToReturn.Add(await MapToJson(brand));
            }
            return brandsToReturn;
            //return new ListResultDto<BrandJSONDto>(ObjectMapper.Map<List<BrandJSONDto>>(brands));
        }

        public async Task<BrandJSONDto> UpdateBrand(BrandDto input)
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
                Id = input.Id,
                Name = JObject.Parse(input.Name),
                Description = JObject.Parse(input.Description),
                Url = input.Url,
                Logo = input.Logo,
                CoverImage = input.CoverImage,
            };
            return brandToReturn;
        }
    }
}
