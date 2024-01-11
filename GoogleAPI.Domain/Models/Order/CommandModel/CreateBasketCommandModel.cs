using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAPI.Domain.Models.Order.CommandModel
{
    public class CreateBasketCommandModel
    {
        public int UserId { get; set; }
        public string? OrderNo { get; set; }
    }
}
