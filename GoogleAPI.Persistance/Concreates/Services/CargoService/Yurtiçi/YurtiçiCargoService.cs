using GooleAPI.Application.Abstractions.IServices.ICargo.IYurtiçi;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace GoogleAPI.Persistance.Concreates.Services.CargoService.Yurtiçi
{
    public class YurtiçiCargoService : IYurtiçiCargoService
    {
        private readonly IConfiguration _congiguration;
        public async Task CreateCargo( )
        {

            //YurticiClient.createNgiShipmentWithAddress data = new YurticiClient.createNgiShipmentWithAddress();

            //data.wsUserName = "1730A1029068699"; //Api kullanıcı adı
            //data.wsPassword = "WDv5M0CNS2mv7n92"; // Api kullanıcı şifresi
            //data.wsUserLanguage = "TR"; // Api dili

            //YurticiClient.XShipmentData shipmentData = new YurticiClient.XShipmentData();
            //shipmentData.ngiDocumentKey = "GG111222333"; // İrsaliye referans kodu
            //shipmentData.cargoType = "2"; // Kargo tipi 2-> koli
            //shipmentData.totalCargoCount = 1; // İrsaliyeye ait ürün sayısı
            //shipmentData.totalDesi = 16; // İrsaliyeye ait ürün kolilerinin x,y,z çarpımı
            //shipmentData.totalWeight = 50; // İrsaliye ürünlerini toplam ağırlığı
            //shipmentData.personGiver = "Gencer Ger"; // Satıcı ismi
            //shipmentData.description = "Api test gönderisi"; // İrsaliye açıklaması
            //shipmentData.productCode = "STA"; // Ürün kodu max 3karakter

            //YurticiClient.XDocCargoData cargoData = new YurticiClient.XDocCargoData();
            //cargoData.ngiCargoKey = "GG111222333"; // Kargo referans numarası
            //cargoData.cargoType = "2"; //Kargo tipi 2-> koli
            //cargoData.cargoDesi = 16;// İrsaliyeye ait ürün kolilerinin x,y,z çarpımı
            //cargoData.cargoWeight = 50;// İrsaliye ürünlerini toplam ağırlığı
            //cargoData.cargoCount = 1;// İrsaliyeye ait ürün kolilerinin x,y,z çarpımı

            //shipmentData.docCargoDataArray = new YurticiClient.XDocCargoData[] { cargoData };


            //YurticiClient.XSpecialFieldData specialData = new YurticiClient.XSpecialFieldData();
            //specialData.specialFieldName = "54"; // Özel alan kodu 54->irsaliye referans kodu
            //specialData.specialFieldValue = "GG111222333"; // Özel alanın değeri

            //shipmentData.specialFieldDataArray = new YurticiClient.XSpecialFieldData[] { specialData };

            //YurticiClient.XCodData codData = new YurticiClient.XCodData();
            //codData.ttInvoiceAmount = 0; // Kargo ücreti
            //codData.ttDocumentId = "111222333"; // Fatura no
            //codData.ttCollectionType = "0";
            //codData.ttDocumentSaveType = "1";

            //shipmentData.codData = codData;

            //data.shipmentData = shipmentData;


            //YurticiClient.XSenderCustAddress senderData = new YurticiClient.XSenderCustAddress();
            //senderData.senderCustName = "Gencer Ger"; //Gönderici ismi
            //senderData.senderAddress = "Muğla Menteşe ..."; //Gönderici adresi
            //senderData.cityId = "48"; // İl plaka kodu
            //senderData.townName = "Menteşe"; //İlçe ismi
            //senderData.senderMobilePhone = "0541872...."; // gönderici numarası
            //senderData.senderEmailAddress = "gen-cer@hotmail.com"; //Gönderici mail adresi        
            //data.XSenderCustAddress = senderData;


            //YurticiClient.XConsigneeCustAddress consigneeData = new YurticiClient.XConsigneeCustAddress();
            //consigneeData.consigneeCustName = "Gencer Ger"; // Alıcı adı
            //consigneeData.consigneeAddress = "Muğla Menteşe ..."; //Alıcı adresi
            //consigneeData.cityId = "48"; //Alıcının il plaka kodu
            //consigneeData.townName = "Menteşe"; //Alıcının ilçesi
            //consigneeData.consigneeMobilePhone = "0541..."; //Alıcının telefonu
            //consigneeData.consigneeEmailAddress = "gen-cer@hotmail.com"; //Alıcının mail adresi     


            //data.XConsigneeCustAddress = consigneeData;


            //YurticiClient.XPayerCustData payerData = new YurticiClient.XPayerCustData();


            //payerData.invCustId = "1029068699"; //(Aracı firma olduğumuz için ben kendi müşteri kodumu yazdım buraya)

            //data.payerCustData = payerData;

            //YurticiClient.NgiShipmentInterfaceServicesClient client = new YurticiClient.NgiShipmentInterfaceServicesClient();


            //var result = await client.createNgiShipmentWithAddressAsync(data); //Sorguyu gönderir

            //Console.WriteLine(JsonSerializer.Serialize(result.createNgiShipmentWithAddressResponse.XShipmentDataResponse));
           
        }

        public void DeleteCargo( )
        {
            throw new NotImplementedException();
        }

        public void GetCargoById( )
        {
            throw new NotImplementedException();
        }

        public void GetCargoList( )
        {
            throw new NotImplementedException();
        }

        public void UpdateCargo( )
        {
            throw new NotImplementedException();
        }
    }
}
