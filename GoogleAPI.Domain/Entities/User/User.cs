﻿using GoogleAPI.Domain.Entities.Common;

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
        public ICollection<RoleUser> RoleUsers { get; set; }


        public DateTime? RefreshTokenEndDate { get; set; }


        public ICollection<Basket> Baskets { get; set; }
        public ICollection<ShippingAddress> ShippingAddresses { get; set; }

        //public ICollection<BillingAddress> BillingAddresses { get; set; }
        public string? PhotoUrl { get; set; }

        public string? PasswordToken { get; set; }
        public bool? IsPasswordTokenUsed { get; set; }
        public DateTime? PasswordTokenEndDate { get; set; }

        public DateTime? LastCreateNewPasswordEmailDate { get; set; }

        public bool? IsOrderBanned { get; set; }
        public bool? IsRemitPaymentBanned { get; set; }
        public bool? IsPayAtDoorBanned { get; set; }
        public string? Gender { get; set; }
        // public UserCommunicationInfo? UserCommunucationInfo { get; set; }


    }
}
