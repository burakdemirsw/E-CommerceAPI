using GoogleAPI.Domain.Entities.Common;

namespace GoogleAPI.Domain.Entities
{
    public class BasketItem : BaseEntity
    {
        public int? BasketId { get; set; }
        public Basket Basket { get; set; }

        public int Quantity { get; set; }

        public int? ProductId { get; set; }
        public Product Product { get; set; }

        public decimal PriceOnSale { get; set; }
        public decimal DiscountedPriceOnSale { get; set; }


    }
}
