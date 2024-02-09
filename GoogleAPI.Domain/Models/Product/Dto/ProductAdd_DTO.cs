namespace GoogleAPI.Domain.Models.Product.Dto
{
    public class ProductAdd_DTO
    {
        public int? Id { get; set; }
        public string StockCode { get; set; }

        public string Description { get; set; }

        public List<int> CategoryIdList { get; set; }

        public List<int> ColorIdList { get; set; }

        public List<int> ItemDimList { get; set; }

        public int BrandId { get; set; }

        public int SupplierId { get; set; }

        public string? Explanation { get; set; }

        public string? CoverLetter { get; set; }

        public int? StockAmount { get; set; }

        public decimal NormalPrice { get; set; }

        public decimal? PurchasePrice { get; set; }

        public decimal? DiscountedPrice { get; set; }

        public int? VatRate { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsNew { get; set; }

        public bool? IsFreeCargo { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? Ticket_1 { get; set; }
        public bool? Ticket_2 { get; set; }
        public bool? Ticket_3 { get; set; }
    }
}
