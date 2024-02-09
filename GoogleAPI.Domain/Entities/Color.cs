using GoogleAPI.Domain.Entities.Common;

namespace GoogleAPI.Domain.Entities
{
    public class Color : BaseEntity
    {
        public string Description { get; set; }
        public ICollection<Product> Products { get; set; } // Renk ile ilişkiyi temsil eden navigation property
        //public ICollection<Order> Orders { get; set; }

    }
}
