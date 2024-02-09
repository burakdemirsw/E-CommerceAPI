// BrandsController.cs

using GoogleAPI.Domain.Entities;
using GoogleAPI.Domain.Models.Brand.ViewModel;
using GooleAPI.Application.Abstractions.IServices.IBrand;
using Microsoft.AspNetCore.Mvc;

namespace GoogleAPI.API.Controllers
{
    [Route("api/brands")]
    [ApiController]
    //[Authorize(AuthenticationSchemes ="Admin")]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet("Get/{brandId}")]
        public async Task<ActionResult<IEnumerable<Brand_VM>>> GetCategories(int brandId)
        {
            try
            {
                List<Brand_VM> brands = await _brandService.GetBrandById(brandId);
                return brands;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Add")]
        public async Task<ActionResult<Brand>> AddBrand(Brand_VM brand)
        {
            try
            {
                bool response = await _brandService.AddBrand(brand);

                if (response)
                {
                    return Ok(true);
                }
                else
                {
                    return BadRequest("Brand could not be added.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Update")]
        public async Task<ActionResult<Brand>> AddUpdate(Brand_VM brand)
        {
            try
            {
                bool response = await _brandService.UpdateBrand(brand);

                if (response)
                {
                    return Ok(true);
                }
                else
                {
                    return BadRequest("Brand could not be updated.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            try
            {
                bool response = await _brandService.DeleteBrand(id);

                if (response)
                {
                    return Ok(true);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
