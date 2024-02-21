using GoogleAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAPI.Domain.Entities.All_Settings
{
    public class PaymentFirmInfo : BaseEntity
    {
        public string? Description { get; set; }
        public bool? IsActive { get; set; }
        public string? MerchantId { get; set; }
        public string? ApiKey { get; set; }
        public string? ApiSecretKey { get; set; }
        public string? OkUrl { get; set; }
        public string? FailUrl { get; set; }

    }
}
