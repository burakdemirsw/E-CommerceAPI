﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAPI.Domain.Models.Order.ViewModel
{
    public class BasketItem_VM
    {
        public int? BasketId { get; set; }

        public int Quantity { get; set; }

        public int? ProductId { get; set; }

    }
}