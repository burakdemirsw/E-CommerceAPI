using GoogleAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAPI.Domain.Entities.User
{
    public class BillingAddress : BaseEntity
    {
        public string? AddressTitle { get; set; }
        public string? AddressName { get; set; }
        public string? AddressPhone { get; set; }
        public string? AddressDescription { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? District { get; set; }
        public string? PostalCode { get; set; }
        public Guid? RowGuid { get; set; }
        public string? TCKN { get; set; }
        public bool? IsIndividual { get; set; }
        public bool? IsCorporate { get; set; }
        public string? CorparateDescription { get; set; }
        public string? TaxAuthorityDescription { get; set; }
        public string? TaxNo { get; set; }


        public int? UserId { get; set; }
        public User User { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
}
