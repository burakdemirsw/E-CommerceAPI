using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAPI.Domain.Models.Order.ResponseModel
{
    public class OrderUser_VM
    {
        public int UserId { get; set; }
        public string NameSurname { get; set; }
        public string PhoneNumber { get; set; }
    }
}
