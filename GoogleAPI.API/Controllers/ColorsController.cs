using GoogleAPI.Domain.Entities;
using GoogleAPI.Domain.Models.Product.ViewModel;
using GooleAPI.Application.Abstractions.IServices.IColor;
using Microsoft.AspNetCore.Mvc;

namespace GoogleAPI.API.Controllers
{
    [Route("api/colors")]
    [ApiController]
    //[Authorize(AuthenticationSchemes ="Admin")]
    public class ColorsController : ControllerBase
    {
        private readonly IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet("Get")]
        public async Task<ActionResult<IEnumerable<Color_VM>>> GetColors(int id)
        {
            try
            {
                List<Color_VM> colors = await _colorService.GetColors(id);
                return colors;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Add")]
        public async Task<ActionResult<Color>> AddColor(Color_VM model)
        {
            try
            {
                bool response = await _colorService.AddColor(model);

                if (response)
                {
                    return Ok(true);
                }
                else
                {
                    return BadRequest("Color could not be added.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("update")]
        public async Task<ActionResult<bool>> UpdateColor(Color_VM model)
        {
            try
            {
                bool response = await _colorService.UpdateColor(model);

                if (response)
                {
                    return Ok(true);
                }
                else
                {
                    return BadRequest("Personal could not be added.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteColor([FromRoute] int id)
        {
            try
            {
                bool response = await _colorService.DeleteColor(id);

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