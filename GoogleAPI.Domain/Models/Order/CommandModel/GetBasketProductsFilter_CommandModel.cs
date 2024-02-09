namespace GoogleAPI.Domain.Models.Order.CommandModel
{

    public class GetBasketProductsFilter_CommandModel
    {
        public int? Id { get; set; }
        public string? CartId { get; set; }
        public string? Barcode { get; set; }
        public string? StockCode { get; set; }

        public string? Description { get; set; }


    }
}
