using GoogleAPI.Domain.Models.Address;
using GoogleAPI.Domain.Models.User;
using GoogleAPI.Domain.Models.User.CommandModel;
using GoogleAPI.Domain.Models.User.Filters;
using GoogleAPI.Domain.Models.User.ResponseModel;
using GoogleAPI.Domain.Models.User.ViewModel;
using GooleAPI.Application.Abstractions.IServices.Authorization;
using GooleAPI.Application.Abstractions.IServices.IUser;
using GooleAPI.Application.Abstractions.IServices.Role;
using GooleAPI.Application.Consts;
using GooleAPI.Application.CustomAttributes;
using GooleAPI.Application.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoogleAPI.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly IUserService _userService;
        readonly IRoleService _roleService;
        readonly IAuthorizationEndpointService _authorizationEndpointService;

        public UsersController(IUserService userService, IRoleService roleService, IAuthorizationEndpointService authorizationEndpointService)
        {
            _userService = userService;
            _roleService = roleService;
            _authorizationEndpointService = authorizationEndpointService;

        }

        [HttpPost("register")]
        // [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Users, ActionType = ActionType.Writing, Definition = "Register User")]

        public async Task<ActionResult<bool>> Register(UserRegister_VM model)
        {
            bool response = await _userService.Register(model);

            if (response)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest("Kayıt başarısız.");
            }
        }

        [HttpPost("update")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Users, ActionType = ActionType.Updating, Definition = "Update User")]
        public async Task<ActionResult<bool>> Update(UserRegister_VM model)
        {
            bool response = await _userService.Update(model);

            if (response)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest("Kayıt başarısız.");
            }
        }





        [HttpPost("login")]
        //[Authorize(AuthenticationSchemes = "Admin")]
        //[AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Users, ActionType = ActionType.Reading, Definition = "Login")]
        public async Task<ActionResult<UserClientInfoResponse>> Login(UserLoginCommandModel model)
        {
            UserClientInfoResponse userClientInfoResponse = await _userService.Login(model);

            if (userClientInfoResponse != null)
            {
                return Ok(userClientInfoResponse);
            }
            else
            {
                return BadRequest("Giriş başarısız.");
            }
        }

        [HttpDelete("delete-user/{id}")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Users, ActionType = ActionType.Deleting, Definition = "Delete User")]
        public async Task<ActionResult<bool>> DeleteUser(int id)
        {
            bool response = await _userService.DeleteUser(id);

            if (response)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest("Kullanıcı silinirken bir hata oluştu.");
            }
        }

        [HttpPost("refresh-token")]
        //[Authorize(AuthenticationSchemes = "Admin")]
        //[AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Users, ActionType = ActionType.Updating, Definition = "Refresh Token")]
        public async Task<ActionResult<UserClientInfoResponse>> RefreshToken(
            [FromBody] RefreshTokenCommandModel RefreshToken
        )
        {
            UserClientInfoResponse result = await _userService.RefreshTokenLogin(
                RefreshToken.RefreshToken
            );

            return Ok(result);
            //return BadRequest(result);
        }

        [HttpPost("get-users")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Users, ActionType = ActionType.Reading, Definition = "Get Users")]

        public async Task<IActionResult> GetUsers(GetUserFilter? getUserFilter)
        {
            try
            {
                List<UserList_VM> users = await _userService.GetUsers(getUserFilter);
                if (users != null)
                {
                    return Ok(users);
                }
                else
                {
                    return BadRequest("error while getting users");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-roles")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Roles, ActionType = ActionType.Reading, Definition = "Get Roles")]

        public async Task<ActionResult<IEnumerable<Role_VM>>> GetRoles(int id)
        {
            try
            {
                List<Role_VM> roles = await _roleService.GetRoles(id);
                return roles;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("add-role")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Roles, ActionType = ActionType.Writing, Definition = "Add Role")]

        public async Task<ActionResult> AddRole(Role_VM model)
        {
            try
            {
                bool response = await _roleService.CreateRole(model);

                if (response)
                {
                    return Ok(true);
                }
                else
                {
                    return BadRequest("Role could not be added.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("update-role")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Roles, ActionType = ActionType.Updating, Definition = "Update Role")]

        public async Task<IActionResult> UpdateRole(Role_VM model)
        {
            try
            {
                bool response = await _roleService.UpdateRole(model);

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

        [HttpDelete("delete-role/{id}")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Roles, ActionType = ActionType.Deleting, Definition = "Delete Role")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            try
            {
                bool response = await _roleService.DeleteRole(id);

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
        [HttpPost("get-roles-to-endpoint")]
        public async Task<IActionResult> GetRolesToEndpoint(GetRolesToEndpointQueryRequest rolesToEndpointQueryRequest)
        {
            var response = await _authorizationEndpointService.GetRolesToEndpointAsync(rolesToEndpointQueryRequest);
            return Ok(response);
        }
        [HttpPost("assing-role-endpoint")] //AssignRoleEndpointAsync(AssignRoleUserCommandRequest
        public async Task<IActionResult> AssignRoleEndpoint(AssignRoleEndpointCommandRequest assignRoleEndpointCommandRequest)
        {
            assignRoleEndpointCommandRequest.Type = typeof(Program);
            var response = await _authorizationEndpointService.AssignRoleEndpointAsync(assignRoleEndpointCommandRequest);
            return Ok(response);
        }

        [HttpPost("assing-role-to-user")] //AssignRoleEndpointAsync(AssignRoleUserCommandRequest
        public async Task<IActionResult> AssignRoleToUserAsync(AssignRoleToUserCommandRequest model)
        {
            var response = await _userService.AssignRoleToUserAsync(model);
            if (response)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(model);
            }
        }

        [HttpGet("get-roles-of-user/{id}")] //AssignRoleEndpointAsync(AssignRoleUserCommandRequest
        public async Task<IActionResult> GetRolesOfUser(int id)
        {
            List<Role_VM> roleList = await _userService.GetRolesOfUser(id);
            if (roleList.Count > 0)
            {
                return Ok(roleList);
            }
            else
            {
                return BadRequest(id);
            }
        }

        #region USER&ADDRESS
        [HttpPost("add-shipping-address-to-user")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Users, ActionType = ActionType.Writing, Definition = "Add Shipping Address To User")]
        public async Task<ActionResult<AddUserShippingAddress_ResponseModel>> AddShippingAddressToUser(AddUserShippingAddressCommandModel model)
        {
            AddUserShippingAddress_ResponseModel response = await _userService.AddShippingAddressToUser(model);

            if (response.State)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest("Adres eklenirken bir hata oluştu.");
            }
        }

        [HttpPost("update-shipping-address-to-user")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Users, ActionType = ActionType.Writing, Definition = "Update Shipping Address To User")]
        public async Task<ActionResult<bool>> UpdateShippingAddressToUser(AddUserShippingAddressCommandModel model)
        {
            bool response = await _userService.UpdateShippingAddressToUser(model);

            if (response)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest("Adres güncellenirken bir hata oluştu.");
            }
        }

        [HttpDelete("delete-shipping-address-to-user/{id}")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Users, ActionType = ActionType.Writing, Definition = "Delete Shipping Address To User")]
        public async Task<ActionResult<bool>> DeleteShippingAddressToUser(int id)
        {
            bool response = await _userService.DeleteUserShippingAddress(id);

            if (response)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest("Adres silinirken bir hata oluştu.");
            }
        }

        [HttpGet("get-shipping-addresses-to-user/{id}")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Users, ActionType = ActionType.Writing, Definition = "Get Shipping Address To User")]
        public async Task<ActionResult<List<UserShippingAddress_VM>>> GetShippingAddressToUser(int id)
        {
            List<UserShippingAddress_VM> response = await _userService.GetUserShippingAddresses(id);

            if (response.Count > 0)
            {
                return Ok(response);
            }
            else
            {
                return Ok(null);
            }
        }

        [HttpGet("get-user-shipping-addres-single/{id}")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Users, ActionType = ActionType.Writing, Definition = "Get User Shipping Address Single")]
        public async Task<ActionResult<List<UserShippingAddress_VM>>> GetUserShippingAddresSingle(int id)
        {
            List<UserShippingAddress_VM> response = await _userService.GetUserShippingAddresSingle(id);

            if (response.Count > 0)
            {
                return Ok(response);
            }
            else
            {
                return Ok(null);
            }
        }

        [HttpGet("send-password-reset-email/{email}")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Users, ActionType = ActionType.Writing, Definition = "Get Password Reset Email")]
        public async Task<ActionResult> SendPasswordResetEmail(string email)
        {
            await _userService.SendPasswordResetEmail(email);
            return Ok(true);
        }

        [HttpGet("confirm-password-token/{token}")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Users, ActionType = ActionType.Writing, Definition = "Confirm Password Token")]
        public async Task<ActionResult> ConfirmPasswordToken(string token)
        {
            var response = await _userService.ConfirmPasswordToken(token);
            return Ok(response);
        }

        [HttpPost("password-reset")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Users, ActionType = ActionType.Writing, Definition = "Password Reset")]
        public async Task<ActionResult> PasswordReset(PasswordRequest_CM model)
        {
            var response = await _userService.PasswordReset(model);
            return Ok(response);
        }
        #endregion
    }
}
