using GoogleAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAPI.Domain.Entities.User
{
    public class Role:  BaseEntity
    {
        public string? RoleName { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Endpoint> Endpoints { get; set; }
    }
}
