using GoogleAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAPI.Domain.Models.User.CommandModel
{
    public class AddUserShippingAddressCommandModel
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string? AddressTitle { get; set; }
        public string? AddressPhoneNumber { get; set; }
        public string? AddressDescription { get; set; }
        public int? CountryId { get; set; }
        public int? ProvinceId { get; set; }
        public int? DistrictId { get; set; }
        public int? NeighborhoodId { get; set; }
        public bool? IsIndividual { get; set; }
        public bool? IsCorporate { get; set; }
        public string? CorparateDescription { get; set; }
        public string? TaxAuthorityDescription { get; set; }
        public string? TaxNo { get; set; }
        public string? NameSurname { get; set; }

        public string? PostalCode { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }

   
}
