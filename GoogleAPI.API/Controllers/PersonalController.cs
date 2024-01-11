using GoogleAPI.Domain.Entities;
using GoogleAPI.Domain.Models.Personal.ViewModel;
using GooleAPI.Application.Abstractions.IServices.IPersonal;
using Microsoft.AspNetCore.Mvc;

namespace GoogleAPI.API.Controllers
{
    [Route("api/personals")]
    [ApiController]
    //[Authorize(AuthenticationSchemes ="Admin")]
    public class PersonalsController : ControllerBase
    {
        private readonly IPersonalService _personalService;

        public PersonalsController(IPersonalService personalService)
        {
            _personalService = personalService;
        }

        [HttpGet("get")]
        public async Task<ActionResult<IEnumerable<Personal_VM>>> GetPersonals(int id)
        {
            try
            {
                List<Personal_VM> personals = await _personalService.GetPersonals(id);
                return personals;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add")]
        public async Task<ActionResult<Menu>> AddPersonal(Personal_VM model)
        {
            try
            {
                bool response = await _personalService.AddPersonal(model);

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
        [HttpPost("update")]
        public async Task<ActionResult<Menu>> UpdatePersonal(Personal_VM model)
        {
            try
            {
                bool response = await _personalService.UpdatePersonal(model);

                if (response)
                {
                    return Ok(true);
                }
                else
                {
                    return BadRequest("color could not be updated.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeletePersonal(int id)
        {
            try
            {
                bool response = await _personalService.DeletePersonal(id);

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