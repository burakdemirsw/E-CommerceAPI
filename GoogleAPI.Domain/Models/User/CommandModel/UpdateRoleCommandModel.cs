using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAPI.Domain.Models.User.CommandModel
{
    public class UpdateRoleCommandModel
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
    }
}
