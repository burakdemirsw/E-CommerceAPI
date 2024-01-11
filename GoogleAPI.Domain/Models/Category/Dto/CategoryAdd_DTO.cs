using GoogleAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAPI.Domain.Models.Category.Dto
{
    public class CategoryAdd_DTO
    {
        public string? Description { get; set; }


        public string? PhotoUrl { get; set; }
        public bool IsActive { get; set; }

        public int? TopCategoryId { get; set; }

    }
}
