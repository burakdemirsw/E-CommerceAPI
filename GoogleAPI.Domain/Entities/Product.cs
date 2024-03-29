﻿using GoogleAPI.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoogleAPI.Domain.Entities
{
    public class Product : BaseEntity
    {
        public ICollection<ProductPhoto> ProductPhotos { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }

        [ForeignKey(nameof(Dimension))]
        public int? DimensionId { get; set; } // Beden için referans anahtar
        public Dimension Dimension { get; set; } // Beden ile ilişkiyi temsil eden navigation property


        [ForeignKey(nameof(Color))]
        public int? ColorId { get; set; } // Renk için referans anahtar ++
        public Color Color { get; set; } // Renk ile ilişkiyi temsil eden navigation property

        [ForeignKey(nameof(Supplier))]
        public int? SupplierId { get; set; } // Renk için referans anahtar ++
        public Supplier Supplier { get; set; } // Renk ile ilişkiyi temsil eden navigation property


        [ForeignKey(nameof(Brand))]
        public int? BrandId { get; set; } // Ana Kategoriye referans veren anahtar++
        public Brand Brand { get; set; } // Ana Kategori ile ilişkiyi temsil eden navigation property


        public string StockCode { get; set; }

        public string? Barcode { get; set; }
        public string Description { get; set; }
        public string? Explanation { get; set; }
        public string? CoverLetter { get; set; }
        public decimal NormalPrice { get; set; }

        public decimal? PurchasePrice { get; set; }
        public decimal? DiscountedPrice { get; set; }
        public int? StockAmount { get; set; }

        public int? VATRate { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsNew { get; set; }
        public bool? IsFreeCargo { get; set; }

        public bool? Ticket_1 { get; set; }
        public bool? Ticket_2 { get; set; }
        public bool? Ticket_3 { get; set; }
        public ICollection<BasketItem> BasketItems { get; set; }

    }
}
