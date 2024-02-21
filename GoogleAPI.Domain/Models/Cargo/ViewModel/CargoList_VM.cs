using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAPI.Domain.Models.Cargo.ViewModel
{
    public class CargoFirmList_VM
    {

        public int Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? Description { get; set; }
        public string? PhotoUrl { get; set; }
        public bool IsActive { get; set; } = false;
        public bool IsCPCActive { get; set; } = false; //cash payment cargo
        public bool IsCCPCActive { get; set; } = false;
        public bool IsBPCActive { get; set; } = true;
        public bool IsSPCActive { get; set; } = true;
  

    }
}
