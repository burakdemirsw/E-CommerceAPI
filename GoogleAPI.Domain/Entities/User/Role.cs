using GoogleAPI.Domain.Entities.Common;

namespace GoogleAPI.Domain.Entities.User
{
    public class Role : BaseEntity
    {
        public string? RoleName { get; set; }
        public ICollection<RoleUser> RoleUsers { get; set; }
        public ICollection<Endpoint> Endpoints { get; set; }
    }
}
