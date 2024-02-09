using GoogleAPI.Domain.Entities.Common;

namespace GoogleAPI.Domain.Entities.PaymentEntities
{
    public class Payment : BaseEntity
    {
        public int? OrderId { get; set; } = 0;
        public Order Order { get; set; }
        public Boolean Status { get; set; }
        public int PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string? PaymentToken { get; set; }
        public decimal PaymentValue { get; set; }
        public string? ExceptionCode { get; set; }
        public string? ExceptionDescription { get; set; }
        public string? ConversationId { get; set; }


    }
}