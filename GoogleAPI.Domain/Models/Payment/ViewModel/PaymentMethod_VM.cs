namespace GoogleAPI.Domain.Models.Payment.ViewModel
{
    public class PaymentMethod_VM : Base_VM
    {
        public bool? IsActive { get; set; }
        public string? MerchantId { get; set; }
        public string? ApiKey { get; set; }
        public string? ApiSecretKey { get; set; }
        public string? OkUrl { get; set; }
        public string? FailUrl { get; set; }
        public string? SpecialField { get; set; }
        public string? SpecialField_2 { get; set; }
        public string? SpecialField_3 { get; set; }

    }
}
