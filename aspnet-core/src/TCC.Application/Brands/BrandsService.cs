using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using TCC.Brands.Dto;
using TCC.Models;

namespace TCC.Brands
{
    public class BrandsService : IBrandsService
    {
        private readonly IRepository<Brand> _brandRepository;

        public BrandsService(IRepository<Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public Task<BrandDto> CreateBrand(CreateBrandDto input)
        {
            throw new NotImplementedException();
        }

        public Task<BrandDto> DeleteBrand(EntityDto input)
        {
            throw new NotImplementedException();
        }

        public Task<BrandDto> GetBrand(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BrandDto> GetBrands()
        {
            throw new NotImplementedException();
        }

        public Task<BrandDto> UpdateBrand(BrandDto input)
        {
            throw new NotImplementedException();
        }
    }
}
