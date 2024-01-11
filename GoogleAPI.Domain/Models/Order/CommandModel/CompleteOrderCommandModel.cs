using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAPI.Domain.Models.Order.CommandModel
{

    public class CompleteOrderCommandModel
    {
        public Guid OrderNo { get; set; }
        public bool IsCompleted { get; set; }
    }
}
