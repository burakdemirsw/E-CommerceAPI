using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAPI.Domain.Models.Category.CommandModel
{
    public class UpdateBasketItemCommandResponse
    {
        public int? BasketId { get; set; }
        public bool State {  get; set; }
    }
}
