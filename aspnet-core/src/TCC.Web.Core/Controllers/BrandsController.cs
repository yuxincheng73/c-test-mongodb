using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        public async Task<IActionResult> GetBrandbyName([FromQuery] string name, [FromQuery] string language_code)
        {
            var brand = await _brandsService.GetBrandbyName(name, language_code);
            if(brand == null)
            {
                return NotFound();
            }
            return Ok(brand);
        }

        [HttpPost]
        [Route("brand")]
        public async Task<IActionResult> CreateBrand(dynamic input)
        {
            if (input == null)
            {
                return BadRequest();
            }
            var brand = new BrandDto
            {
                Name = input.name.ToString(Formatting.None),
                Description = input.description.ToString(Formatting.None),
                Url = input.url,
                Logo = input.logo,
                CoverImage = input.coverimage
            };
            return Ok(await _brandsService.CreateBrand(brand));
        }

        [HttpPut]
        [Route("brand")]
        public async Task<IActionResult> UpdateBrand(dynamic input)
        {
            if (input == null)
            {
                return NotFound();
            }
            var brandToUpdate = new BrandDto
            {
                Id = (int)input.id,
                Name = input.name.ToString(Formatting.None),
                Description = input.description.ToString(Formatting.None),
                Logo = input.logo.ToString(Formatting.None),
                CoverImage = input.coverimage.ToString(Formatting.None),
                Url = input.url.ToString(Formatting.None),
            };
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
