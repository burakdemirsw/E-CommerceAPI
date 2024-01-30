using GoogleAPI.Domain.Entities;
using GoogleAPI.Persistance.Contexts;
using GoogleAPI.Persistance.Repositories;
namespace GooleAPI.Application.IRepositories
{
    public class SupplierReadRepository : ReadRepository<Supplier>, ISupplierReadRepository
    {
        public SupplierReadRepository(GooleAPIDbContext context) : base(context) { }
    }
}
