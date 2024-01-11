﻿using GoogleAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAPI.Domain.Entities
{
    public class BasketItem : BaseEntity
    {
        public int? BasketId { get; set; }
        public Basket Basket { get; set; }

        public int Quantity { get; set; }

        public int? ProductId { get; set; }
        public Product Product { get; set; }
    }
}
