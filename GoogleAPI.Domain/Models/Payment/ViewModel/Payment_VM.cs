namespace GoogleAPI.Domain.Models.Payment.ViewModel
{
    public class Payment_VM
    {
        public bool Status { get; set; }
        public int PaymentMethodId { get; set; }
        public int PaymentTypeId { get; set; }
        public string OrderNo { get; set; }
        public string PaymentToken { get; set; }
        public decimal? PaymentValue { get; set; }
        public string? ExceptionCode { get; set; }
        public string? ExceptionDescription { get; set; }

    }
}
