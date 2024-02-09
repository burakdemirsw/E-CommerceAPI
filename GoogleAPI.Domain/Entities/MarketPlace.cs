using GoogleAPI.Domain.Entities.Common;

namespace GoogleAPI.Domain.Entities
{
    public class MarketPlace : BaseEntity
    {
        public string? Description { get; set; }

        public string? ApiKey { get; set; }

        public string? ApiSecretKey { get; set; }

        public string? SupplierId { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
