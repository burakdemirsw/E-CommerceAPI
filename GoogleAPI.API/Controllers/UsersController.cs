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
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IAuthorizationEndpointService _authorizationEndpointService;

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


        [HttpPost("add-user-address")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Users, ActionType = ActionType.Writing, Definition = "Add Address")]
        public async Task<ActionResult<bool>> AddAddress(AddUserAddressCommandModel model)
        {
            bool response = await _userService.AddUserAddress(model);

            if (response)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest("Adres eklenirken bir hata oluştu.");
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


    }
}
