using GoogleAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAPI.Domain.Entities
{
    public class Personal : BaseEntity
    {
        public string? Description { get; set; }
        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }
        public string? PhotoUrl { get; set; }

    }
}
