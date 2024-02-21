using GoogleAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAPI.Domain.Entities.All_Settings
{
    public class CompanyInfo : BaseEntity
    {
        public string? CompanyName { get; set; }
        public string? LogoUrl { get; set; }
        public string? ServiceSector { get; set; }
        public string? AuthorizedPerson { get; set; }
        public string? Phone { get; set; }
        public string? Fax { get; set; }
        public string? TaxOffice { get; set; }
        public string? TaxNumber { get; set; }
        public string? TradeRegistryNo { get; set; }
        public string? MersisNo { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? PostalCode { get; set; }
        public string? CompanyCountry { get; set; }
        public string? CompanyCity { get; set; }
        public string? CompanyDistrict { get; set; }
        public string? PasswordResetUrl { get; set; }
        public string? WebSiteUrl { get; set; }

    }
}
