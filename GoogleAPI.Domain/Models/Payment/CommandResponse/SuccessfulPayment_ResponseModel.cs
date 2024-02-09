using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAPI.Domain.Models.Payment.CommandResponse
{
    public class SuccessfulPayment_ResponseModel
    {
        public string OrderNo { get; set; }
        public bool PaymentStatus { get; set; }

    }
}
