using GoogleAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAPI.Domain.Entities
{
    public class Country : BaseEntity //ülke
    {
        public string? Description { get; set; }
    }
    public class Province : BaseEntity //il
    {
        public string? Description { get; set; }

        public Country Country { get; set; }
        [ForeignKey(nameof(Country))]
        public int CountryId { get; set; }

    }
    public class District : BaseEntity //ilçe
    {

        public string? Description { get; set; }

        public Province Province { get; set; }
        [ForeignKey(nameof(Province))]
        public int ProvinceId { get; set; }
    }
    public class Neighborhood : BaseEntity //mahalle
    {
        public string? Description { get; set; }

        public District District { get; set; }
        [ForeignKey(nameof(District))]
        public int DistrictId { get; set; }
    }
}

