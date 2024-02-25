using GoogleAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAPI.Domain.Entities.Cargo
{
    public class CargoFirm : BaseEntity
    {

        public string? Description { get; set; }
        public string? CargoPaymentDescription { get; set; }

        public string? PhotoUrl { get; set; }

        public bool IsActive { get; set; } = false;

        public bool IsCPCActive { get; set; } = false; //kapıda nakit  
        public decimal CPC_Price { get; set; }
        public decimal CPC_LowerPriceLimit { get; set; }
        public decimal CPC_UpperPriceLimit { get; set; }

        public bool IsCCPCActive { get; set; } = false; //kapıda kredi kartı
        public decimal CCPC_Price { get; set; }
        public decimal CCPC_LowerPriceLimit { get; set; }
        public decimal CCPC_UpperPriceLimit { get; set; }

        public bool IsBPCActive { get; set; } = true; //Buyer Payment
        public decimal BPC_Price { get; set; }
        public decimal BPC_LowerPriceLimit { get; set; }
        public decimal BPC_UpperPriceLimit { get; set; }

        public bool IsSPCActive { get; set; } = true; //Shipper Payment
        public decimal SPC_Price { get; set; }
        public decimal SPC_LowerPriceLimit { get; set; }
        public decimal SPC_UpperPriceLimit { get; set; }


        public string? UserName { get; set; }
        public string? CustomerCode { get; set; }
        public string? Password { get; set; }
        public string? Currency { get; set; }

        public bool isZPLBarcode { get; set; } = true;
        public bool isDifferentBarcode { get; set; } = false;
        public string? ApiKey { get; set; }
        public string? ApiSecretKey { get; set; }

        public string? StockCode { get; set; }


    }





    //public class CargoType : BaseEntity //KNO,KKO,ALICI ÖDEMELİ,GÖNDERİCİ ÖDEMELİ
    //{
    //    public string Description { get; set; }
    //    public decimal  Price { get; set; }
    //    public ICollection<Cargo> Cargos { get; set; }
    //}
}
