namespace GoogleAPI.Domain.Models.Order.CommandModel
{

    public class CompleteOrderCommandModel
    {
        public Guid OrderNo { get; set; }
        public bool IsCompleted { get; set; }
    }
}
