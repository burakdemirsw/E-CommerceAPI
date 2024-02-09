namespace GoogleAPI.Domain.Models.Product.Filters
{
    public class GetProductCardsFilter
    {
        public Pagination Pagination { get; set; }
        public string? StockCode { get; set; }
        public string? Description { get; set; }
        public Decimal? NormalPrice { get; set; }
        public Decimal? DiscountedPrice { get; set; }

    }
}
