using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAPI.Domain.Models.User.CommandModel
{
    public class UserLoginCommandModel
    {

        public string PhoneNumberOrEmail { get; set; }
        public string Password { get; set; }
    }
}
