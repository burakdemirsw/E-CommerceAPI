using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAPI.Domain.Models.Product.ResponseModel
{
    //varyasyon sayfası ve update sayfasında kullanılmak üzere oluşturuldu .14.12
    public class GetVariationsIdListResponseModel
    {
        public int? Id { get; set; }
        public string? StockCode { get; set; }
        public string?  ColorDescription { get; set; }
        public string?  DimentionDescription { get; set; }
        public decimal? NormalPrice { get; set; }
        public decimal? PurchasePrice { get; set; }
        public string? Barcode { get; set; }
        public bool? IsActive { get; set; }
    }
}
