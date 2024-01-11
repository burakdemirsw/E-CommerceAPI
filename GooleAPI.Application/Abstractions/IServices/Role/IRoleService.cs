using GoogleAPI.Domain.Models.User.CommandModel;
using GoogleAPI.Domain.Models.User.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooleAPI.Application.Abstractions.IServices.Role
{
    public interface IRoleService
    {
        Task<bool> CreateRole(Role_VM model );
        Task<bool> DeleteRole(int Id);
        Task<bool> UpdateRole(Role_VM model);
        Task<List<Role_VM>> GetRoles(int Id);

    }
}
