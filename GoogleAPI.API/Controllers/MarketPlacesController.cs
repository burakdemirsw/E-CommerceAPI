using GoogleAPI.Domain.Entities;
using GoogleAPI.Domain.Models.MarketPlace.ViewModel;
using GooleAPI.Application.Abstractions.IServices.IMarketPlace;
using Microsoft.AspNetCore.Mvc;

namespace GoogleAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketPlacesController : ControllerBase
    {
        private readonly IMarketPlaceService _MarketPlaceService;

        public MarketPlacesController(IMarketPlaceService MarketPlaceService)
        {
            _MarketPlaceService = MarketPlaceService;
        }

        [HttpGet("Get/{MarketPlaceId}")]
        public async Task<ActionResult<IEnumerable<MarketPlace_VM>>> GetCategories(int MarketPlaceId)
        {
            try
            {
                List<MarketPlace_VM> MarketPlaces = await _MarketPlaceService.GetMarketPlaceById(MarketPlaceId);
                return MarketPlaces;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Add")]
        public async Task<ActionResult<MarketPlace>> AddMarketPlace(MarketPlace_VM MarketPlace)
        {
            try
            {
                bool response = await _MarketPlaceService.AddMarketPlace(MarketPlace);

                if (response)
                {
                    return Ok(true);
                }
                else
                {
                    return BadRequest("MarketPlace could not be added.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Update")]
        public async Task<ActionResult<MarketPlace>> AddUpdate(MarketPlace_VM MarketPlace)
        {
            try
            {
                bool response = await _MarketPlaceService.UpdateMarketPlace(MarketPlace);

                if (response)
                {
                    return Ok(true);
                }
                else
                {
                    return BadRequest("MarketPlace could not be updated.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteMarketPlace(int id)
        {
            try
            {
                bool response = await _MarketPlaceService.DeleteMarketPlace(id);

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
