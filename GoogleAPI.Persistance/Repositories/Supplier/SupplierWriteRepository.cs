using GoogleAPI.Domain.Entities;
using GoogleAPI.Persistance.Contexts;
using GoogleAPI.Persistance.Repositories;
namespace GooleAPI.Application.IRepositories
{
    public class SupplierWriteRepository : WriteRepository<Supplier>, ISupplierWriteRepository
    {
        public SupplierWriteRepository(GooleAPIDbContext context) : base(context) { }
    }
}
