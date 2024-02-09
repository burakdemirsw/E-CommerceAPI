namespace GoogleAPI.Domain.Models.Payment.ViewModel
{
    public class PaymentList_VM
    {
        public int Id { get; set; }
        public Guid OrderNo { get; set; }
        public DateTime? OrderCreatedDate { get; set; }
        public int BasketId { get; set; }
        public DateTime? BasketCreatedDate { get; set; }
        public string? PaymentToken { get; set; }
        public string? PaymentMethodDescription { get; set; }

        public bool Status { get; set; }
        public string? ExceptionCode { get; set; }
        public string? ExceptionDescription { get; set; }
    }
}
