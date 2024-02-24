namespace GoogleAPI.Domain.Models.Order.ViewModel
{
    public class OrderList_VM
    {
        public int Id { get; set; }
        public int BasketId { get; set; }
        public Guid OrderNo { get; set; }
        public string? UserNameSurname { get; set; }
        public decimal TotalValue { get; set; }

        public DateTime? CreatedDate { get; set; }
        public List<BasketItemList_VM> Items { get; set; }

        public string? OrderStatus { get; set; }
        public string? OrderShipmentStatus { get; set; }
        public string? OrderPaymentStatus { get; set; }
        public string? OrderProvider { get; set; }


    }
}
