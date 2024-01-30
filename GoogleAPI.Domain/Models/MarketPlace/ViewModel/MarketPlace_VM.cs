using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAPI.Domain.Models.MarketPlace.ViewModel
{
    public class MarketPlace_VM  :Base_VM
    {

        public string? ApiKey { get; set; }

        public string? ApiSecretKey { get; set; }

        public string? SupplierId { get; set; }
    }
}
