using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAPI.Domain.Models.Product.CommandModel
{
    public class UpdateProductStockByIdComandModel
    {
        public int ProductId { get; set; }
        public int  StockAmount { get; set; }
    }
}
