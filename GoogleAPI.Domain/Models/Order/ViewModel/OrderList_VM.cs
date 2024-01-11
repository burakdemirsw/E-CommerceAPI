using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAPI.Domain.Models.Order.ViewModel
{
    public class OrderList_VM
    {
        public int Id { get; set; }
        public Guid OrderNo { get; set; }
        public string? UserNameSurname { get; set; }
        public decimal TotalValue { get; set; }
        public string? Provider { get; set; }
        public DateTime? CreatedDate { get; set; }

        public List<BasketItemList_VM> Items { get; set; }
    }
}
