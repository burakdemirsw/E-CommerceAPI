using GoogleAPI.Domain.Entities;
using GoogleAPI.Persistance.Contexts;
using GoogleAPI.Persistance.Repositories;
namespace GooleAPI.Application.IRepositories
{
    public class CategoryReadRepository : ReadRepository<Category>, ICategoryReadRepository
    {
        public CategoryReadRepository(GooleAPIDbContext context) : base(context) { }
    }
}
