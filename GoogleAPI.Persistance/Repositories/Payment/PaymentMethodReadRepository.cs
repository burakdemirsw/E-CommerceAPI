using GoogleAPI.Domain.Entities.PaymentEntities;
using GoogleAPI.Persistance.Contexts;
using GoogleAPI.Persistance.Repositories;
namespace GooleAPI.Application.IRepositories
{

    public class PaymentMethodReadRepository : ReadRepository<PaymentMethod>, IPaymentMethodReadRepository
    {
        public PaymentMethodReadRepository(GooleAPIDbContext context) : base(context) { }
    }

}
