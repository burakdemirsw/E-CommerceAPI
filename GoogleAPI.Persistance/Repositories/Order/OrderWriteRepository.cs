using GoogleAPI.Domain.Entities;
using GoogleAPI.Persistance.Contexts;
using GoogleAPI.Persistance.Repositories;
namespace GooleAPI.Application.IRepositories
{
    public class OrderWriteRepository : WriteRepository<Order>, IOrderWriteRepository
    {
        public OrderWriteRepository(GooleAPIDbContext context) : base(context) { }
    }
}
