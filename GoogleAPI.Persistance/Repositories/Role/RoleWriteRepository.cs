using GoogleAPI.Domain.Entities.User;
using GoogleAPI.Persistance.Contexts;
using GoogleAPI.Persistance.Repositories;

namespace GooleAPI.Application.IRepositories
{
    public class RoleWriteRepository : WriteRepository<Role>, IRoleWriteRepository
    {
        public RoleWriteRepository(GooleAPIDbContext context) : base(context) { }
    }
}
