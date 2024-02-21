using GoogleAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAPI.Domain.Entities.All_Settings
{
    public class MailInfo : BaseEntity
    {
        public bool IsFirst { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
