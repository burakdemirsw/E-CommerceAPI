using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAPI.Domain.Models.Order.ViewModel
{

    public class BasketItemList_VM
    {
        public int Id { get; set; }  
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public string? PhotoUrl { get; set; }
        public string? ColorDescription { get; set; }
        public string? DimentionDescription { get; set; }
        public decimal Price { get; set; }


    }
}
