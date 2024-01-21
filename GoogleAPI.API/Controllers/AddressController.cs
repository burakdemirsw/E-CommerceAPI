
using Microsoft.AspNetCore.Mvc;

namespace GoogleAPI.API.Controllers
{
    [Route("api/addresses")]
    [ApiController]
    [Authorize(AuthenticationSchemes ="Admin")]
    public class AddressController : ControllerBase
    {

        readonly IGoogle
        [HttpGet("get-provinces/{id}")]
        public async Task<ActionResult> GetProvinces(int brandId)
        {
            return Ok();

        }


        [HttpGet("get-districts/{id}")]
        public async Task<ActionResult> GetDistrics(int brandId)
        {
            return Ok();
            
        }

        [HttpGet("get-neigborhood/{id}")]
        public async Task<ActionResult> GetNeighborhoods(int brandId)
        {
            return Ok();

        }



    }
}
