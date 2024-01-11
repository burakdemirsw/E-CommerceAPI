using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAPI.Domain.Models.Category.ViewModel
{
    public class SubCategory_VM : Base_VM
    {
        public int? TopCategoryCategoryId { get; set; }
        public string? TopCategoryDescription { get; set; }
        public List<SubCategory_VM>? SubCategories { get; set; }

    }
}
