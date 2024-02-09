using GoogleAPI.Domain.Entities.PaymentEntities;
using GoogleAPI.Persistance.Contexts;
using GoogleAPI.Persistance.Repositories;
namespace GooleAPI.Application.IRepositories
{
    public class PaymentWriteRepository : WriteRepository<Payment>, IPaymentWriteRepository
    {
        public PaymentWriteRepository(GooleAPIDbContext context) : base(context) { }
    }
}
