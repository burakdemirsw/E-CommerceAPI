namespace GoogleAPI.Domain.Models.Order.CommandModel
{
    public class CreateBasketCommandModel
    {
        public int UserId { get; set; }
        public string? OrderNo { get; set; }
    }
}
