using GoogleAPI.Domain.Entities.Common;

namespace GoogleAPI.Domain.Entities
{
    public class Supplier : BaseEntity
    {
        public string? Description { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
