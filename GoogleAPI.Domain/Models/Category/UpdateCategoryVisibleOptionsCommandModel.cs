using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAPI.Domain.Models.Category
{
    public class UpdateCategoryVisibleOptionsCommandModel
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }
}
