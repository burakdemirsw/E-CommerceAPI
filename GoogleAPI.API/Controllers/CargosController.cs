using GooleAPI.Application.Abstractions.IServices.ICargo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GoogleAPI.Domain.Entities.Cargo;
using System.Threading.Tasks;
using GoogleAPI.Domain.Models.Cargo.ViewModel;
using GooleAPI.Application.Abstractions.IServices.ICargo.IMng;
using GoogleAPI.Domain.Models.Cargo.Mng.Request;
using GoogleAPI.Persistance.Contexts;
using Google.Apis.Drive.v3;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Upload;
using GooleAPI.Application.Abstractions.IServices.FileUploadService;
using System.Text.Json;
using GoogleAPI.Domain.Models.File;



namespace GoogleAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargosController : ControllerBase
    {

        private readonly GooleAPIDbContext _context;

        private readonly ICargoService _cargoService;
        private readonly IMNGCargoService _mngCargoService;
        private readonly IFileUploadService _uploadService;
        public CargosController(ICargoService cargoService,IMNGCargoService mngCargoService, GooleAPIDbContext context, IFileUploadService uploadService)
        {
            _cargoService = cargoService;
            _mngCargoService = mngCargoService;
            _context = context;
            _uploadService = uploadService;
        }



          [HttpPost("upload-file")]
        public async Task<IActionResult> UploadFile([FromForm] UploadFileModel uploadFileModel )
        {
            var response = await _uploadService.UploadFileAsync2(uploadFileModel.File);
            UploadFileResultModel uploadResult= new UploadFileResultModel();
            uploadResult.Url = response.ToString();
            uploadResult.Result = "OK";
            return Ok(uploadResult);
        }

        [HttpPost("upload-files")]
        public async Task<IActionResult> UploadFile([FromForm] UploadFilesModel uploadFilesModel)
        {
            var response = await _uploadService.UploadFileAsync3(uploadFilesModel.Files);
            
            return Ok(response);
        }


        [HttpPost("add-cargo-firm")]
        public async Task<IActionResult> AddCargo([FromBody] CargoFirm cargo)
        {
            if (cargo == null)
            {
                return BadRequest("Cargo object is null");
            }

            bool success = await _cargoService.AddCargoFirm(cargo);
            if (success)
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
        }

        [HttpDelete("delete-cargo-firm/{cargoId}")]
        public async Task<IActionResult> DeleteCargo(int cargoId)
        {
            bool success = await _cargoService.DeleteCargoFirm(cargoId);
            if (success)
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
        }

        [HttpGet("get-cargo-firm-by-id/{cargoId}")]
        public async Task<IActionResult> GetCargo(int cargoId)
        {
            if(cargoId == -1)
            {
                List<CargoFirm> cargoFirms =  _context.CargoFirms.ToList();
                return Ok(cargoFirms);

            }
            CargoFirm cargo = await _cargoService.GetCargoFirmById(cargoId);
            if (cargo != null)
            {
                return Ok(cargo);
            }
            else
            {
                return Ok(false);
            }
        }

        [HttpGet("get-cargo-firms")]
        public async Task<ActionResult<List<CargoFirmList_VM>>> GetCargoList( )
        {
            List<CargoFirmList_VM> cargoList = await _cargoService.GetCargoFirmList();
            return Ok(cargoList);

   
        }

        [HttpPost("update-cargo-firm")]
        public async Task<IActionResult> UpdateCargo([FromBody] CargoFirm cargo)
        {
            if (cargo == null)
            {
                return BadRequest("Cargo object is null");
            }

            bool success = await _cargoService.UpdateCargoFirm(cargo);
            if (success)
            {
                return Ok(true);
            } 
            else
            {
                return Ok(false);
            }

        }

        [HttpGet("set-first-cargo-firm/{cargoId}")]
        public async Task<IActionResult> SetFirstCargoFirm(int cargoId)
        {
            bool success = await _cargoService.SetFirstCargoFirm(cargoId);
            if (success)
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
        }

        [HttpGet("get-first-cargo")]
        public async Task<IActionResult> GetFirstCargo()
        {
            CargoFirm success = await _cargoService.GetFirstCargo();
          
                return Ok(success);
          
        }
        [HttpGet("update-cargo-firm-properties/{cargoFirmId}/{state}")]
        public async Task<IActionResult> UpdateCargoFirmProperties(int cargoFirmId, int state)
        {
            bool response = await _cargoService.UpdateCargoFirmProperties(cargoFirmId, state);

            return Ok(response);
        }
    }

    
}
