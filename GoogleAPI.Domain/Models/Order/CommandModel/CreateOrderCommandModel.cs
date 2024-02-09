namespace GoogleAPI.Domain.Models.Order.CommandModel
{
    public class CreateOrderCommandModel
    {
        public int? Id { get; set; }
        // public int? BillingAddressId { get; set; }
        public int? ShippingAddressId { get; set; }
        public int BasketId { get; set; }
        public bool IsCompleted { get; set; }
    }
}
