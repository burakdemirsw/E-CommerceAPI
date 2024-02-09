using GoogleAPI.Domain.Entities.Common;
using GoogleAPI.Domain.Entities.User;

namespace GoogleAPI.Domain.Entities.Address
{
    public class Province : BaseEntity //il
    {
        public string? Description { get; set; }

        public Country Country { get; set; }
        //[ForeignKey(nameof(Country))] 
        public int CountryId { get; set; }

        public ICollection<District> Districts { get; set; }


        //public ICollection<BillingAddress> BillingAddresses { get; set; }
        public ICollection<ShippingAddress> ShippingAddresses { get; set; }


    }
}
