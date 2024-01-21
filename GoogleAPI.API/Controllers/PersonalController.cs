using GoogleAPI.Domain.Entities;
using GoogleAPI.Domain.Models.Personal.ViewModel;
using GooleAPI.Application.Abstractions.IServices.IPersonal;
using GooleAPI.Application.Consts;
using GooleAPI.Application.CustomAttributes;
using GooleAPI.Application.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoogleAPI.API.Controllers
{
    [Route("api/personals")]
    [ApiController]

    public class PersonalsController : ControllerBase
    {
        private readonly IPersonalService _personalService;

        public PersonalsController(IPersonalService personalService)
        {
            _personalService = personalService;
        }

        [HttpGet("get")]

        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Personals, ActionType = ActionType.Reading, Definition = "Get Personals")]
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
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Personals, ActionType = ActionType.Writing, Definition = "Add Personal")]
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
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Personals, ActionType = ActionType.Updating
            , Definition = "Update Personal")]
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
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Personals, ActionType = ActionType.Deleting
            , Definition = "Delete Personal")]
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