using GoogleAPI.Domain.Entities;
using GoogleAPI.Persistance.Contexts;
using GooleAPI.Application.IRepositories;

namespace GoogleAPI.Persistance.Repositories
{
    public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
    {
        public ProductWriteRepository(GooleAPIDbContext context) : base(context) { }
    }
}
