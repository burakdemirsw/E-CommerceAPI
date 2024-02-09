namespace GoogleAPI.Domain.Models.Payment.Filter
{
    public class PaymentFilter
    {
        public int BasketId { get; set; }
        public int? OrderId { get; set; }
        public int PaymentId { get; set; }
        public int PaymentMethodId { get; set; }
        public bool Status { get; set; }
    }

}
