
using GoogleAPI.Domain.Entities;
using GoogleAPI.Domain.Entities.PaymentEntities;
using GoogleAPI.Domain.Entities.User;
using GoogleAPI.Domain.Models;
using GoogleAPI.Domain.Models.Category.CommandModel;
using GoogleAPI.Domain.Models.Order.CommandModel;
using GoogleAPI.Domain.Models.Order.Filters;
using GoogleAPI.Domain.Models.Order.ResponseModel;
using GoogleAPI.Domain.Models.Order.ViewModel;
using GoogleAPI.Domain.Models.Payment.Filter;
using GoogleAPI.Domain.Models.Payment.ViewModel;
using GoogleAPI.Domain.Models.Response;
using GoogleAPI.Domain.Models.User.ViewModel;
using GoogleAPI.Persistance.Contexts;
using GooleAPI.Application.Abstractions.IServices.IOrder;
using GooleAPI.Application.IRepositories;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using BasketItem = GoogleAPI.Domain.Entities.BasketItem;
using Payment = GoogleAPI.Domain.Entities.PaymentEntities.Payment;


namespace GoogleAPI.Persistance.Concreates.Services.Order
{
    public class OrderService : IOrderService
    {
        IBasketWriteRepository _bw;
        IBasketItemWriteRepository _biw;

        IOrderWriteRepository _ow;
        IOrderReadRepository _or;
        GooleAPIDbContext _context;
        IProductReadRepository _pr;

        IBasketReadRepository _br;
        IBasketItemReadRepository _bir;

        private readonly IPaymentReadRepository _paymetReadRepository;
        private readonly IPaymentWriteRepository _paymetWriteRepository;

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;

        public OrderService(IBasketWriteRepository bw,
        IBasketItemWriteRepository biw,
        IBasketReadRepository br,
        IBasketItemReadRepository bir,
        IOrderWriteRepository ow,
        IOrderReadRepository or, IProductReadRepository pr, GooleAPIDbContext context, IHttpContextAccessor httpContextAccessor,IConfiguration configuration, IPaymentReadRepository paymentReadRepository, IPaymentWriteRepository paymentWriteRepository)
        {
            _bir = bir;
            _biw = biw;
            _br = br;
            _bw = bw;
            _or = or;
            _ow = ow;
            _pr = pr;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _paymetReadRepository = paymentReadRepository;
            _paymetWriteRepository = paymentWriteRepository;
        }



        public async Task<bool> DeleteBasket(int id)
        {
            try
            {
                Basket? basket = await _br.Table.FirstOrDefaultAsync(c => c.Id == id);
                if (basket == null)
                {
                    return false;
                }

                bool response = _bw.Remove(basket);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception($"DeleteColor method failed: {ex.Message}", ex);
            }

        }

        public async Task<bool> DeleteBasketItem(int id)
        {
            //UpdateBasketItemCommandResponse updateBasketItemCommandResponse = new UpdateBasketItemCommandResponse();    
            try
            {
                BasketItem? basketItem = await _bir.Table.FirstOrDefaultAsync(c => c.Id == id);
                if (basketItem == null)
                {
                    //updateBasketItemCommandResponse.State = false;
                    //updateBasketItemCommandResponse.BasketId = basketItem?.BasketId;
                    return false;
                }

                bool response = _biw.Remove(basketItem);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception($"DeleteColor method failed: {ex.Message}", ex);
            }
        }

        public async Task<int> GetBasket(int userId)
        {


            try
            {
                Basket? basket = await _br.Table.FirstOrDefaultAsync(b => b.UserId == userId && b.Order == null);

                if (basket == null)
                {
                    CreateBasketResponseModel responseModel = new CreateBasketResponseModel();
                    responseModel = await AddBasket(userId);
                    return responseModel.BasketId;
                }
                else
                {
                    return basket.Id;
                }
            }
            catch (Exception)
            {

                return 0;
            }



        }

        public async Task<CreateBasketResponseModel> AddBasket(int userId)
        {

            var basket = await _br.Table.FirstOrDefaultAsync(b => b.UserId == userId && b.Order != null && !b.Order.IsCompleted);

            if (basket == null)
            {
                // Create a new basket if no existing basket is found
                basket = new Basket
                {
                    UserId = userId,
                    CreatedDate = DateTime.Now,
                    BaskedNo = Guid.NewGuid(),
                    // Initialize other necessary properties like BaskedNo, Order, BasketItems, etc.
                };

                // Add the new basket to the database
                await _bw.AddAsync(basket);
                Basket? addedBasket = await _br.Table.FirstOrDefaultAsync(b => b.BaskedNo == basket.BaskedNo);
                if (addedBasket != null)
                {
                    CreateBasketResponseModel responseModel = new();
                    responseModel.State = true;
                    responseModel.BasketId = basket.Id;
                    return responseModel;
                }
                else
                {
                    CreateBasketResponseModel responseModel = new();
                    responseModel.State = false;
                    responseModel.BasketId = 0;
                    return responseModel;
                }


            }
            else
            {
                CreateBasketResponseModel responseModel = new();
                responseModel.State = false;
                responseModel.BasketId = 0;
                return responseModel;
            }
        }

        public async Task<ResponseModel<OrderList_VM>> GetOrders(GetOrderListFilterCommandModel? model)
        {
            List<OrderList_VM> orderList = new List<OrderList_VM>();
            IQueryable<Domain.Entities.Order> query = _or.Table.AsQueryable();



            if (model.OrderNo != Guid.Empty)
            {
                query = query.Where(o => (o.OrderNo == model.OrderNo));
            }
            if (model.Id != 0)
            {
                query = query.Where(o => o.Id == model.Id);
            }
            if (model.BasketId != 0)
            {
                query = query.Where(o => o.BasketId == model.BasketId);
            }
            //if (model.UserId!=0)
            //{
            //    query.Include(p => p.Basket).Where(p => p.Basket.UserId == model.UserId);
            //}
            List<Domain.Entities.Order> orders = await query

                .Skip((model.Pagination.Page - 1) * model.Pagination.Size)
                .Take(model.Pagination.Size)
                 .OrderByDescending(o => o.Id)
                .ToListAsync();
            foreach (var o in orders)
            {
                Domain.Models.Order.ViewModel.OrderList_VM orderList_VM = new Domain.Models.Order.ViewModel.OrderList_VM();
                orderList_VM.Id = o.Id;
                orderList_VM.OrderNo = o.OrderNo;
                orderList_VM.UserNameSurname = (from user in _context.Users
                                                join basket in _context.Baskets on user.Id equals basket.UserId
                                                where basket.Id == o.BasketId
                                                select user.FirstName + " " + user.LastName).FirstOrDefault();

                orderList_VM.CreatedDate = o.CreatedDate;
                orderList_VM.Provider = "WhatsApp";
                orderList_VM.Items = await GetBasketItems(o.BasketId);
                orderList_VM.BasketId = o.BasketId;

                // TotalValue hesaplama işlemi
                decimal totalValue = (await (from bi in _context.BasketItems
                                             join b in _context.Baskets on bi.BasketId equals b.Id
                                             join p in _context.Products on bi.ProductId equals p.Id
                                             where b.Id == o.BasketId
                                             select new BasketItemList_VM
                                             {
                                                 Price = p.NormalPrice
                                             }).ToListAsync())
                                              .Sum(o => o.Price);

                orderList_VM.TotalValue = totalValue;

                orderList.Add(orderList_VM);
            }
            int totalCount = await query.CountAsync();

            ResponseModel<OrderList_VM> response = new ResponseModel<OrderList_VM> { Datas = orderList, TotalCount = totalCount };
            return response;
        }


        public async Task<List<BasketItemList_VM>> GetBasketItems(int basketId)
        {
            // Query to retrieve basket items and join them with product information
            var query = from bi in _bir.Table
                        join p in _pr.Table on bi.ProductId equals p.Id
                        join pp in _context.ProductPhotos on p.Id equals pp.ProductId
                        join ph in _context.Photos on pp.PhotoId equals ph.Id
                        join c in _context.Colors on p.ColorId equals c.Id
                        join d in _context.Dimensions on p.DimensionId equals d.Id
                        where bi.BasketId == basketId // Add a condition to filter by basket ID
                        group new { bi, p, ph, c, d } by new
                        {
                            bi.Id,
                            p.Description,
                            ph.Url,
                            ColorDescription = c.Description,
                            DimentionDescription = d.Description,
                            p.NormalPrice,
                            p.StockCode
                        } into grouped
                        select new BasketItemList_VM
                        {
                            Id = grouped.Key.Id,
                            Description = grouped.Key.Description,
                            Quantity = grouped.Sum(item => item.bi.Quantity),
                            PhotoUrl = grouped.Key.Url,
                            ColorDescription = grouped.Key.ColorDescription,
                            DimensionDescription = grouped.Key.DimentionDescription,
                            Price = grouped.Key.NormalPrice,
                            StockCode = grouped.Key.StockCode
                        };


            // Execute the query and populate the BasketItemList_VM list
            var basketItemList_VM = await query.ToListAsync(); // Assuming you are using Entity Framework or a similar ORM

            // Check if there are any results
            if (basketItemList_VM.Any())
            {
                return basketItemList_VM;
            }
            else
            {
                // Handle the case where no items were found for the given basket ID
                // You can throw an exception, return an empty list, or handle it as needed
                // For now, let's return an empty list
                return new List<BasketItemList_VM>();
            }
        }

        public async Task<bool> ClearBasketItems(int basketId)
        {
            List<BasketItem>? basketItems = _context.BasketItems.Where(p => p.BasketId == basketId).ToList();

            if (basketItems != null && basketItems.Count > 0)
            {
                foreach (var item in basketItems)
                {
                    _biw.Remove(item);
                }
            }

            return true;
        }
        //onaylanan siparişin basketId değerini günceller
        public async Task<bool> UpdateOrderBasket(Guid basketNo)
        {
            Basket? basket = await _br.Table.FirstOrDefaultAsync(b => b.BaskedNo == basketNo);
            GoogleAPI.Domain.Entities.Order? order = await _or.Table.FirstOrDefaultAsync(b => b.BasketId == basket.Id);
            order.BasketId = basket.Id;
            var response = await _ow.Update(order);

            return response;
        }

        //sepetteki ürün adedini günceller 
        //eğer istenen miktar stoktakinden fazla ise hata dönmesi lazım
        public async Task<UpdateBasketItemCommandResponse> UpdateBasketItemQuantity(BasketItem_VM model)
        {
            UpdateBasketItemCommandResponse updateBasketItemCommandResponse = new UpdateBasketItemCommandResponse();


            BasketItem? basketItem = await _biw.Table.FirstOrDefaultAsync(bi => bi.BasketId == model.BasketId && bi.Id == model.ProductId);
            if (basketItem != null)
            {
                basketItem.Quantity = basketItem.Quantity + model.Quantity;
                bool response = await _biw.Update(basketItem);
                updateBasketItemCommandResponse.State = true;
                updateBasketItemCommandResponse.BasketId = basketItem.BasketId;
                return updateBasketItemCommandResponse;
            }
            updateBasketItemCommandResponse.State = true;
            updateBasketItemCommandResponse.BasketId = model.BasketId;
            return updateBasketItemCommandResponse;

        }
        //sepetteki ürün adedini günceller
        public async Task<UpdateBasketItemCommandResponse> AddItemToBasket(List<AddBasketItem_VM> models)
        {

            UpdateBasketItemCommandResponse updateBasketItemCommandResponse = new UpdateBasketItemCommandResponse();


            foreach (var model in models)
            {
                Basket? basket = _context.Baskets.FirstOrDefault(b => b.Id == model.BasketId);
                if (basket == null)
                {
                    CreateBasketResponseModel createBasketResponseModel = await AddBasket(model.UserId);
                    model.BasketId = createBasketResponseModel.BasketId;

                }
                Product? product = _context.Products.FirstOrDefault(p => p.StockCode == model.StockCode && p.DimensionId == model.DimensionId && p.ColorId == model.ColorId);
                Product? _product = new Product();
                if (product == null)
                {
                    _product = _context.Products.FirstOrDefault(p => p.Id == model.ProductId);
                    if (_product == null)
                    {
                        throw new Exception("Ürün Bulunamadı");
                    }
                }

                BasketItem? checkBasketItem = new BasketItem();
                ;
                if (product != null)
                {

                    checkBasketItem = _context.BasketItems.FirstOrDefault(b => b.BasketId == model.BasketId && b.ProductId == product.Id);
                }
                else
                {
                    checkBasketItem = _context.BasketItems.FirstOrDefault(b => b.BasketId == model.BasketId && b.ProductId == _product.Id);
                }

                if (checkBasketItem == null)
                {
                    BasketItem basketItem = new BasketItem();
                    basketItem.ProductId = product == null ? _product.Id : product.Id;
                    basketItem.Quantity = model.Quantity;
                    basketItem.BasketId = model.BasketId;
                    basketItem.CreatedDate = DateTime.Now;
                    var response1 = await _biw.AddAsync(basketItem);
                    updateBasketItemCommandResponse.State = true;
                    updateBasketItemCommandResponse.BasketId = basketItem.BasketId;
                    //  return updateBasketItemCommandResponse;
                }
                else
                {
                    checkBasketItem.Quantity += model.Quantity;
                    var response2 = await _biw.Update(checkBasketItem);
                    updateBasketItemCommandResponse.State = true;
                    updateBasketItemCommandResponse.BasketId = model.BasketId;
                    // return updateBasketItemCommandResponse;
                }

            }
            return updateBasketItemCommandResponse;

        }
        //sepeti onayla dedikten sorna kişinin güncel sepetID;
        //yeni bir order no verilir
        //alınan güncel basketID değeri order içindeki basketID alanına yazılır 

        public async Task<bool> CreateOrder(CreateOrderCommandModel model)
        {
            Domain.Entities.Order order = new Domain.Entities.Order();
            order.UpdatedDate = DateTime.Now;
            order.BasketId = model.BasketId;
            order.OrderNo = Guid.NewGuid();
            order.ShippingAddressId = model.ShippingAddressId; //kullanıcı farklı bir fatura adresi verebilir
            order.CreatedDate = DateTime.Now;
            order.IsCompleted = true;
            bool response = await _ow.AddAsync(order);

            return response;
        }

        //ilgili siparişin IsCompleted değeri true/false olarak ayarlarnır
        public async Task<bool> CompleteOrder(CompleteOrderCommandModel model)
        {
            Domain.Entities.Order? order = await _ow.Table.FirstOrDefaultAsync(o => o.OrderNo == model.OrderNo);
            order.IsCompleted = model.IsCompleted;
            var response = await _ow.Update(order);

            return (response);

        }
        //ilgili sipariş sipariş Id değerine göre silinir
        public async Task<bool> DeleteOrder(int id)
        {
            Domain.Entities.Order? order = await _ow.Table.FirstOrDefaultAsync(o => o.Id == id);
            if (order != null)
            {
                var response = await _ow.RemoveAsync(id);
                return (response);
            }
            else
            {
                return false;
            }

        }

        //ilgili siparişler bir filtreleme Modeline göre Listelencek 
        //filteleme Modeli // Id,orderNo,Başlangıç tarihi , bitiş tarihi ,siparişkaynağı (whatshapp,telegram) alanlarına göre olucak 

        public bool IsAlphanumericString(string input)
        {
            // İstenen uzunluğun kontrolü
            if (input.Length != 10)
            {
                return false;
            }

            // Her karakter için kontrol yapılması
            foreach (char c in input)
            {
                if (!char.IsDigit(c) && !char.IsUpper(c))
                {
                    return false;
                }
            }

            // Yukarıdaki kontrolleri geçen bir dize, geçerli olarak kabul edilir
            return true;
        }
        public async Task<string> GenerateUniqueValue( )
        {
            Guid guid = Guid.NewGuid();
            byte[] bytes = guid.ToByteArray();
            string uniqueValue = BitConverter.ToString(bytes).Replace("-", "").Substring(0, 12);
            return uniqueValue;
        }
        public async Task<OrderUser_VM> GetOrderUser(int? userId)
        {
            if (userId != null)
            {
                User? user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
                if (user != null)
                {
                    OrderUser_VM _user = new OrderUser_VM()
                    {
                        UserId = user.Id,
                        NameSurname = user.FirstName + " " + user.LastName,
                        PhoneNumber = user.PhoneNumber,

                    };

                    return _user;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }


        }

        public async Task<UserShippingAddress_VM> GetUserOrderShippingAddres(int basketId)
        {
            GoogleAPI.Domain.Entities.Order? order = await _context.Orders.FirstOrDefaultAsync(o => o.BasketId == basketId);
            if (order != null)
            {
                UserShippingAddress_VM? model = await (from a in _context.ShippingAddresses
                                                       where a.Id == order.ShippingAddressId
                                                       join c in _context.Countries on a.CountryId equals c.Id
                                                       join p in _context.Provinces on a.ProvinceId equals p.Id
                                                       join d in _context.Districts on a.DistrictId equals d.Id
                                                       join u in _context.Users on a.UserId equals u.Id
                                                       join n in _context.Neighborhoods on a.NeighborhoodId equals n.Id
                                                       select new UserShippingAddress_VM
                                                       {
                                                           Id = a.Id,
                                                           UserId = a.UserId,
                                                           NameSurname = u.FirstName + " " + u.LastName,
                                                           AddressTitle = a.AddressTitle,
                                                           AddressDescription = a.AddressDescription,
                                                           CountryDescripton = c.Description,
                                                           ProvinceDescripton = p.Description,
                                                           DistrictDescripton = d.Description,
                                                           NeighborhoodDescripton = n.Description,
                                                           IsIndividual = a.IsIndividual,
                                                           IsCorporate = a.IsCorporate,
                                                           CorparateDescription = a.CorparateDescription,
                                                           TaxAuthorityDescription = a.TaxAuthorityDescription,
                                                           TaxNo = a.TaxNo,
                                                           PostalCode = a.PostalCode,
                                                           UpdatedDate = a.UpdatedDate
                                                       }).FirstOrDefaultAsync();

                Console.WriteLine(model);
                return model;
            }

            else
            {
                return null;
            }


        }

        public async Task<List<GetOrderDetail_ResponseModel>> GetOrdersOfUser(int userId, int count)
        {

            List<GetOrderDetail_ResponseModel> models = new List<GetOrderDetail_ResponseModel>();
            List<Basket> baskets = await _context.Baskets.Where(b => b.UserId == userId).OrderByDescending(b => b.CreatedDate).Take(count).ToListAsync();
            foreach (var item in baskets)
            {
                GetOrderDetail_ResponseModel model = await GetOrderDetail(item.Id);
                models.Add(model);
            }

            return models;
        }
        public async Task<GetOrderDetail_ResponseModel> GetOrderDetail(int basketId)
        {
            try
            {
                Domain.Entities.Basket? basket = await _context.Baskets.FirstOrDefaultAsync(o => o.Id == basketId);
                if (basket != null)
                {
                    GetOrderDetail_ResponseModel response = new GetOrderDetail_ResponseModel();
                    response.Address = await GetUserOrderShippingAddres(basket.Id);
                    response.User = await GetOrderUser(basket.UserId);
                    GetOrderListFilterCommandModel filter = new GetOrderListFilterCommandModel();
                    filter.Pagination = new Pagination();
                    filter.Pagination.Size = 1;
                    filter.Pagination.Page = 1;
                    filter.BasketId = basketId;

                    int? orderId = _context.Orders.FirstOrDefault(o => o.BasketId == basketId)?.Id;
                    if(orderId == null)
                    {
                        response.Payments = null;
                    }
                    if (orderId != null)
                    
                    {
                        response.Payments =await  GetPaymentsOfOrderList(new PaymentFilter { OrderId = orderId , Status = true });
                    }
                   

                    ResponseModel<OrderList_VM> _response = await GetOrders(filter);

                    if (_response.Datas != null)
                    {
                    }
                    if (_response.Datas.Count > 0)
                    {

                        response.OrderDetail = _response.Datas.First();
                    }
                    else
                    {
                        response.OrderDetail = null;
                    }

                    return response;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message + ex.StackTrace);
            }


        }

        public async Task<GetOrderDetail_ResponseModel> CheckIyzcoPaymentStatus(string conversationId)
        {

            //ÖDEME ONAYI NASIL VERİLİR? 
            

            //CLİENT TARAFINDAN BİR CID YOLLANANIR

            Payment? payment = _context.Payments.FirstOrDefault(payment => payment.ConversationId == conversationId);
            if ((payment) != null)
            {
            

                Iyzipay.Options options = new Iyzipay.Options
                {
                    ApiKey = _configuration["Payment:Iyzco:ApiKey"],
                    SecretKey = _configuration["Payment:Iyzco:ApiSecretKey"],
                    BaseUrl = "https://sandbox-api.iyzipay.com"
                };

                RetrieveCheckoutFormRequest request = new RetrieveCheckoutFormRequest();
                request.Locale = "tr";
                request.ConversationId = conversationId;
                request.Token = payment.PaymentToken;

                CheckoutForm checkoutForm = CheckoutForm.Retrieve(request, options);

                //CLİENT TARAFINDAN YOLLANAN ID DB YE KAYDEDİLEN VERİLERLE UYUŞUYORSA VE BAŞARILI İSE GERİYE SİPARİŞ DETAYI DÖNDÜRÜLÜR
                if (checkoutForm.ConversationId == payment.ConversationId && checkoutForm.Token == payment.PaymentToken && Convert.ToDecimal(checkoutForm.PaidPrice) == payment.PaymentValue)
                {
                    int basketId = _context.Orders.FirstOrDefault(o => o.Id == payment.OrderId).BasketId;
                    if (basketId != null)
                    {
                        if(payment.Status != true)
                        {
                            payment.Status = true;
                            await _paymetWriteRepository.Update(payment);


                        }

                        //update işlemleri 
                      
                        GetOrderDetail_ResponseModel model = await GetOrderDetail(basketId);

                        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(model));
                        return model;
                    }
                    else
                    {
                        throw new Exception("basketId null");
                    }

                }
                else
                {
                    throw new Exception("Ödeme Verileri DB'ile Eşleşmedi");
                }


            }
            else
            {
                throw new Exception("Ödeme Bulunamadı");
            }


        }

        public async Task<GetOrderDetail_ResponseModel> CheckPaytrPaymentStatus(string conversationId,bool status)
        {

            Payment? payment = _context.Payments.FirstOrDefault(payment => payment.ConversationId == conversationId);
            if ((payment) != null)
            {
                Iyzipay.Options options = new Iyzipay.Options
                {
                    ApiKey = _configuration["Payment:Iyzco:ApiKey"],
                    SecretKey = _configuration["Payment:Iyzco:ApiSecretKey"],
                    BaseUrl = "https://sandbox-api.iyzipay.com"
                };

                RetrieveCheckoutFormRequest request = new RetrieveCheckoutFormRequest();
                request.Locale = "tr";
                request.ConversationId = conversationId;
                request.Token = payment.PaymentToken;

                CheckoutForm checkoutForm = CheckoutForm.Retrieve(request, options);

                //CLİENT TARAFINDAN YOLLANAN ID DB YE KAYDEDİLEN VERİLERLE UYUŞUYORSA VE BAŞARILI İSE GERİYE SİPARİŞ DETAYI DÖNDÜRÜLÜR
                if (checkoutForm.ConversationId == payment.ConversationId && checkoutForm.Token == payment.PaymentToken && Convert.ToDecimal(checkoutForm.PaidPrice) == payment.PaymentValue)
                {
                    int basketId = _context.Orders.FirstOrDefault(o => o.Id == payment.OrderId).BasketId;
                    if (basketId != null)
                    {
                        if (payment.Status != true)
                        {
                            payment.Status = true;
                            await _paymetWriteRepository.Update(payment);


                        }

                        //update işlemleri 

                        GetOrderDetail_ResponseModel model = await GetOrderDetail(basketId);

                        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(model));
                        return model;
                    }
                    else
                    {
                        throw new Exception("basketId null");
                    }

                }
                else
                {
                    throw new Exception("Ödeme Verileri DB'ile Eşleşmedi");
                }


            }
            else
            {
                throw new Exception("Ödeme Bulunamadı");
            }


        }

        public async Task<List<PaymentList_VM>> GetPaymentsOfOrderList(PaymentFilter request)
        {

            var query = from p in _context.Payments
                        join o in _context.Orders on p.OrderId equals o.Id
                        join b in _context.Baskets on o.BasketId equals b.Id
                        join pm in _context.PaymentMethods on p.PaymentMethodId equals pm.Id
                        where (request.PaymentId == 0 ?   p.Id > 0 : p.Id == request.PaymentId) &&
                              (request.BasketId == 0 ? b.Id > 0 : b.Id == request.BasketId) &&
                              (request.OrderId == 0 ? o.Id > 0 : o.Id == request.OrderId) &&
                              (request.PaymentMethodId == 0 ? p.PaymentMethodId > 0 : p.PaymentMethodId == request.PaymentMethodId) &&
                              p.Status == request.Status
                        select new PaymentList_VM
                        {
                            Id = p.Id,
                            OrderNo = o.OrderNo,
                            OrderCreatedDate = o.CreatedDate,
                            BasketId = b.Id,
                            BasketCreatedDate = b.CreatedDate,
                            PaymentToken = p.PaymentToken,
                            PaymentMethodDescription = pm.Description,
                            Status = p.Status,
                            ExceptionCode = p.ExceptionCode,
                            ExceptionDescription = p.ExceptionDescription
                        };

            List<PaymentList_VM> response = await query.ToListAsync();

            return response;

        }


    }
}
