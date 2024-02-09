using GoogleAPI.Domain.Entities.Common;

namespace GoogleAPI.Domain.Entities
{
    public class Brand : BaseEntity
    {
        public string Description { get; set; }
        public string? PhotoUrl { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
