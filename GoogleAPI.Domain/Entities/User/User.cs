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
    public class User : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Password { get; set; }
        public Boolean? SubscribeToPromotions { get; set; }

        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? RefreshToken { get; set; }

        [ForeignKey(nameof(Role))]
        public int? RoleId { get; set; }
        public Role Role { get; set; }

        public DateTime? RefreshTokenEndDate { get; set; }


        public ICollection<Basket> Baskets { get; set; }
        public ICollection<ShippingAddress> ShippingAddresses { get; set; }

        public ICollection<BillingAddress> BillingAddresses { get; set; }


        // public UserCommunicationInfo? UserCommunucationInfo { get; set; }


    }
}
