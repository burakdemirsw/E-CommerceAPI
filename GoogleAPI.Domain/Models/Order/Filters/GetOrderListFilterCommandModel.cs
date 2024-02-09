namespace GoogleAPI.Domain.Models.Order.Filters
{
    public class GetOrderListFilterCommandModel
    {
        public Pagination Pagination { get; set; }
        public Guid OrderNo { get; set; }
        public int Id { get; set; }
        public int BasketId { get; set; }
        //public int UserId { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
