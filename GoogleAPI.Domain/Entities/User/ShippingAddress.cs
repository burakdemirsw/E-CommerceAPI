using GoogleAPI.Domain.Entities.Common;
using NHibernate.UserTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAPI.Domain.Entities.User
{
    public class ShippingAddress : BaseEntity
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
 
        public int? UserId { get; set; }
        public User User { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
}
