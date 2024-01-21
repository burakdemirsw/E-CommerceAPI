using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAPI.Domain.Models.Response
{
    public  class ResponseModel<T>
    {
        public int TotalCount { get; set; } = 0;
        public List<T>? Datas { get; set; }
    }
}
