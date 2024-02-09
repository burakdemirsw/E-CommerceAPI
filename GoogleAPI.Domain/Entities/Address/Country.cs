using GoogleAPI.Domain.Entities.Common;
using GoogleAPI.Domain.Entities.User;

namespace GoogleAPI.Domain.Entities.Address
{
    public class Country : BaseEntity //ülke
    {
        public string? Description { get; set; }
        //public ICollection<BillingAddress> BillingAddresses { get; set; }
        public ICollection<ShippingAddress> ShippingAddresses { get; set; }
        public ICollection<Province> Provinces { get; set; }


    }

}

