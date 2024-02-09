namespace GoogleAPI.Domain.Models.Product.CommandModel
{
    public class UpdateProductStockByIdComandModel
    {
        public int ProductId { get; set; }
        public int StockAmount { get; set; }
    }
}
