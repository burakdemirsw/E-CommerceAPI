using FluentNHibernate.Mapping;
using GoogleAPI.Domain.Entities.All_Settings;
using GoogleAPI.Domain.Entities.Cargo;
using GoogleAPI.Domain.Entities.PaymentEntities;
using GoogleAPI.Domain.Models.Order.ResponseModel;
using GoogleAPI.Domain.Models.Payment;
using GoogleAPI.Domain.Models.Payment.Cart;
using GoogleAPI.Domain.Models.Payment.CommandResponse;
using GoogleAPI.Domain.Models.Payment.Filter;
using GoogleAPI.Domain.Models.Payment.ViewModel;
using GoogleAPI.Persistance.Contexts;
using GooleAPI.Application.Abstractions.IServices.IOrder;
using GooleAPI.Application.Abstractions.IServices.IyzcoPayment;
using GooleAPI.Application.IRepositories;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Nancy.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Specialized;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using static QRCoder.PayloadGenerator;
using Payment = GoogleAPI.Domain.Entities.PaymentEntities.Payment;

namespace GoogleAPI.Persistance.Concreates.Services.IyzcoPayment
{
    public class IyzcoPaymentService : IIyzcoPayment
    {
        private readonly IConfiguration _configuration;
        private readonly IPaymentReadRepository _pr;
        private readonly IPaymentWriteRepository _pw;
        private readonly IPaymentMethodWriteRepository _pmw;
        private readonly IPaymentMethodReadRepository _prw;
        private readonly GooleAPIDbContext _c;
        private readonly IOrderService _os;
        public IyzcoPaymentService(IConfiguration configuration, IPaymentReadRepository pr, IPaymentWriteRepository pw, IPaymentMethodWriteRepository pmw, IPaymentMethodReadRepository prw, IOrderService os
            , GooleAPIDbContext context)
        {
            _configuration = configuration;
            _pr = pr;
            _pw = pw;
            _pmw = pmw;
            _prw = prw;
            _c = context;
            _os = os;
        }

        public async Task<bool> AddPayment(Payment_VM request)
        {
            Payment payment = new Payment()
            {
                Id = 0,
                Status = request.Status,
                PaymentMethodId = request.PaymentMethodId,
                PaymentToken = request.PaymentToken,
                PaymentValue = Convert.ToDecimal(request.PaymentValue),
                ExceptionCode = request.ExceptionCode,
                ExceptionDescription = request.ExceptionDescription,

            };
            bool state = await _pw.AddAsync(payment);

            return state;
        }

        public async Task<bool> DeletePayment(int request)
        {
            Payment? payment = _pr.Table.FirstOrDefault(x => x.Id == request);
            if (payment == null)
            {
                return false;
            }
            else
            {
                var state = _pw.Remove(payment);

                return state;
            }

        }


        public async Task<bool> UpdatePaymentStatus(int paymentId, bool status)
        {
            Payment? payment = _pr.Table.FirstOrDefault(x => x.Id == paymentId);
            if (payment == null)
            {
                return false;
            }
            else
            {
                payment.Status = status;
                bool state = await _pw.Update(payment);

                return state;
            }
        }

   

        public async Task<List<PaymentMethod_VM>> GetPaymentMethodList()
        {
            List<PaymentMethod_VM> response = await _c.PaymentMethods.Select(pm => new PaymentMethod_VM
            {
                Description = pm.Description,
                Id = pm.Id,
                IsActive = pm.IsActive,
                MerchantId = pm.MerchantId,
                ApiKey = pm.ApiKey,
                ApiSecretKey = pm.ApiSecretKey,
                OkUrl = pm.OkUrl,
                FailUrl  = pm.FailUrl,
                SpecialField = pm.SpecialField,
                SpecialField_2 = pm.SpecialField_2,
                SpecialField_3 = pm.SpecialField_3,

            }).ToListAsync();

            return response;
        }



        //public void PayWithIyzco()
        //{
        //    string apiKey = "sandbox-AFu267a0mCx7FhZP8wg32qRzjhwkkiBI";
        //    string secretKey = "sandbox-vXp4jI21rePsw2pMiAUUd3t0vIf1l288";

        //    Options options = new Options
        //    {
        //        ApiKey = _configuration["Payment:Iyzco:ApiKey"],
        //        SecretKey = _configuration["Payment:Iyzco:ApiSecretKey"],
        //        BaseUrl = "https://sandbox-api.iyzipay.com"
        //    };

        //    CreatePaymentRequest request = new CreatePaymentRequest
        //    {
        //        Locale = Locale.TR.ToString(),
        //        ConversationId = Guid.NewGuid().ToString(),
        //        Price = "1000.00",
        //        PaidPrice = "1000.10",
        //        Currency = Currency.TRY.ToString(),
        //        Installment = 1,
        //        BasketId = "B67832",
        //        PaymentChannel = PaymentChannel.WEB.ToString(),
        //        PaymentGroup = PaymentGroup.PRODUCT.ToString(),
        //        PaymentCard = new PaymentCard
        //        {
        //            CardHolderName = "John Doe",
        //            CardNumber = "5528790000000008",
        //            ExpireMonth = "   ",
        //            ExpireYear = "2030",
        //            Cvc = "123",
        //            RegisterCard = 0
        //        },
        //        Buyer = new Buyer
        //        {
        //            Id = "BY789",
        //            Name = "John",
        //            Surname = "Doe",
        //            GsmNumber = "+905555555555",
        //            Email = "john.doe@example.com",
        //            IdentityNumber = "12345678901",
        //            RegistrationDate = "2015-10-05 12:43:35",
        //            LastLoginDate = "2015-10-05 12:43:35",
        //            RegistrationAddress = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1",
        //            City = "Istanbul",
        //            Country = "Turkey",
        //            ZipCode = "34732"
        //        },
        //        ShippingAddress = new Address
        //        {
        //            ContactName = "Jane Doe",
        //            City = "Istanbul",
        //            Country = "Turkey",
        //            Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1",
        //            ZipCode = "34732"
        //        },
        //        BillingAddress = new Address
        //        {
        //            ContactName = "Jane Doe",
        //            City = "Istanbul",
        //            Country = "Turkey",
        //            Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1",
        //            ZipCode = "34732"
        //        },
        //        BasketItems = new List<BasketItem>
        //        {
        //            new BasketItem
        //            {
        //                Id = "BI101",
        //                Name = "Item Name",
        //                Category1 = "Category",
        //                ItemType = BasketItemType.PHYSICAL.ToString(),
        //                Price = "10.00"
        //            }
        //        }
        //    };

        //    Payment payment = Payment.Create(request, options);

        //    Console.WriteLine("Ödeme Durumu: " + payment.Status);
        //    Console.WriteLine("Ödeme Hata Kodu: " + payment.ErrorCode);
        //    Console.WriteLine("Ödeme Hata Mesajı: " + payment.ErrorMessage);
        //}

        //public Payment PayWithIyzco2(CreatePaymentRequest request)
        //{
        //    string apiKey = "sandbox-AFu267a0mCx7FhZP8wg32qRzjhwkkiBI";
        //    string secretKey = "sandbox-vXp4jI21rePsw2pMiAUUd3t0vIf1l288";

        //    Options options = new Options
        //    {
        //        ApiKey = _configuration["Payment:Iyzco:ApiKey"],
        //        SecretKey = _configuration["Payment:Iyzco:ApiSecretKey"],
        //        BaseUrl = "https://sandbox-api.iyzipay.com"
        //    };

        //    Payment payment = Payment.Create(request, options);

        //    return payment;
        //}

        //public PayWithIyzicoInitialize PayWithIyzco3(CreatePayWithIyzicoInitializeRequest request)
        //{
        //    Options options = new Options
        //    {
        //        ApiKey = _configuration["Payment:Iyzco:ApiKey"],
        //        SecretKey = _configuration["Payment:Iyzco:ApiSecretKey"],
        //        BaseUrl = "https://sandbox-api.iyzipay.com"
        //    };

        //    PayWithIyzicoInitialize payWithIyzicoInitialize = PayWithIyzicoInitialize.Create(
        //        request,
        //        options
        //    );

        //    return payWithIyzicoInitialize;
        //}

        public async Task<CreditCardPayment_CommandResponse> IyzcoPayment(Payment_CommandModel model)
        {

            try
            {

                List<int> enabledInstallments = new List<int>();
                enabledInstallments.Add(2);
                enabledInstallments.Add(3);
                enabledInstallments.Add(6);
                enabledInstallments.Add(9);
                var CID = Guid.NewGuid().ToString();
                CreateCheckoutFormInitializeRequest request = new CreateCheckoutFormInitializeRequest
                {

                    Locale = Locale.TR.ToString(),
                    ConversationId = CID,
                    Price = model.BasketPrice,
                    PaidPrice = model.BasketPrice,
                    Currency = Currency.TRY.ToString(),
                    BasketId = model.BasketId,
                    PaymentGroup = "PRODUCT",
                    
                    //CallbackUrl = "https://www.merchant.com/callback",
                    CallbackUrl = $"http://localhost:4202/admin/product/payment-status/iyzico/{CID}",


                    Buyer = new Buyer
                    {
                        Id = model.User.Id.ToString(), // Alıcı kimliği
                        Name = model.User.FirstName,
                        Surname = model.User.LastName,
                        GsmNumber = model.User.PhoneNumber, // Alıcı telefon numarası
                        Email = model.User.Email,
                        IdentityNumber = "11111111111", // Alıcı kimlik numarası
                        LastLoginDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), // Son giriş tarihi
                        RegistrationDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), // Kayıt tarihi
                        RegistrationAddress = model.Address.AddressDescription, // Kayıt adresi
                        Ip = "178.247.147.221",
                        City = model.Address.ProvinceDescripton,
                        Country = model.Address.CountryDescripton,
                        ZipCode = model.Address.PostalCode // Posta kodu
                    },
                    ShippingAddress = new Address
                    {
                        ContactName = model.User.FirstName + " " + model.User.LastName,
                        City = model.Address.ProvinceDescripton,
                        Country = model.Address.CountryDescripton,
                        Description = model.Address.AddressDescription,
                        ZipCode = model.Address.PostalCode
                    },
                    BillingAddress = new Address
                    {
                        ContactName = model.User.FirstName + " " + model.User.LastName,
                        City = model.Address.ProvinceDescripton,
                        Country = model.Address.CountryDescripton,
                        Description = model.Address.AddressDescription,
                        ZipCode = model.Address.PostalCode
                    },
                    BasketItems = new List<BasketItem>()
                };


                foreach (var item in model.BasketItems)
                {
                    BasketItem basketItem = new BasketItem
                    {
                        Id = item.Id.ToString(),
                        Name = item.Description,
                        Category1 = "Giyim",
                        ItemType = BasketItemType.PHYSICAL.ToString(),
                        Price = item.NormalPrice.ToString()
                    };
                    request.BasketItems.Add(basketItem);
                }

                Iyzipay.Options options = new Iyzipay.Options
                {
                    ApiKey = _configuration["Payment:Iyzco:ApiKey"],
                    SecretKey = _configuration["Payment:Iyzco:ApiSecretKey"],
                    BaseUrl = "https://sandbox-api.iyzipay.com"
                };

                CheckoutFormInitialize PayWithIyzicoInitialize = CheckoutFormInitialize.Create(
                    request,
                    options
                );
                //Process.Start(new ProcessStartInfo(PayWithIyzicoInitialize.PaymentPageUrl) { UseShellExecute = true });
                
                if (PayWithIyzicoInitialize == null)
                {
                    throw new Exception("CheckoutFormInitialize Null. Reason :" + PayWithIyzicoInitialize.ErrorMessage);
                }

                Console.WriteLine(PayWithIyzicoInitialize.Token);
                Console.WriteLine(PayWithIyzicoInitialize.ConversationId);
                 if (PayWithIyzicoInitialize.Status == "success")
                {
                    Payment payment = new Payment();
                    payment.PaymentValue = Convert.ToDecimal(model.BasketPrice);
                    payment.OrderId = _c.Orders.FirstOrDefault(o => o.BasketId == Convert.ToInt32(model.BasketId))?.Id;
                    payment.PaymentMethodId = _c.PaymentMethods.FirstOrDefault(pm => pm.Description == "Iyzico").Id;
                    payment.CreatedDate = DateTime.Now;
                    payment.PaymentToken = PayWithIyzicoInitialize.Token;
                    payment.ConversationId = request.ConversationId;
                    var response = await _pw.AddAsync( payment );

                }
                else
                {
                    Payment payment = new Payment();
                    payment.PaymentValue = Convert.ToDecimal(model.BasketPrice);
                    payment.OrderId = _c.Orders.FirstOrDefault(o => o.BasketId == Convert.ToInt32(model.BasketId))?.Id;
                    payment.PaymentMethodId = _c.PaymentMethods.FirstOrDefault(pm => pm.Description == "Iyzico").Id;
                    payment.CreatedDate = DateTime.Now;
                    payment.PaymentToken = PayWithIyzicoInitialize.Token;
                    payment.ConversationId = request.ConversationId;
                    var response = await _pw.AddAsync(payment);
                }

                CreditCardPayment_CommandResponse CreditCardPayment_CommandResponse = new CreditCardPayment_CommandResponse() { PageUrl = PayWithIyzicoInitialize.PaymentPageUrl };
                
                return CreditCardPayment_CommandResponse;

            }
            catch (Exception ex)
            {
                throw new Exception("CheckoutFormInitialize Null. Reason :" + ex.Message);

            }

        }

        public async  Task<CreditCardPayment_CommandResponse> PayTRPayment(Payment_CommandModel model)
        {
            try
            {
                var CD = Guid.NewGuid().ToString();

                decimal formattedPrice = Convert.ToDecimal($"{model.BasketPrice:F2}");
                string merchant_id = _configuration["Payment:PayTR:MerchantId"];
                string merchant_key = _configuration["Payment:PayTR:ApiKey"];
                string merchant_salt = _configuration["Payment:PayTR:ApiSecretKey"];
                string emailstr = model.User.Email;
                int payment_amountstr = Convert.ToInt32(formattedPrice * 100);
                string merchant_oid = Guid.NewGuid().ToString().Replace("-", "");
                string user_namestr = model.User.Email;
                string user_phonestr = model.User.PhoneNumber;
                string user_addressstr = model.Address.AddressDescription;
                string merchant_ok_url = _configuration["Payment:PayTR:OkUrl"];
                string merchant_fail_url = _configuration["Payment:PayTR:FailUrl"];
                string user_ip = "176.227.56.29";
                List<Product_PayTR> user_basket = new List<Product_PayTR> { };
                Console.WriteLine(merchant_oid);

                // Assume model.BasketItems is an IEnumerable of Products.
                foreach (var product in model.BasketItems)
                {
                    // Create a new product object.
                    var newProduct = new Product_PayTR
                    {
                        Description = product.Description,
                        NormalPrice = $"{product.NormalPrice:F2}",
                        StockAmount = product.StockAmount
                    };

                    // Add the new product object to the user basket.
                    user_basket.Add(newProduct);
                }
                string timeout_limit = "30";
                string debug_on = "0";
                string test_mode = "0";
                string no_installment = "0";
                string max_installment = "0";
                string currency = "TL";
                string lang = "";

                NameValueCollection data = new NameValueCollection();
                data["merchant_id"] = merchant_id;
                data["user_ip"] = user_ip;
                data["merchant_oid"] = merchant_oid;
                data["email"] = emailstr;
                data["payment_amount"] = payment_amountstr.ToString();

                JavaScriptSerializer ser = new JavaScriptSerializer();
                string user_basket_json = ser.Serialize(user_basket);
                string user_basketstr = Convert.ToBase64String(Encoding.UTF8.GetBytes(user_basket_json));
                data["user_basket"] = user_basketstr;

                string merged = string.Concat(merchant_id, user_ip, merchant_oid, emailstr, payment_amountstr.ToString(), user_basketstr, no_installment, max_installment, currency, test_mode, merchant_salt);
                HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(merchant_key));
                byte[] b = hmac.ComputeHash(Encoding.UTF8.GetBytes(merged));

                data["paytr_token"] = Convert.ToBase64String(b);
                data["debug_on"] = debug_on;
                data["test_mode"] = test_mode;
                data["no_installment"] = no_installment;
                data["max_installment"] = max_installment;
                data["user_name"] = user_namestr;
                data["user_address"] = user_addressstr;
                data["user_phone"] = user_phonestr;
                data["merchant_ok_url"] = merchant_ok_url;
                data["merchant_fail_url"] = merchant_fail_url;
                data["timeout_limit"] = timeout_limit;
                data["currency"] = currency;
                data["lang"] = lang;


                using (WebClient client = new WebClient())
                {
                    client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                    byte[] result = client.UploadValues("https://www.paytr.com/odeme/api/get-token", "POST", data);
                    string ResultAuthTicket = Encoding.UTF8.GetString(result);
                    dynamic json = JValue.Parse(ResultAuthTicket);

                    if (json.status == "success")
                    {
                       
                            Payment payment = new Payment();
                            payment.PaymentValue = Convert.ToDecimal(model.BasketPrice);
                            payment.OrderId = _c.Orders.FirstOrDefault(o => o.BasketId == Convert.ToInt32(model.BasketId))?.Id;
                            payment.PaymentMethodId = _c.PaymentMethods.FirstOrDefault(pm => pm.Description == "Iyzico").Id;
                            payment.CreatedDate = DateTime.Now;
                            payment.PaymentToken = json.token;
                            payment.ConversationId = CD;
                            var response = await _pw.AddAsync(payment);


                        var Src = "https://www.paytr.com/odeme/guvenli/" + json.token;
                        //Process.Start(new ProcessStartInfo(Src) { UseShellExecute = true });

                        CreditCardPayment_CommandResponse CreditCardPayment_CommandResponse = new CreditCardPayment_CommandResponse() { PageUrl = Src };

                        return CreditCardPayment_CommandResponse;
                        // İşlem başarılı ise yapılacak işlemler. sipariş onaylama vb



                    }                        
                    
                    else
                    {
                        Payment payment = new Payment();
                        payment.PaymentValue = Convert.ToDecimal(model.BasketPrice);
                        payment.OrderId = _c.Orders.FirstOrDefault(o => o.BasketId == Convert.ToInt32(model.BasketId))?.Id;
                        payment.PaymentMethodId = _c.PaymentMethods.FirstOrDefault(pm => pm.Description == "Iyzico").Id;
                        payment.CreatedDate = DateTime.Now;
                        payment.PaymentToken =null;
                        payment.ConversationId = CD;
                        payment.ExceptionCode = json.exceptionCode;
                        payment.ExceptionDescription = json.exceptionDescription; ;
                        var response = await _pw.AddAsync(payment);

                        throw new Exception(json.reason);
                        // işlem başarısız ise yapılacak işlemler sepete geri döndürme vb
                    }
                }

            }
            catch (Exception ex)
            {

                throw new Exception("PAYTR IFRAME failed. reason:" + ex.Message);
            }
        }

     

        public async  Task<bool> AddPaymentMethod(PaymentMethod_VM request)
        {
            PaymentMethod? paymentMethod = new PaymentMethod();

            paymentMethod.Description = request.Description;
            paymentMethod.IsActive = request.IsActive;
            paymentMethod.MerchantId = request.MerchantId;
            paymentMethod.ApiKey = request.ApiKey;
            paymentMethod.ApiSecretKey = request.ApiSecretKey;
            paymentMethod.OkUrl = request.OkUrl;
            paymentMethod.FailUrl = request.FailUrl;

            bool response = await _pmw.AddAsync(paymentMethod);
            return response;

        }

        public async Task<bool> UpdatePaymentMethod(PaymentMethod_VM request)
        {
            PaymentMethod? paymentMethod = _c.PaymentMethods.FirstOrDefault(p => p.Description.Contains(request.Description));

            paymentMethod.Description = request.Description;
            paymentMethod.IsActive = request.IsActive;
            paymentMethod.MerchantId = request.MerchantId;
            paymentMethod.ApiKey = request.ApiKey;
            paymentMethod.ApiSecretKey = request.ApiSecretKey;
            paymentMethod.OkUrl = request.OkUrl;
            paymentMethod.FailUrl = request.FailUrl;

            if (paymentMethod != null)
            {
                bool response =await  _pmw.Update(paymentMethod);
                return response;


            }
            else
            {
                throw new Exception("Not Found");
            }
        }

        public async Task<bool> DeletePaymentMethod(int paymentMethodId)
        {
            PaymentMethod? paymentMethod = _c.PaymentMethods.FirstOrDefault(p => p.Id == paymentMethodId);

            if (paymentMethod != null)
            {
                bool response =  _pmw.Remove(paymentMethod); 
                return response;


            }
            else
            {
                throw new Exception("Not Found");
            }
        }

        //  "payment-status/:paymentStatus/:paymentMethodId/:paymentTypeId/:orderNo/:token",
        public async Task<CreditCardPayment_CommandResponse> OtherPayments(int basketId ,string paymentDescription,Guid token) 
        {

            List<PaymentMethod> paymentMethods = await _c.PaymentMethods.ToListAsync();
            PaymentMethod? paymentMethod = paymentMethods.FirstOrDefault(pm => pm.Description == paymentDescription);
            int? paymentMethodId = paymentMethod.Id;
            if (paymentMethodId == null || paymentMethod == null)
            {
                throw new Exception("Ödeme Tipi yada Ödeme Metodu Bulunamadı (1)");

            }

            Domain.Entities.Order? order =_c.Orders.FirstOrDefault(o => o.BasketId == basketId);
            if (order == null)
            {
                throw new Exception($"Sipariş Bulunamadı");
            }
            Payment? isAlreadyAddedPayment = _c.Payments.FirstOrDefault(p => p.PaymentToken == token.ToString());
            if (isAlreadyAddedPayment != null)
            {
                throw new Exception($"Bu Token İle Daha Önce {paymentMethod.Description} Metodu Kullanılarak {order.Id} ID'li Siparişe Ödeme Eklendi");
            }
            //CargoFirm? cargoFirm = _c.CargoFirms.FirstOrDefault(cf => cf.IsActive==true);
            //if (cargoFirm == null)
            //{
            //    throw new Exception("Aktif Kargo Firması Bulunamadı");
            //}
            //List<Domain.Entities.BasketItem> basketItems = _c.BasketItems.Where(bi => bi.BasketId == basketId).ToList();
            //Domain.Entities.Product? cargoProduct = _c.Products.FirstOrDefault(p => p.StockCode == cargoFirm.StockCode);
            //if (cargoFirm == null)
            //{
            //    throw new Exception("Kargo Firması Ürünü Bulunamadı");
            //}
            //if (!basketItems.Any(bi=>bi.ProductId == cargoProduct.Id))
            //{
            //    Domain.Entities.BasketItem basketItem = new Domain.Entities.BasketItem();
            //    basketItem.ProductId = cargoProduct.Id;
            //    basketItem.BasketId = basketId; ;
            //    basketItem.PriceOnSale = cargoFirm.SPC_Price;
            //    basketItem.CreatedDate = DateTime.Now;  
            //    basketItem.UpdatedDate = DateTime.Now;
            //    _c.BasketItems.Add(basketItem);
            //    _c.SaveChanges();
            //}



            GetOrderDetail_ResponseModel? orderDetail  = await _os.GetOrderDetail(basketId);
            if(orderDetail != null && paymentMethods != null)
            {
                //var token = Guid.NewGuid().ToString();
               
                Payment payment = new Payment();
                payment.PaymentMethodId = (int)(paymentMethodId == null ? 0 : paymentMethodId);
                payment.Status = false;
                payment.PaymentValue = orderDetail.OrderDetail.TotalValue;
                payment.CreatedDate = DateTime.Now;
                payment.UpdatedDate = DateTime.Now;
                payment.PaymentToken = token.ToString();
                payment.ConversationId = token.ToString();
                payment.OrderId = orderDetail.OrderDetail.Id;


                bool response =  await _pw.AddAsync(payment);
                if (response)
                {
                    //sipariş durumlarını güncelle

                    //Domain.Entities.Order? order = await _c.Orders.FirstOrDefaultAsync(o => o.OrderNo == orderDetail.OrderDetail.OrderNo);
                    if (order != null)
                    {
                        if(paymentDescription == "Havale")
                        {
                            order.OrderShipmentStatusId = 6; //Beklemede
                            order.OrderPaymentStatusId = 6;//Ödeme Bekliyor
                            order.OrderStatusId = 1; //sipariş alındı
                            _c.Orders.Update(order);
                            _c.SaveChanges();

                        }
                        else if(paymentDescription == "Kapıda Ödeme Nakit")
                        {
                            order.OrderShipmentStatusId = 6; //Beklemede
                            order.OrderPaymentStatusId = 1;//Onaylandı
                            order.OrderStatusId = 1; //sipariş alındı
                            _c.Orders.Update(order);
                            _c.SaveChanges();
                        }
                        else if (paymentDescription == "Kapıda Ödeme Kredi Kartı")
                        {
                            order.OrderShipmentStatusId = 6; //Beklemede
                            order.OrderPaymentStatusId = 1;//Onaylandı
                            order.OrderStatusId = 1; //sipariş alındı
                            _c.Orders.Update(order);
                            _c.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("Ödeme Tipi Bulunamadı (2)");
                        }


                        if (paymentDescription == "Havale")
                        {
                            CreditCardPayment_CommandResponse _response = new CreditCardPayment_CommandResponse();
                            _response.PageUrl = $"http://localhost:4202/admin/product/payment-status/false/{paymentMethodId}/{orderDetail.OrderDetail.OrderNo}/{token}";
                            return _response;

                        }
                        else if (paymentDescription == "Kapıda Ödeme Nakit")
                        {
                            CreditCardPayment_CommandResponse _response = new CreditCardPayment_CommandResponse();
                            _response.PageUrl = $"http://localhost:4202/admin/product/payment-status/true/{paymentMethodId}/{orderDetail.OrderDetail.OrderNo}/{token}";
                            return _response;
                        }
                        else if (paymentDescription == "Kapıda Ödeme Kredi Kartı")
                        {
                            CreditCardPayment_CommandResponse _response = new CreditCardPayment_CommandResponse();
                            _response.PageUrl = $"http://localhost:4202/admin/product/payment-statu s/true/{paymentMethodId}/{orderDetail.OrderDetail.OrderNo}/{token}";
                            return _response;
                        }
                        else
                        {
                            return null;
                        }
                       

                    }
                    else
                    {
                        throw new Exception("Sipariş Bulunamadı");

                    }
              

                }
                else
                {
                    throw new Exception("Ödeme Eklenemedi");
                }


 

            }
            else
            {
                throw new Exception("Sipariş Bulunamadı");
            }
        }


    }
}
