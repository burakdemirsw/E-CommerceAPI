using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAPI.Domain.Models.User.CommandModel
{
    public class AddUserAddressCommandModel
    {
        public int UserId { get; set; }
        public string? AddressTitle { get; set; }
        public string? AddressName { get; set; }
        public string? AddressDescription { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? District { get; set; }
        public string? PostalCode { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}
