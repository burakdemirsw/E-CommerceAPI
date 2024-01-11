using GoogleAPI.Domain.Entities.User;
using GoogleAPI.Persistance.Contexts;
using GoogleAPI.Persistance.Repositories;

namespace GooleAPI.Application.IRepositories
{
    public class RoleReadRepository : ReadRepository<Role>, IRoleReadRepository
    {
        public RoleReadRepository(GooleAPIDbContext context) : base(context) { }
    }
}
