
using GoogleAPI.Domain.Models.Category.CommandModel;
using GoogleAPI.Domain.Models.Order.CommandModel;
using GoogleAPI.Domain.Models.Order.Filters;
using GoogleAPI.Domain.Models.Order.ResponseModel;
using GoogleAPI.Domain.Models.Order.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooleAPI.Application.Abstractions.IServices.IOrder
{
    public  interface IOrderService
    {
        public Task<UpdateBasketItemCommandResponse> AddItemToBasket(AddBasketItem_VM model);
        public Task<bool> DeleteBasketItem(int id);
        public Task<UpdateBasketItemCommandResponse> UpdateBasketItemQuantity(BasketItem_VM model);
        public Task<List<BasketItemList_VM>> GetBasketItems(int basketId);

        public Task<int> GetBasket(int userId);
        public Task<CreateBasketResponseModel> AddBasket(int userId);
        public Task<bool> DeleteBasket(int id);
        public Task<bool> UpdateOrderBasket(Guid basketNo);

        public Task<bool> CreateOrder(CreateOrderCommandModel model);
        public Task<bool> CompleteOrder(CompleteOrderCommandModel model);
        public Task<bool> DeleteOrder( int id);
        public Task<List<OrderList_VM>> GetOrders( OrderListFilterCommandModel model);

    }
}
