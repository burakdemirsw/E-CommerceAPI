using GoogleAPI.Domain.Entities;
using GoogleAPI.Domain.Entities.PaymentEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooleAPI.Application.IRepositories
{
    public interface IPaymentWriteRepository : IWriteRepository<Payment> { }
    public interface IPaymentMethodWriteRepository : IWriteRepository<PaymentMethod> { }

}
