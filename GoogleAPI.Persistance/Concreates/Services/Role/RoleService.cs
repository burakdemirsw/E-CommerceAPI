using GoogleAPI.Domain.Models.User.ViewModel;
using GooleAPI.Application.Abstractions.IServices.Role;
using GooleAPI.Application.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace GoogleAPI.Persistance.Concreates.Services.Role
{
    public class RoleService : IRoleService
    {
        internal readonly IRoleReadRepository _rr;
        internal readonly IRoleWriteRepository _rw;

        public RoleService(IRoleWriteRepository rw, IRoleReadRepository rr)
        {
            _rw = rw;
            _rr = rr;
        }

        public async Task<bool> CreateRole(Role_VM model)
        {

            try
            {
                var response = await _rw.AddAsync(new() { RoleName = model.RoleName });
                if (response)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw new Exception($"CreateRole method failed: {ex.Message}", ex);

            }

        }

        public async Task<bool> DeleteRole(int id)
        {
            try
            {
                Domain.Entities.User.Role? role = await _rr.Table.FirstOrDefaultAsync(r => r.Id == id);
                if (role == null)
                {
                    return false;
                }

                bool response = _rw.Remove(role);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception($"DeleteRole method failed: {ex.Message}", ex);
            }
        }

        public async Task<List<Role_VM>> GetRoles(int id)
        {
            try
            {
                List<Domain.Entities.User.Role> roles = new List<Domain.Entities.User.Role>();

                if (id == 0)
                {
                    roles = _rr.GetAll().ToList();
                }
                else
                {
                    Domain.Entities.User.Role role = await _rr.GetByIdAsync(id, true);
                    if (role != null)
                    {
                        roles.Add(role);
                    }
                }

                List<Role_VM> _roles = roles.Select(r => new Role_VM
                {
                    Id = r.Id,
                    RoleName = r.RoleName,

                }).ToList();

                return _roles;
            }
            catch (Exception ex)
            {
                throw new Exception($"GetRoles method failed: {ex.Message}", ex);
            }
        }

        public async Task<bool> UpdateRole(Role_VM model)
        {
            try
            {
                Domain.Entities.User.Role? role = await _rr.Table.FirstOrDefaultAsync(r => r.Id == model.Id);
                if (role == null)
                {
                    return false;
                }
                else
                {
                    role.RoleName = model.RoleName;
                    var response = await _rw.Update(role);
                    if (response)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception($"UpdateRole method failed: {ex.Message}", ex);
            }
        }
    }
}
