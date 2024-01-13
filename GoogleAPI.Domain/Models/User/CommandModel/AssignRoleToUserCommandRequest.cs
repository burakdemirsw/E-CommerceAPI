using GoogleAPI.Domain.Models.User.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAPI.Domain.Models.User.CommandModel
{
    public class AssignRoleToUserCommandRequest
    {
        public int UserId { get; set; }
        public List<Role_VM> Roles { get; set; }
    }
}
