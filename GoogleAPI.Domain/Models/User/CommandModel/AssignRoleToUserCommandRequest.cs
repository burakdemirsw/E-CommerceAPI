using GoogleAPI.Domain.Models.User.ViewModel;

namespace GoogleAPI.Domain.Models.User.CommandModel
{
    public class AssignRoleToUserCommandRequest
    {
        public int UserId { get; set; }
        public List<Role_VM> Roles { get; set; }
    }
}
