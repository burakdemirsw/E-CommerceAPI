using GoogleAPI.Domain.Entities.Common;

namespace GoogleAPI.Domain.Entities
{
    public class Photo : BaseEntity
    {
        public string? Url { get; set; }

        public ICollection<ProductPhoto> ProductPhotos { get; set; }
    }
}
