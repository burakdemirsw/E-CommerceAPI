// BrandsController.cs

using GoogleAPI.Domain.Entities;
using GoogleAPI.Domain.Models.Brand.ViewModel;
using GooleAPI.Application.Abstractions.IServices.Configuration;
using GooleAPI.Application.Abstractions.IServices.IBrand;
using GooleAPI.Application.Configuration;
using GooleAPI.Application.CustomAttributes;
using GooleAPI.Application.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoogleAPI.API.Controllers
{
    [Route("api/ApplicationServices")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class ApplicationServicesController : ControllerBase
    {
        readonly IApplicationService _applicationService;

        public ApplicationServicesController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet("get-authorize-definition-endpoints")]
        [AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Get Authorize Definition Endpoints", Menu = "Application Services")]
        public async  Task<IActionResult> GetAuthorizeDefinitionEndpoints( )
        {
            List<GooleAPI.Application.Configuration.Menu> datas = await _applicationService.GetAuthorizeDefinitionEndpoints(typeof(Program));
            return Ok(datas);
        }
    }
}
