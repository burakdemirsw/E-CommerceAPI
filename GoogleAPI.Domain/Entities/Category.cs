using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleAPI.Domain.Entities.Common;

namespace GoogleAPI.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string? Description { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
        public string? PhotoUrl { get; set; }
        public bool  IsActive{ get; set; }  
        public int? TopCategoryId { get; set; }  
    }
}
