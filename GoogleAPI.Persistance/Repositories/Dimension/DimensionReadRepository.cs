using GoogleAPI.Domain.Entities;
using GoogleAPI.Persistance.Contexts;
using GoogleAPI.Persistance.Repositories;
namespace GooleAPI.Application.IRepositories
{
    public class DimensionReadRepository : ReadRepository<Dimension>, IDimensionReadRepository
    {
        public DimensionReadRepository(GooleAPIDbContext context) : base(context) { }
    }
}
