using GoogleAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAPI.Domain.Entities
{
    public class Basket : BaseEntity
    {
        public Guid BaskedNo { get; set; }
        public int? UserId { get; set; } 
        public GoogleAPI.Domain.Entities.User.User User { get; set; } // Basket (1) -> User (*)

        public Order Order { get; set; }

        public ICollection<BasketItem> BasketItems { get; set; }
    }
}
