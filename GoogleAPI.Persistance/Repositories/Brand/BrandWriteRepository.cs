using GoogleAPI.Domain.Entities;
using GoogleAPI.Persistance.Contexts;
using GoogleAPI.Persistance.Repositories;
namespace GooleAPI.Application.IRepositories
{
    public class BrandWriteRepository : WriteRepository<Brand>, IBrandWriteRepository
    {
        public BrandWriteRepository(GooleAPIDbContext context) : base(context) { }
    }
}
