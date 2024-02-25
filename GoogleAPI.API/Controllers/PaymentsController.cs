using GoogleAPI.Domain.Models.Payment;
using GoogleAPI.Domain.Models.Payment.CommandResponse;
using GoogleAPI.Domain.Models.Payment.Filter;
using GoogleAPI.Domain.Models.Payment.ViewModel;
using GoogleAPI.Domain.Models.User;
using GoogleAPI.Persistance.Contexts;
using GooleAPI.Application.Abstractions.IServices.IyzcoPayment;
using Iyzipay.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Security.Cryptography;

namespace GoogleAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly GooleAPIDbContext _context;
        private readonly IIyzcoPayment _iyzcoPaymentService;
        private readonly IConfiguration _configuration;

        public PaymentsController(
            GooleAPIDbContext context,
            IIyzcoPayment iyzcoPaymentService,
            IConfiguration configuration
        )
        {
            _context = context;
            _iyzcoPaymentService = iyzcoPaymentService;
            _configuration = configuration;
        }

        //[HttpGet("get-payment")]
        //public ActionResult PayWithIyzco( )
        //{
        //    _iyzcoPaymentService.PayWithIyzco();
        //    return Ok();
        //}

        //[HttpPost("test-payment-2")] //direct
        //public ActionResult PayWithIyzco2(Payment_CommandModel model )
        //{
        //    CreatePaymentRequest request = new CreatePaymentRequest
        //    {
        //        Locale = "tr", // API isteğinde kullanılacak olan dil
        //        ConversationId = Guid.NewGuid().ToString(), // Benzersiz bir konuşma kimliği
        //        Price = model.BasketPrice, // Ödeme miktarı
        //        PaidPrice = model.BasketPrice, // Ödenen miktar
        //        Currency = "TRY", // Ödeme yapılacak para birimi
        //        Installment = 1, // Taksit sayısı
        //        BasketId = model.BasketId, // Sepet kimliği
        //        PaymentChannel = "WEB", // Ödeme kanalı (WEB, MOBILE, vb.)
        //        PaymentGroup = "PRODUCT", // Ödeme grubu (PRODUCT, LISTING, vb.)
        //        PaymentCard = new PaymentCard
        //        {
        //            CardHolderName = model.CredidCard.CardName,
        //            CardNumber = model.CredidCard.CardNumber, // Kredi kartı numarası
        //            ExpireMonth = model.CredidCard.ExpireMonth, // Son kullanma ayı
        //            ExpireYear = model.CredidCard.ExpireYear, // Son kullanma yılı
        //            Cvc = model.CredidCard.Cvc, // CVC kodu
        //            RegisterCard = 0
        //        },
        //        Buyer = new Buyer
        //        {
        //            Id = model.User.Id.ToString(), // Alıcı kimliği
        //            Name = model.User.FirstName,
        //            Surname = model.User.LastName,
        //            GsmNumber = model.User.PhoneNumber, // Alıcı telefon numarası
        //            Email = model.User.Email,
        //            IdentityNumber = "11111111111", // Alıcı kimlik numarası
        //            RegistrationDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), // Kayıt tarihi
        //            LastLoginDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), // Son giriş tarihi
        //            RegistrationAddress = model.Address.AddressDescription, // Kayıt adresi
        //            City = model.Address.ProvinceDescripton,
        //            Country = model.Address.CountryDescripton,
        //            ZipCode = model.Address.PostalCode // Posta kodu
        //        },
        //        ShippingAddress = new Address
        //        {
        //            ContactName = model.User.FirstName + " " + model.User.LastName,
        //            City = model.Address.ProvinceDescripton,
        //            Country = model.Address.CountryDescripton,
        //            Description = model.Address.AddressDescription,
        //            ZipCode = model.Address.PostalCode
        //        },
        //        BillingAddress = new Address
        //        {
        //            ContactName = model.User.FirstName + " " + model.User.LastName,
        //            City = model.Address.ProvinceDescripton,
        //            Country = model.Address.CountryDescripton,
        //            Description = model.Address.AddressDescription,
        //            ZipCode = model.Address.PostalCode
        //        },
        //        BasketItems = new List<BasketItem>()
        //    };


        //    foreach (var item in model.BasketItems)
        //    {
        //        BasketItem basketItem = new BasketItem
        //        {
        //            Id = item.Id.ToString(),
        //            Name = item.Description,
        //            Category1 = "Giyim",
        //            ItemType = BasketItemType.PHYSICAL.ToString(),
        //            Price = item.NormalPrice.ToString()
        //        };
        //        request.BasketItems.Add(basketItem);
        //    }

        //   Payment payment = _iyzcoPaymentService.PayWithIyzco2(request);


        //    return Ok();
        //}



        //[HttpPost("test-payment-3")] //pwi
        //public ActionResult PayWithIyzco3(Payment_CommandModel model)
        //{


        //    try
        //    {

        //        List<int> enabledInstallments = new List<int>();
        //        enabledInstallments.Add(2);
        //        enabledInstallments.Add(3);
        //        enabledInstallments.Add(6);
        //        enabledInstallments.Add(9);

        //        CreatePayWithIyzicoInitializeRequest request = new CreatePayWithIyzicoInitializeRequest
        //        {

        //            Locale = Locale.TR.ToString(),
        //            ConversationId = Guid.NewGuid().ToString(),
        //            Price = model.BasketPrice,
        //            PaidPrice = model.BasketPrice,
        //            Currency = Currency.TRY.ToString(),
        //            BasketId = model.BasketId,
        //            PaymentGroup = "PRODUCT",
        //            CallbackUrl = "https://www.merchant.com/callback",


        //            Buyer = new Buyer
        //            {
        //                Id = model.User.Id.ToString(), // Alıcı kimliği
        //                Name = model.User.FirstName,
        //                Surname = model.User.LastName,
        //                GsmNumber = model.User.PhoneNumber, // Alıcı telefon numarası
        //                Email = model.User.Email,
        //                IdentityNumber = "11111111111", // Alıcı kimlik numarası
        //                LastLoginDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), // Son giriş tarihi
        //                RegistrationDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), // Kayıt tarihi
        //                RegistrationAddress = model.Address.AddressDescription, // Kayıt adresi
        //                Ip = "178.247.147.221",
        //                City = model.Address.ProvinceDescripton,
        //                Country = model.Address.CountryDescripton,
        //                ZipCode = model.Address.PostalCode // Posta kodu
        //            },
        //            ShippingAddress = new Address
        //            {
        //                ContactName = model.User.FirstName + " " + model.User.LastName,
        //                City = model.Address.ProvinceDescripton,
        //                Country = model.Address.CountryDescripton,
        //                Description = model.Address.AddressDescription,
        //                ZipCode = model.Address.PostalCode
        //            },
        //            BillingAddress = new Address
        //            {
        //                ContactName = model.User.FirstName + " " + model.User.LastName,
        //                City = model.Address.ProvinceDescripton,
        //                Country = model.Address.CountryDescripton,
        //                Description = model.Address.AddressDescription,
        //                ZipCode = model.Address.PostalCode
        //            },
        //            BasketItems = new List<BasketItem>()
        //        };


        //        foreach (var item in model.BasketItems)
        //        {
        //            BasketItem basketItem = new BasketItem
        //            {
        //                Id = item.Id.ToString(),
        //                Name = item.Description,
        //                Category1 = "Giyim",
        //                ItemType = BasketItemType.PHYSICAL.ToString(),
        //                Price = item.NormalPrice.ToString()
        //            };
        //            request.BasketItems.Add(basketItem);
        //        }

        //        PayWithIyzicoInitialize PayWithIyzicoInitialize = _iyzcoPaymentService.PayWithIyzco3(request);

        //        Console.WriteLine(PayWithIyzicoInitialize.Status);
        //        Console.WriteLine(PayWithIyzicoInitialize.Token);
        //        Console.WriteLine(PayWithIyzicoInitialize.TokenExpireTime);
        //        Console.WriteLine(PayWithIyzicoInitialize.PayWithIyzicoPageUrl);
        //        Console.WriteLine(PayWithIyzicoInitialize.Locale);
        //        Console.WriteLine(PayWithIyzicoInitialize.ErrorMessage);
        //        Process.Start(new ProcessStartInfo(PayWithIyzicoInitialize.PayWithIyzicoPageUrl) { UseShellExecute = true });
        //        return Ok(PayWithIyzicoInitialize.PayWithIyzicoPageUrl);

        //    }
        //    catch (Exception ex)
        //    {

        //        return Ok(ex.Message);
        //    }

        //}

        [HttpPost("iyzco-payment")]
        public async Task<ActionResult<CreditCardPayment_CommandResponse>> IyzcoPayment(
            Payment_CommandModel request
        )
        {
            CreditCardPayment_CommandResponse model = await _iyzcoPaymentService.IyzcoPayment(request);
            Console.WriteLine("URL: " + model.PageUrl);

            return Ok(model);
        }

        [HttpPost("paytr-payment")]
        public async Task<ActionResult<CreditCardPayment_CommandResponse>> PayTRPayment(
            Payment_CommandModel request
        )
        {
            CreditCardPayment_CommandResponse model =await  _iyzcoPaymentService.PayTRPayment(request);
            Console.WriteLine("URL: " + model.PageUrl);
            return Ok(model);
        }

      

      
        [HttpGet("update-payment-status/{paymentId}/{status}")]
        public async Task<ActionResult<List<PaymentList_VM>>> UpdatePaymentStatus(
            int paymentId,
            bool status
        )
        {
            bool response = await _iyzcoPaymentService.UpdatePaymentStatus(paymentId, status);

            return Ok(response);
        }

        [HttpPost("add-payment")]
        public async Task<ActionResult<bool>> AddPayment(Payment_VM request)
        {
            bool response = await _iyzcoPaymentService.AddPayment(request);

            return Ok(response);
        }

        [HttpGet("delete-payment/{id}")]
        public async Task<ActionResult<bool>> DeletePayment(int id)
        {
            bool response = await _iyzcoPaymentService.DeletePayment(id);

            return Ok(response);
        }

        [HttpGet("other-payments/{basketId}/{paymentDescription}/{token}")]
        public async Task<ActionResult<List<CreditCardPayment_CommandResponse>>> OtherPayments(int basketId, string paymentDescription, Guid token)
        {
            CreditCardPayment_CommandResponse response = await _iyzcoPaymentService.OtherPayments( basketId,paymentDescription, token);

            return Ok(response);
        }


        [HttpGet("test")]
        public async Task<ActionResult<bool>> Test(string merchantOid)
        {
            NameValueCollection data = _GeneratePayTrSorguData(_configuration["Payment:PayTR:MerchantId"], _configuration["Payment:PayTR:ApiKey"], _configuration["Payment:PayTR:ApiSecretKey"], merchantOid);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

                byte[] result = client.UploadValues("https://www.paytr.com/odeme/durum-sorgu", "POST", data);

                string ResultAuthTicket = Encoding.UTF8.GetString(result);
                dynamic json = JValue.Parse(ResultAuthTicket);

                return Ok(json);
            }
        }

        private NameValueCollection _GeneratePayTrSorguData(string merchantId, string merchantKey, string merchantSalt, string merchantOid)
        {
            // Gönderilecek veriler oluşturuluyor
            NameValueCollection data = new NameValueCollection();
            data["merchant_id"] = merchantId;
            data["merchant_oid"] = merchantOid;

            // Token oluşturma fonksiyonu, değiştirilmeden kullanılmalıdır.
            string Birlestir = string.Concat(merchantId, merchantOid, merchantSalt);

            HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(merchantKey));
            byte[] b = hmac.ComputeHash(Encoding.UTF8.GetBytes(Birlestir));
            data["paytr_token"] = Convert.ToBase64String(b);

            return data;
        }


        [HttpGet("get-payment-method-list")]
        public async Task<ActionResult<List<PaymentMethod_VM>>> GetPaymentMethodList( )
        {
            List<PaymentMethod_VM> list = await _iyzcoPaymentService.GetPaymentMethodList();

            return Ok(list);
        }

        [HttpPost("update-payment-method")]
        public async Task<ActionResult<bool>> UpdatePaymentFirmInfo(PaymentMethod_VM request)
        {
            bool response = await _iyzcoPaymentService.UpdatePaymentMethod(request);

            return Ok(response);
        }

        [HttpDelete("delete-payment-method")]
        public async Task<ActionResult<bool>> UpdatePaymentMethod(PaymentMethod_VM request)
        {
            bool response = await _iyzcoPaymentService.UpdatePaymentMethod(request);

            return Ok(response);
        }


    }
}
