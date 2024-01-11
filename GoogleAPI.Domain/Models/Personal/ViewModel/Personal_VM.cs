using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAPI.Domain.Models.Personal.ViewModel
{
    public class Personal_VM : Base_VM
    {

        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? PhotoUrl { get; set; }

    }
}
