﻿
using GoogleAPI.Domain.Entities;
using GoogleAPI.Domain.Models.Order.CommandModel;
using GoogleAPI.Domain.Models.Order.Filters;
using GoogleAPI.Domain.Models.Order.ResponseModel;
using GoogleAPI.Domain.Models.Order.ViewModel;
using GoogleAPI.Persistance.Contexts;
using GooleAPI.Application.Abstractions.IServices.IOrder;
using GooleAPI.Application.IRepositories;
using Microsoft.EntityFrameworkCore;


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

        public OrderService(IBasketWriteRepository bw,
        IBasketItemWriteRepository biw,
        IBasketReadRepository br,
        IBasketItemReadRepository bir,
        IOrderWriteRepository ow,
        IOrderReadRepository or, IProductReadRepository pr, GooleAPIDbContext context)
        {
            _bir = bir;
            _biw = biw;
            _br = br;
            _bw = bw;
            _or = or;
            _ow = ow;
            _pr = pr;
            _context = context;

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
            try
            {
                BasketItem? basketItem = await _bir.Table.FirstOrDefaultAsync(c => c.Id == id);
                if (basketItem == null)
                {
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


            var basket = await _br.Table.FirstOrDefaultAsync(b => b.UserId == userId && b.Order != null && !b.Order.IsCompleted);

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

        public async Task<List<OrderList_VM>> GetOrders(OrderListFilterCommandModel? model)
        {
            List<OrderList_VM> orderList = new List<OrderList_VM>();
            List<Domain.Entities.Order> orders = new List<Domain.Entities.Order>();
            IQueryable<Domain.Entities.Order> query = _or.Table.AsQueryable();

            List<Domain.Entities.Order> orders2 = await _or.Table.OrderByDescending(o => o.CreatedDate).Take(100).ToListAsync();
            foreach (var o in orders2)
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

            return orderList;


            //if (model == null)
            //{


            //}
            //else
            //{
            //    return orderList;
            //}
        }



        public async Task<List<BasketItemList_VM>> GetBasketItems(int basketId)
        {
            // Create a list to hold BasketItemList_VM objects
            List<BasketItemList_VM> basketItemList_VM = new List<BasketItemList_VM>();

            // Query to retrieve basket items and join them with product information
            var query = from bi in _bir.Table
                        join p in _pr.Table on bi.ProductId equals p.Id
                        join pp in _context.ProductPhotos on p.Id equals pp.ProductId
                        join ph in _context.Photos on pp.PhotoId equals ph.Id
                        join c in _context.Colors on p.ColorId equals c.Id
                        join d in _context.Dimensions on p.DimensionId equals d.Id
                        where bi.BasketId == basketId // Add a condition to filter by basket ID
                        select new BasketItemList_VM
                        {
                            Description = p.Description,
                            Quantity = bi.Quantity,
                            PhotoUrl = ph.Url,
                            ColorDescription = c.Description,
                            DimentionDescription = d.Description,
                            Price = p.NormalPrice
                        };

            // Execute the query and populate the BasketItemList_VM list
            basketItemList_VM = await query.ToListAsync(); // Assuming you are using Entity Framework or a similar ORM

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
        public async Task<bool> UpdateBasketItemQuantity(BasketItem_VM model)
        {
            BasketItem? basketItem = await _biw.Table.FirstOrDefaultAsync(bi => bi.BasketId == model.BasketId && bi.ProductId == model.ProductId);
            if (basketItem != null)
            {
                basketItem.Quantity = model.Quantity;
                bool response = await _biw.Update(basketItem);

                return response;
            }

            return false;

        }
        //sepetteki ürün adedini günceller
        public async Task<bool> AddBasketITem(BasketItem_VM model)
        {
            BasketItem basketItem = new BasketItem();
            basketItem.ProductId = model.ProductId;
            basketItem.Quantity = model.Quantity;
            basketItem.BasketId = model.BasketId;
            basketItem.CreatedDate = DateTime.Now;
            var response = await _biw.AddAsync(basketItem);
            return response;


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
            order.BillingAddressId = model.BillingAddressId;    //kullanıcı farklı bir teslimat adresi verebilir
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

    }
}