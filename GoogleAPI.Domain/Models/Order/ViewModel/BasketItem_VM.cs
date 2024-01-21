using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAPI.Domain.Models.Order.ViewModel
{
    public class BasketItem_VM
    {
        public int? BasketId { get; set; }

        public int Quantity { get; set; }

        public int? ProductId { get; set; }

    }
    public class AddBasketItem_VM
    {
        public int? BasketId { get; set; }

        public int Quantity { get; set; }

        public string StockCode { get; set; }
        public int ColorId { get; set; }
        public int DimentionId { get; set; }
        public int UserId { get; set; }
    }
}
