﻿
using GoogleAPI.Domain.Entities;
using GoogleAPI.Domain.Models.Category.CommandModel;
using GoogleAPI.Domain.Models.Order.CommandModel;
using GoogleAPI.Domain.Models.Order.Filters;
using GoogleAPI.Domain.Models.Order.ResponseModel;
using GoogleAPI.Domain.Models.Order.ViewModel;
using GoogleAPI.Domain.Models.Response;
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
                query = query.Where(o => (o.OrderNo == model.OrderNo) );
            }
            if (model.Id != 0)
            {
                query = query.Where(o => o.Id == model.Id);
            }
            if (model.BaketId != 0)
            {
                query = query.Where(o=> o.BasketId == model.BaketId);
            }
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

            ResponseModel<OrderList_VM> response  = new ResponseModel<OrderList_VM> { Datas = orderList, TotalCount = totalCount };
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
        public async Task<UpdateBasketItemCommandResponse> AddItemToBasket(AddBasketItem_VM model)
        {
            UpdateBasketItemCommandResponse updateBasketItemCommandResponse = new UpdateBasketItemCommandResponse();
            Basket? basket = _context.Baskets.FirstOrDefault(b => b.Id == model.BasketId);
            if (basket == null)
            {
                CreateBasketResponseModel createBasketResponseModel = await AddBasket(model.UserId);
                model.BasketId = createBasketResponseModel.BasketId;

            }
            Product? product = _context.Products.FirstOrDefault(p=>p.StockCode == model.StockCode && p.DimensionId == model.DimentionId && p.ColorId == model.ColorId);  
            if(product == null)
            {
                throw new Exception("Ürün Bulunamadı");
            }
            BasketItem? checkBasketItem = _context.BasketItems.FirstOrDefault(b => b.BasketId == model.BasketId && b.ProductId == product.Id);

            if (checkBasketItem == null)
            {
                BasketItem basketItem = new BasketItem();
                basketItem.ProductId = product.Id;
                basketItem.Quantity = model.Quantity;
                basketItem.BasketId = model.BasketId;
                basketItem.CreatedDate = DateTime.Now;
                var response1 = await _biw.AddAsync(basketItem);
                updateBasketItemCommandResponse.State = true;
                updateBasketItemCommandResponse.BasketId = basketItem.BasketId;
                return updateBasketItemCommandResponse;
            }
            else
            {
                checkBasketItem.Quantity += model.Quantity;
                var response2 = await _biw.Update(checkBasketItem);
                updateBasketItemCommandResponse.State = true;
                updateBasketItemCommandResponse.BasketId = model.BasketId;
                return updateBasketItemCommandResponse;
            }




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
