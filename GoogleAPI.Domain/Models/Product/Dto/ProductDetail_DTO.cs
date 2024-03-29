﻿namespace GoogleAPI.Domain.Models.Product.Dto
{
    public class ProductDetail_DTO
    {
        public string? StockCode { get; set; }
        public string? Description { get; set; }
        public string? Color { get; set; }
        public string? Variations { get; set; }
        public decimal NormalPrice { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public string? Brand { get; set; }
        public string? PhotoUrl { get; set; }
    }
}
