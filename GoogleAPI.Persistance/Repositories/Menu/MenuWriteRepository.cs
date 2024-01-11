using GoogleAPI.Domain.Entities;
using GoogleAPI.Persistance.Contexts;
using GoogleAPI.Persistance.Repositories;
namespace GooleAPI.Application.IRepositories
{
    public class MenuWriteRepository : WriteRepository<Menu>, IMenuWriteRepository
    {
        public MenuWriteRepository(GooleAPIDbContext context) : base(context) { }
    }
}
