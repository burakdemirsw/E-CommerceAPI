namespace GoogleAPI.Domain.Models.Payment.CommandModel
{
    public class CredidCartModel
    {
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public string ExpireMonth { get; set; }
        public string ExpireYear { get; set; }
        public string Cvc { get; set; }

    }
}
