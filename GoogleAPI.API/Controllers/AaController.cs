using GooleAPI.Application.Abstractions.IServices.IMail;
using GooleAPI.Application.Abstractions.IServices.IUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoogleAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AaController : ControllerBase
    {
        readonly IMailService _mailService;
        readonly IUserService _userService;

        public AaController(IMailService mailService, IUserService userService)
        {
            _userService = userService;
            _mailService = mailService;
        }

        [HttpGet]
        public async Task<IActionResult> SendMail( )
        {
            //await _mailService.SendMail(new List<string> { "demir.burock96@gmail.com" }, "Hello", "<strong>Hello WORLD.</strong>", true);
            //await _mailService.SendPasswordResetEmail("demir.burock96@gmail.com", "1", "1");
            await _userService.SendPasswordResetEmail("demir.burock96@gmail.com");
            return Ok();



        }
        [HttpPost]
        public async Task<IActionResult> SendMail(string decodedPassword)
        {
           
            var response = await _userService.ConfirmPasswordToken(decodedPassword);
            return Ok(response);
        }
    }
}
