using GoogleAPI.Domain.Models.User.ViewModel;

namespace GoogleAPI.Domain.Models.User.CommandModel
{
    public class AssignRoleEndpointCommandRequest
    {
        public List<Role_VM> Roles { get; set; }
        public string Code { get; set; }
        public string Menu { get; set; }
        public Type? Type { get; set; }
    }
}
