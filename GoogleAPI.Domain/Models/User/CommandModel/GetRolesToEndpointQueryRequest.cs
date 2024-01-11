using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAPI.Domain.Models.User.CommandModel
{
    public class GetRolesToEndpointQueryRequest
    {
        public string Code { get; set; }
        public string Menu { get; set; }
    }
}
