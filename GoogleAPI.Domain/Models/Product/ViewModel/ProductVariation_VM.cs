using GoogleAPI.Domain.Models.Brand.ViewModel;
using GoogleAPI.Domain.Models.Category.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAPI.Domain.Models.Product.ViewModel
{
    public class ProductVariation_VM
    {
        public int? Id { get; set; }
        public string? StockCode { get; set; }
        public string? Description { get; set; }
        public List<Dimention_VM>? Dimentions { get; set; } //list <string olarak ver>
        public List<CategoriesList_VM> Categories { get; set; }
        public int? StockAmount { get; set; }
        //kategorileri de ekle
        public Color_VM? Color { get; set; }
        public Brand_VM? Brand { get; set; }
        public string? Barcode { get; set; }
        public string? CoverLetter { get; set; }
        public decimal? NormalPrice { get; set; }
        public decimal? PurchasePrice { get; set; }
        public decimal? DiscountedPrice { get; set; }
        public int? VATRate { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsNew { get; set; }
        public bool? IsFreeCargo { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
