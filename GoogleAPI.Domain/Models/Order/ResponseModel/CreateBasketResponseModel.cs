using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAPI.Domain.Models.Order.ResponseModel
{
    public class CreateBasketResponseModel
    {
        public int BasketId { get; set; }
        public bool State { get; set; }
    }
}
