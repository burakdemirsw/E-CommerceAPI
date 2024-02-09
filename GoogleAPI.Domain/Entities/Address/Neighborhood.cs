using GoogleAPI.Domain.Entities.Common;
using GoogleAPI.Domain.Entities.User;

namespace GoogleAPI.Domain.Entities.Address
{
    public class Neighborhood : BaseEntity //mahalle
    {
        public string? Description { get; set; }

        public District District { get; set; }
        //[ForeignKey(nameof(District))]
        public int DistrictId { get; set; }

        //public ICollection<BillingAddress> BillingAddresses { get; set; }
        public ICollection<ShippingAddress> ShippingAddresses { get; set; }

    }

}
