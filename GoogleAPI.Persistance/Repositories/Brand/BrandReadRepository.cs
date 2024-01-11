using GoogleAPI.Domain.Entities;
using GoogleAPI.Persistance.Contexts;
using GoogleAPI.Persistance.Repositories;
namespace GooleAPI.Application.IRepositories
{
    public class BrandReadRepository : ReadRepository<Brand>, IBrandReadRepository
    {
        public BrandReadRepository(GooleAPIDbContext context) : base(context) { }
    }
}
