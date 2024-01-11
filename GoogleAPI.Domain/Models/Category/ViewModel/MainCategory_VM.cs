using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAPI.Domain.Models.Category.ViewModel
{
    public class MainCategory_VM : Base_VM
    {

        public List<SubCategory_VM>? SubCategories { get; set; }
    }
}
