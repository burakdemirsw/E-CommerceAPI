using GoogleAPI.Domain.Entities.Common;
using GoogleAPI.Domain.Entities.User;

namespace GoogleAPI.Domain.Entities
{
    public class Endpoint : BaseEntity
    {
        public Endpoint( )
        {
            Roles = new HashSet<Role>();
        }
        public string ActionType { get; set; }
        public string HttpType { get; set; }
        public string Definition { get; set; }
        public string Code { get; set; }

        public Menu Menu { get; set; }
        public ICollection<Role> Roles { get; set; }
    }
}
