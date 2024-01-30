using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAPI.Domain.Models.Address
{
    public class Province_VM
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public int CountryId { get; set; }

    }
}
