namespace GoogleAPI.Domain.Models.Order.CommandModel
{
    public class GetBasketProductsFilter_ResponseModel
    {
        public int? Id { get; set; }
        public string? PhotoUrl { get; set; }
        public string? CardId { get; set; }
        public string? StockCode { get; set; }
        public string? Description { get; set; }
        public int? StockAmount { get; set; }
        public string? Barcode { get; set; }

        public string? ColorDescription { get; set; }
        public string? DimensionDescription { get; set; }

        public decimal? NormalPrice { get; set; }
        public decimal? DiscountedPrice { get; set; }
        public decimal? PriceOnSale { get; set; }
        public decimal? DiscountedPriceOnSale { get; set; }
    }
}
