using GoogleAPI.Domain.Entities.Common;
using GoogleAPI.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAPI.Domain.Entities.Address
{

    public class District : BaseEntity //ilçe
    {

        public string? Description { get; set; }

        public Province Province { get; set; }
        // [ForeignKey(nameof(Province))]
        public int ProvinceId { get; set; }

        public ICollection<Neighborhood> Neighborhoods { get; set; }

        //public ICollection<BillingAddress> BillingAddresses { get; set; }
        public ICollection<ShippingAddress> ShippingAddresses { get; set; }

    }
}
