using GoogleAPI.Domain.Models.User.CommandModel;
using GoogleAPI.Domain.Models.User.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooleAPI.Application.Abstractions.IServices.Authorization
{
    public interface IAuthorizationEndpointService
    
    {
        public Task<bool> AssignRoleEndpointAsync(AssignRoleEndpointCommandRequest model);
        public Task<List<Role_VM>> GetRolesToEndpointAsync(GetRolesToEndpointQueryRequest model);


    }
}
