namespace GoogleAPI.Domain.Models.Order.ViewModel
{
    public class BasketItem_VM
    {
        public int? BasketId { get; set; }

        public int Quantity { get; set; }

        public int? ProductId { get; set; }

    }
    public class AddBasketItem_VM
    {
        public int? BasketId { get; set; }

        public int Quantity { get; set; }
        public int ProductId { get; set; }

        public int ColorId { get; set; }
        public int DimensionId { get; set; }
        public string StockCode { get; set; }
        public int UserId { get; set; }
        public decimal PriceOnSale { get; set; }
        public decimal DiscountedPriceOnSale { get; set; }

    }
}
