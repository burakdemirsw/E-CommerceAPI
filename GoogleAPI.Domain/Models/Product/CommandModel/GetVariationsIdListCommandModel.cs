using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAPI.Domain.Models.Product.CommandModel
{
    public class GetVariationsIdListCommandModel
    {
        public string? StockCode { get; set; }
        public int? ColorId { get; set; }
    }
}
