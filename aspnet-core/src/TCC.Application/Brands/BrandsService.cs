using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;
using TCC.Brands.Dto;
using TCC.Models;

namespace TCC.Brands
{
    public class BrandsService : TCCAppServiceBase, IBrandsService 
    {
        private readonly IMongoCollection<Brand> _brandRepository;

        public BrandsService(IBrandsDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _brandRepository = database.GetCollection<Brand>(settings.BrandsCollectionName);
        }

        public async Task<string> CreateBrand(BrandDto input)
        {
            var brand = ObjectMapper.Map<Brand>(input);
            brand.Discoverable = false;
            brand.SortingOrder = brand.Id;
            brand.TimeZone = DateTime.UtcNow.ToString();
            await _brandRepository.InsertOneAsync(brand);
            return brand.Id;
        }

        public async Task<string> DeleteBrand(string id)
        {
            if(id == null)
            {
                return "Deletion Failed";
            }
            await _brandRepository.DeleteOneAsync(c => c.Id == id);
            return "Deletion Successful";
        }

        public async Task<BrandJSONDto> GetBrand(string id)
        {
            var brand = await _brandRepository.FindAsync<Brand>(c => c.Id == id);
            //var brandDto = ObjectMapper.Map<BrandDto>(brand).ToString();
            var brandToReturn = await MapToJson(brand.FirstOrDefault());
            return brandToReturn;
            //return ObjectMapper.Map<BrandDto>(brand);
        }

        public async Task<BrandJSONDto> GetBrandbyName(string name, string language_code)
        {
            var jsonName = "{\"content\":\"" + name + "\",\"language_code\":\"" + language_code + "\"}";
            var brand = await _brandRepository.FindAsync<Brand>(c => c.Name == jsonName);
            var brandToReturn = await MapToJson(brand.FirstOrDefault());
            return brandToReturn;
            //return ObjectMapper.Map<BrandDto>(brand);
        }

        public async Task<List<BrandJSONDto>> GetBrands()
        {
            var brands = await _brandRepository.Find(c => true).ToListAsync();
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
            var brandToUpdate = Builders<Brand>.Update.Set("Id", brand.Id)
                .Set("Name", brand.Name)
                .Set("Description", brand.Description)
                .Set("Url", brand.Url)
                .Set("Logo", brand.Logo)
                .Set("CoverImage", brand.CoverImage);
            var updatedBrand = await _brandRepository.FindOneAndUpdateAsync(Builders<Brand>.Filter.Eq(c => c.Id, brand.Id), brandToUpdate, new FindOneAndUpdateOptions<Brand> { ReturnDocument = ReturnDocument.After });
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
