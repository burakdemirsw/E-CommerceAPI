using GoogleAPI.Domain.Entities.Common;

namespace GoogleAPI.Domain.Entities.PaymentEntities
{
    public class PaymentMethod : BaseEntity
    {
        public ICollection<Payment> Payments { get; set; }
        public string Description { get; set; }

    }
}
