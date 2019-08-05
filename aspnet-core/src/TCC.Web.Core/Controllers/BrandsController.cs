using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TCC.Brands;
using TCC.Brands.Dto;

namespace TCC.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/service")]
    public class BrandsController : TCCControllerBase
    {
        private readonly IBrandsService _brandsService;

        public BrandsController(IBrandsService brandsService)
        {
            _brandsService = brandsService;
        }

        [HttpGet]
        [Route("brands")]
        public async Task<IActionResult> GetBrands()
        {
            var brands = await _brandsService.GetBrands();
            if(brands == null)
            {
                return NotFound();
            }
            return Ok(brands);
        }

        [HttpGet]
        [Route("brand/{id}")]
        public async Task<IActionResult> GetBrand(int id)
        {
            var brand = await _brandsService.GetBrand(id);
            if (brand == null)
            {
                return NotFound();
            }
            return Ok(brand);
        }

        [HttpGet]
        [Route("brand")]
        public async Task<IActionResult> GetBrandbyName([FromQuery] string name)
        {
            var brand = await _brandsService.GetBrandbyName(name);
            if(brand == null)
            {
                return NotFound();
            }
            return Ok(brand);
        }

        [HttpPost]
        [Route("brand")]
        public async Task<IActionResult> CreateBrand(CreateBrandDto input)
        {
            if (input == null)
            {
                return BadRequest();
            }
            return Ok(await _brandsService.CreateBrand(input));
        }

        [HttpPut]
        [Route("brand")]
        public async Task<IActionResult> UpdateBrand(dynamic input)
        {
            var brandToUpdate = new BrandDto
            {
                Id = input.Id,
                Name = input.Name,
                Description = input.Description,
                Logo = input.Logo,
                CoverImage = input.CoverImage,
                Url = input.Url,
            };

            if(input == null)
            {
                return NotFound();
            }
            return Ok(await _brandsService.UpdateBrand(brandToUpdate));
        }

        [HttpDelete]
        [Route("brand")]
        public async Task<IActionResult> DeleteBrand(EntityDto input)
        {
            if(input == null)
            {
                return NotFound();
            }
            await _brandsService.DeleteBrand(input);
            return Ok();
        }
    }
}
