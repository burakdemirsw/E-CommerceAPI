using GoogleAPI.Domain.Entities;
using GoogleAPI.Persistance.Contexts;
using GoogleAPI.Persistance.Repositories;
namespace GooleAPI.Application.IRepositories
{
    public class DimensionWriteRepository : WriteRepository<Dimension>, IDimensionWriteRepository
    {
        public DimensionWriteRepository(GooleAPIDbContext context) : base(context) { }
    }
}
