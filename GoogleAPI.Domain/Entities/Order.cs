using GoogleAPI.Domain.Entities.Common;

using GoogleAPI.Domain.Entities.PaymentEntities;
using GoogleAPI.Domain.Entities.User;

namespace GoogleAPI.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Guid OrderNo { get; set; }
        //public BillingAddress BillingAddress { get; set; }   // order (1) -> billingAddress (*)
        //public int? BillingAddressId { get; set; } 
        public int? ShippingAddressId { get; set; }
        public ShippingAddress ShippingAddress { get; set; } // order (1) -> shippingAddress (*)
        public int BasketId { get; set; }
        public Basket Basket { get; set; }// order (1) ->  (1) basket

        public bool IsCompleted { get; set; }

        public string? IpAddress { get; set; }



        public int? MarketPlaceId { get; set; }
        public MarketPlace MarketPlace { get; set; }


        public ICollection<Payment> Payments { get; set; }
        //public int? PaymentId { get; set; } = 0;
        //public Payment Payment { get; set; }
    }
}
