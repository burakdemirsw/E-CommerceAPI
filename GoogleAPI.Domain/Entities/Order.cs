using GoogleAPI.Domain.Entities.Common;
using GoogleAPI.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAPI.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Guid OrderNo { get; set; }    
        public BillingAddress BillingAddress { get; set; }   // order (1) -> billingAddress (*)
        public int? BillingAddressId { get; set; } 
        public int? ShippingAddressId { get; set; }
        public ShippingAddress ShippingAddress { get; set; } // order (1) -> shippingAddress (*)
        public int BasketId { get; set; }
        public Basket Basket { get; set; }// order (1) ->  (1) basket

        public bool  IsCompleted { get; set; }
    }
}
