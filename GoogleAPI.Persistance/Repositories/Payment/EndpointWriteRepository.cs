using GoogleAPI.Domain.Entities.PaymentEntities;
using GoogleAPI.Persistance.Contexts;
using GoogleAPI.Persistance.Repositories;
namespace GooleAPI.Application.IRepositories
{
    public class PaymentMethodWriteRepository : WriteRepository<PaymentMethod>, IPaymentMethodWriteRepository
    {
        public PaymentMethodWriteRepository(GooleAPIDbContext context) : base(context) { }
    }
}
