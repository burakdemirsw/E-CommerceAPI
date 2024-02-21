using Google.Apis.Auth.OAuth2.Responses;
using GoogleAPI.Domain.Entities.Cargo;
using GoogleAPI.Domain.Models.Cargo.Mng.Order;
using GoogleAPI.Domain.Models.Cargo.Mng.Request;
using GoogleAPI.Domain.Models.Cargo.Mng.Response;
using GoogleAPI.Domain.Models.Order.ResponseModel;
using GoogleAPI.Persistance.Contexts;
using GooleAPI.Application.Abstractions.IServices.ICargo;
using GooleAPI.Application.Abstractions.IServices.ICargo.IMng;
using Iyzipay.Model.V2.Subscription;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAPI.Persistance.Concreates.Services.CargoService.Mng
{
    public class MngCargoService : IMNGCargoService
    {
        ICargoService _cargoService;
        GooleAPIDbContext _context;
        public MngCargoService(ICargoService cargoService , GooleAPIDbContext context)
        {
            _cargoService = cargoService;
            _context = context;
        }

        public async Task<CreatePackage_MNG_Response> CreateCargo(GetOrderDetail_ResponseModel Order)
        {
            CargoFirm cargo = await _cargoService.GetCargoFirmById(3);

            string url = "https://testapi.mngkargo.com.tr/mngapi/api/standardcmdapi/createOrder";
            string clientId = cargo.ApiKey;
            string clientSecret = cargo.ApiSecretKey;


            CreateTokenResponse_MNG token = await CreateToken();
            CreatePackage_MNG_Request request = new CreatePackage_MNG_Request();
            request.Order = new Order_MNG()
            {
                ReferenceId = Order.OrderDetail.Id.ToString(),
                Barcode = Order.OrderDetail.OrderNo.ToString(),
                BillOfLandingId= Order.OrderDetail.OrderNo.ToString(),
                IsCOD = 1, // Kapıda Ödeme mi,
                CodAmount =Convert.ToInt32( Order.OrderDetail.TotalValue),// Kapıda Ödeme Miktarı
                ShipmentServiceType =1,//1:STANDART_TESLİMAT, 7:GUNİCİ_TESLİMAT, 8:AKŞAM_TESLİMAT Gönderi Tipi
                PackagingType =3,// 1:DOSYA, 2:Mİ, 3:PAKET, 4:KOLİ Kargo Cinsi
                Content =Order.OrderDetail.Items.Count>0  ? Order.OrderDetail.Items.Count+" Adet Ürün Paketlenmiştir" : "Ürün İçeriği Yoktur" ,//  Genel İçerik Bilgisi
                SmsPreference1 =1,// Kargo varış şubesine ulaştığında alıcıya SMS gitsin mi
                SmsPreference2 =1,// Kargo ilk hazırlandığında alıcıya SMS gitsin mi?
                SmsPreference3 =1,// Kargo teslim edildiğinde göndericiye SMS gitsin mi?
                PaymentType =1,//1:GONDERICI_ODER, 2:ALICI_ODER
                DeliveryType =1,//1:ADRESE_TESLIM, 2:ALICISI_HABERLİ Teslim Şekli
                Description ="",// TRND, N11, GG, VIVE Pazaryeri Kodu örneğin: TRND, N11, GG, VIVE
                MarketPlaceShortCode ="",// MarketPlace Pazaryeri Satış Kodu
                MarketPlaceSaleCode ="",//
            };
            request.OrderPieceList = new List<OrderPieceList_MNG>();
            foreach (var item in Order.OrderDetail.Items)
            {
                OrderPieceList_MNG _item = new OrderPieceList_MNG();
                _item.Barcode = item.StockCode == null ? "" : item.StockCode;
                _item.Desi = 1;
                _item.Kg = 1;
                _item.Content = item.Description;
                request.OrderPieceList.Add(_item);
            }
            request.Recipient = new Recipient_MNG
            {
                CustomerId = "",
                RefCustomerId = "",
                CityCode = 0,
                DistrictCode = 0,
                CityName = "İstanbul",
                DistrictName = "Üsküdar",
                Address = "Küçük Çamlıca Mahallesi Müftü Kuyusu Sokak Şekerkaya villaları no: 11 daire 2 ",
                BussinessPhoneNumber ="",
                Email = "demir.burock96@gmail.com",
                TaxOffice = "",
                TaxNumber = "",
                FullName = "Burak Demir",
                HomePhoneNumber = "",
                MobilePhoneNumber = "05393465584"

            };
            string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings
            {
                ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
            });

            using (HttpClient client = new HttpClient())
            {

                client.DefaultRequestHeaders.Add("X-IBM-Client-Id", clientId.Trim());
                client.DefaultRequestHeaders.Add("X-IBM-Client-Secret", clientSecret.ToString());

                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(url, content);


                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    CreatePackage_MNG_Response? tokenResponse = JsonConvert.DeserializeObject<CreatePackage_MNG_Response>(responseContent);
                    return tokenResponse;


                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                    return null;
                }
            }



            throw new NotImplementedException();
        }

        public async Task<CreateTokenResponse_MNG> CreateToken( )
        {
         
            CargoFirm cargo = await _cargoService.GetCargoFirmById(3);

            string url = "https://testapi.mngkargo.com.tr/mngapi/api/token";
            string clientId = cargo.ApiKey;
            string clientSecret = cargo.ApiSecretKey;
         

            var request = new CreateToken_MNG_Request
            {
                CustomerNumber =cargo.UserName,
                Password = cargo.Password,
                IdentityType = 1
            };
            string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings
            {
                ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
            });


            using (HttpClient client = new HttpClient())
            {

                client.DefaultRequestHeaders.Add("X-IBM-Client-Id", clientId.Trim());
                client.DefaultRequestHeaders.Add("X-IBM-Client-Secret", clientSecret.ToString());

                 var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(url, content);
                //Console.WriteLine(clientId);
              
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    CreateTokenResponse_MNG tokenResponse = JsonConvert.DeserializeObject<CreateTokenResponse_MNG>(responseContent);
                    return tokenResponse;

               
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                    return null;
                }
            }


        }

        public Task<bool> DeleteCargo( )
        {
            throw new NotImplementedException();
        }
    }
   

  
}

