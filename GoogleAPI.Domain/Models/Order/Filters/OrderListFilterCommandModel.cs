using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAPI.Domain.Models.Order.Filters
{
    public class OrderListFilterCommandModel
    {
        public Guid OrderNo { get; set; }
        public int Id { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
