namespace GoogleAPI.Domain.Models.User.ViewModel
{
    public class UserShippingAddress_VM
    {

        public int Id { get; set; }
        public int? UserId { get; set; }
        public string? AddressTitle { get; set; }
        public string? AddressName { get; set; }
        public string? AddressDescription { get; set; }
        public string? CountryDescripton { get; set; }
        public string? ProvinceDescripton { get; set; }
        public string? DistrictDescripton { get; set; }
        public string? NeighborhoodDescripton { get; set; }
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
