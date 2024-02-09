using GoogleAPI.Domain.Entities.Common;

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
