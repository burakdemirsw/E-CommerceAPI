﻿
using GoogleAPI.Domain.Models.Category.CommandModel;
using GoogleAPI.Domain.Models.Order.CommandModel;
using GoogleAPI.Domain.Models.Order.Filters;
using GoogleAPI.Domain.Models.Order.ResponseModel;
using GoogleAPI.Domain.Models.Order.ViewModel;
using GoogleAPI.Domain.Models.Payment.Filter;
using GoogleAPI.Domain.Models.Payment.ViewModel;
using GoogleAPI.Domain.Models.Response;
using GoogleAPI.Domain.Models.User.ViewModel;
using Iyzipay.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooleAPI.Application.Abstractions.IServices.IOrder
{
     public  interface IOrderService
    {

         Task<bool> ClearBasketItems(int basketId);
         Task<UpdateBasketItemCommandResponse> AddItemToBasket(List<AddBasketItem_VM> model);
         Task<bool> DeleteBasketItem(int id);
         Task<UpdateBasketItemCommandResponse> UpdateBasketItemQuantity(BasketItem_VM model);
         Task<List<BasketItemList_VM>> GetBasketItems(int basketId);
         Task<GetOrderDetail_ResponseModel> GetOrderDetail(int basketId);
         Task<List<GetOrderDetail_ResponseModel>> GetOrdersOfUser(int userId, int count);
         Task<UserShippingAddress_VM> GetUserOrderShippingAddres(int basketId);
         Task<int> GetBasket(int userId);
         Task<CreateBasketResponseModel> AddBasket(int userId);
         Task<bool> DeleteBasket(int id);
         Task<bool> UpdateOrderBasket(Guid basketNo);

         Task<bool> CreateOrder(CreateOrderCommandModel model);
         Task<bool> CompleteOrder(CompleteOrderCommandModel model);
         Task<bool> DeleteOrder( int id);
         Task<ResponseModel<OrderList_VM>> GetOrders( GetOrderListFilterCommandModel model);
         Task<List<PaymentList_VM>> GetPaymentsOfOrderList(PaymentFilter request);
         Task<GetOrderDetail_ResponseModel> CheckIyzcoPaymentStatus(string conversationId);
        Task<GetOrderDetail_ResponseModel> CheckPaytrPaymentStatus(string conversationId,bool status);
        Task<GetOrderDetail_ResponseModel> CheckOtherPaymentStatus(string token, bool status, int paymentMethodId, Guid orderNo);

    }
}
