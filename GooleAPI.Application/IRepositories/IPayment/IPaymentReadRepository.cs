using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleAPI.Domain.Entities;
using GoogleAPI.Domain.Entities.PaymentEntities;
namespace GooleAPI.Application.IRepositories
{
    public interface IPaymentReadRepository : IReadRepository<Payment> { }
    public interface IPaymentMethodReadRepository : IReadRepository<PaymentMethod> { }

}
