using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAPI.Domain.Models.Product.CommandModel
{
    public class UpdateFistPhotoOfCardCommandModel : ProductCard_DTO
    {
        public int PhotoId { get; set; }
    }
}
