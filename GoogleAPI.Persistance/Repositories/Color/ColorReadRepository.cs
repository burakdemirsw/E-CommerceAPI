using GoogleAPI.Domain.Entities;
using GoogleAPI.Persistance.Contexts;
using GoogleAPI.Persistance.Repositories;
namespace GooleAPI.Application.IRepositories
{
    public class ColorReadRepository : ReadRepository<Color>, IColorReadRepository
    {
        public ColorReadRepository(GooleAPIDbContext context) : base(context) { }
    }
}
