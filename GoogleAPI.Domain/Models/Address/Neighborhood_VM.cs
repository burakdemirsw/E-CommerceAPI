using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAPI.Domain.Models.Address
{

    public class Neighborhood_VM
    {
        public int Id { get; set; }

        public string? Description { get; set; }


        public int DistrictId { get; set; }

    }
}
