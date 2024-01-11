using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAPI.Domain.Entities
{
    public class ProductPhoto
    {


        public int ProductId { get; set; }
        public Product Product { get; set; }


        public int PhotoId { get; set; }
        public Photo Photo { get; set; }

        public bool IsFirstPhoto { get; set; }


    }
}
