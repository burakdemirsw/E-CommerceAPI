using GoogleAPI.Domain.Entities.PaymentEntities;
using GoogleAPI.Persistance.Contexts;
using GoogleAPI.Persistance.Repositories;
namespace GooleAPI.Application.IRepositories
{
    public class PaymentReadRepository : ReadRepository<Payment>, IPaymentReadRepository
    {
        public PaymentReadRepository(GooleAPIDbContext context) : base(context) { }
    }

}
