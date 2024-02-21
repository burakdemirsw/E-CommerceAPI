using GoogleAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAPI.Domain.Entities
{
    public class PopUp : BaseEntity
    {
        public int PopUpTypeId { get; set; }
        public PopUpType PopUpType { get; set; }
        public string? PhotoUrl { get; set; }
        public string? Desription { get; set; }
        public string? RedirectUrl { get; set; }
        public int Time { get; set; } = 1;
        public bool IsActive { get; set; }
    }
    public class PopUpType : BaseEntity
    {
        public ICollection<PopUp> PopUps { get; set; } 
        public string? Type { get; set; } //ana sayfa - ürün listesi
        public string? Desription { get; set; }
        public string? RedirectUrl { get; set; }
    }
}
