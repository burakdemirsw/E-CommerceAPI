using GoogleAPI.Domain.Entities;
using GoogleAPI.Domain.Models.User.CommandModel;
using GoogleAPI.Domain.Models.User.ViewModel;
using GooleAPI.Application.Abstractions.IServices.Authorization;
using GooleAPI.Application.Abstractions.IServices.Configuration;
using GooleAPI.Application.IRepositories;
using Microsoft.EntityFrameworkCore;
using NHibernate.Util;

namespace GoogleAPI.Persistance.Concreates.Services.Authorization
{
    public class AuthorizationEndpointService : IAuthorizationEndpointService
    {
        readonly IApplicationService _applicationService;
        readonly IEndpointReadRepository _endpointReadRepository;
        readonly IEndpointWriteRepository _endpointWriteRepository;
        readonly IMenuReadRepository _menuReadRepository;
        readonly IMenuWriteRepository _menuWriteRepository;
        readonly IRoleReadRepository _roleReadRepository;
        public AuthorizationEndpointService(IApplicationService applicationService,
            IEndpointReadRepository endpointReadRepository,
            IEndpointWriteRepository endpointWriteRepository,
            IMenuReadRepository menuReadRepository,
            IMenuWriteRepository menuWriteRepository,
            IRoleReadRepository roleReadRepository)
        {
            _applicationService = applicationService;
            _endpointReadRepository = endpointReadRepository;
            _endpointWriteRepository = endpointWriteRepository;
            _menuReadRepository = menuReadRepository;
            _menuWriteRepository = menuWriteRepository;

            _roleReadRepository = roleReadRepository;
        }

        public async Task<bool> AssignRoleEndpointAsync(AssignRoleEndpointCommandRequest model)
        {
            try
            {
                Menu? _menu = await _menuReadRepository.Table.FirstOrDefaultAsync(m => m.Name == model.Menu);
                if (_menu == null)
                {
                    _menu = new()
                    {
                        Id = 0,
                        Name = model.Menu
                    };
                    await _menuWriteRepository.AddAsync(_menu);

                    await _menuWriteRepository.SaveAsync(_menu);
                }

                Endpoint? endpoint = await _endpointReadRepository.Table.Include(e => e.Menu).Include(e => e.Roles).FirstOrDefaultAsync(e => e.Code == model.Code && e.Menu.Name == model.Menu);

                if (endpoint == null)
                {
                    List<GooleAPI.Application.Configuration.Menu>? list = await _applicationService.GetAuthorizeDefinitionEndpoints(model.Type);
                    if (list.Count > 0)
                    {
                        Console.WriteLine(list.Count);
                        foreach (var item in list)
                        {
                            Console.WriteLine(item.Name);
                            foreach (var _action in item.Actions)
                            {
                                Console.WriteLine(_action.Code);
                            }
                        }


                    }
                    var action = list.FirstOrDefault(m => m.Name == model.Menu)
                           ?.Actions.FirstOrDefault(e => e.Code == model.Code);

                    endpoint = new()
                    {
                        Code = action.Code,
                        ActionType = action.ActionType,
                        HttpType = action.HttpType,
                        Definition = action.Definition,
                        Id = 0,
                        Menu = _menu,

                    };

                    await _endpointWriteRepository.AddAsync(endpoint);
                    await _endpointWriteRepository.SaveAsync(endpoint);
                }

                foreach (var role in endpoint.Roles)
                    endpoint.Roles.Remove(role);

                var appRoles = _roleReadRepository.Table
                    .AsEnumerable()
                    .Where(r => model.Roles.Any(role => role.RoleName == r.RoleName))
                    .ToList
                    ();
                foreach (var role in appRoles)
                    endpoint.Roles.Add(role);

                await _endpointWriteRepository.SaveAsync(endpoint);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }

        public async Task<List<Role_VM>> GetRolesToEndpointAsync(GetRolesToEndpointQueryRequest model)
        {
            Endpoint? endpoint = await _endpointReadRepository.Table
                .Include(e => e.Roles)
                .Include(e => e.Menu)
                .FirstOrDefaultAsync(e => e.Code == model.Code && e.Menu.Name == model.Menu);

            if (endpoint != null)
            {
                return endpoint.Roles.Select(r => new Role_VM
                {
                    Id = r.Id,
                    RoleName = r.RoleName
                }).ToList();
            }
            else
            {
                return new List<Role_VM>(); // Return an empty list if endpoint is null
            }
        }
    }
}
