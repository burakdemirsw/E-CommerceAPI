namespace GoogleAPI.Domain.Models.Product.CommandModel
{
    public class GetProductPhotoResponse
    {
        public List<PhotoDetail> Photos { get; set; }
        public string? StockCode { get; set; }
        public int? ColorId { get; set; }
    }


}
