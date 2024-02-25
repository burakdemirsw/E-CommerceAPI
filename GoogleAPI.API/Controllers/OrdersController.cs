using GoogleAPI.Domain.Models.Category.CommandModel;
using GoogleAPI.Domain.Models.Order.CommandModel;
using GoogleAPI.Domain.Models.Order.Filters;
using GoogleAPI.Domain.Models.Order.ResponseModel;
using GoogleAPI.Domain.Models.Order.ViewModel;
using GoogleAPI.Domain.Models.Payment.Filter;
using GoogleAPI.Domain.Models.Payment.ViewModel;
using GoogleAPI.Domain.Models.Response;
using GoogleAPI.Persistance.Concreates.Services.IyzcoPayment;
using GooleAPI.Application.Abstractions.IServices.IOrder;
using GooleAPI.Application.Abstractions.IServices.IyzcoPayment;
using GooleAPI.Application.Consts;
using GooleAPI.Application.CustomAttributes;
using GooleAPI.Application.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GoogleAPI.API.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IIyzcoPayment _iyzcoPaymentService;
        public OrdersController(IOrderService orderService, IIyzcoPayment iyzcoPaymentService)
        {
            _orderService = orderService;
            _iyzcoPaymentService = iyzcoPaymentService;
        }

        [HttpGet("get-basket-items/{basketId}")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Orders, ActionType = ActionType.Reading, Definition = "Get Basket Items")]
        public async Task<ActionResult<List<BasketItemList_VM>>> GetBasketItems(int basketId)
        {
            try
            {
                // Call the service method to get basket items
                var basketItems = await _orderService.GetBasketItems(basketId);

                if (basketItems.Count > 0)
                {
                    return Ok(basketItems);
                }
                else
                {
                    return Ok(basketItems);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions here
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("get-order-detail/{basketId}")]
        //[Authorize(AuthenticationSchemes = "Admin")]
        //[AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Orders, ActionType = ActionType.Reading, Definition = "Get Order Detail")]
        public async Task<ActionResult<GetOrderDetail_ResponseModel>> GetOrderDetail(int basketId)
        {
            try
            {
                // Call the service method to get basket items
                GetOrderDetail_ResponseModel basketItems = await _orderService.GetOrderDetail(basketId);

                if (basketItems != null)
                {
                    return Ok(basketItems);
                }
                else
                {
                    return Ok(basketItems);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions here
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("get-orders-of-user/{userId}/{count}")]
        //[Authorize(AuthenticationSchemes = "Admin")]
        //[AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Orders, ActionType = ActionType.Reading, Definition = "Get User Orders")]
        public async Task<ActionResult<List<GetOrderDetail_ResponseModel>>> GetUserOrders(int userId, int count)
        {
            try
            {
                // Call the service method to get basket items
                var models = await _orderService.GetOrdersOfUser(userId, count);

                if (models != null)
                {
                    return Ok(models);
                }
                else
                {
                    return Ok(models);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions here
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

      


        [HttpDelete("delete-basket/{id}")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Orders, ActionType = ActionType.Deleting, Definition = "Delete Basket")]
        public async Task<ActionResult<bool>> DeleteBasket(int id)
        {
            try
            {
                bool result = await _orderService.DeleteBasket(id);
                if (result)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound("Basket not found.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete("delete-basket-item/{id}")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Orders, ActionType = ActionType.Deleting, Definition = "Delete Basket Item")]
        public async Task<ActionResult<bool>> DeleteBasketItem(int id)
        {
            try
            {
                bool result = await _orderService.DeleteBasketItem(id);
                if (result)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound("Basket item not found.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("get-basket/{userId}")]
        //[Authorize(AuthenticationSchemes = "Admin")]
        //[AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Orders, ActionType = ActionType.Reading, Definition = "Get Basket")]
        public async Task<ActionResult> GetBasket(int userId)
        {
            try
            {
                int basketId = await _orderService.GetBasket(userId);
                return Ok(basketId);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("clear-basket-items/{basketId}")]
        //[Authorize(AuthenticationSchemes = "Admin")]
        //[AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Orders, ActionType = ActionType.Reading, Definition = "Clear Basket Items")]
        public async Task<ActionResult> ClearBasketItems(int basketId)
        {
            try
            {
                bool result = await _orderService.ClearBasketItems(basketId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("add-basket/{userId}")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Orders, ActionType = ActionType.Writing, Definition = "Add Basket")]
        public async Task<ActionResult<bool>> AddBasket(int userId)
        {
            try
            {
                var response = await _orderService.AddBasket(userId);
                if (response.State)
                {
                    return Ok(response.State);
                }
                else
                {
                    return BadRequest("Failed to create a basket.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }


        [HttpPost("add-item-to-basket")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Orders, ActionType = ActionType.Writing, Definition = "Add Item To Basket")]
        public async Task<ActionResult<UpdateBasketItemCommandResponse>> AddItemToBasket(List<AddBasketItem_VM> models)
        {
            try
            {
                UpdateBasketItemCommandResponse updateBasketItemCommandResponse = await _orderService.AddItemToBasket(models);

                if (updateBasketItemCommandResponse.State)
                {
                    return Ok(updateBasketItemCommandResponse);
                }
                else
                {
                    return BadRequest("Failed to add basket item.");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions here
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPost("update-basket-item-quantity")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Orders, ActionType = ActionType.Updating, Definition = "Update Basket Item Quantity")]
        public async Task<ActionResult<bool>> UpdateBasketItemQuantity(BasketItem_VM model)
        {
            try
            {
                var response = await _orderService.UpdateBasketItemQuantity(model);
                if (response != null)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest("Failed to update a basket item quantity.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("get-orders")]
        //[Authorize(AuthenticationSchemes = "Admin")]
        //[AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Orders, ActionType = ActionType.Reading, Definition = "GetOrders")]
        public async Task<ActionResult<ResponseModel<OrderList_VM>>> GetOrders(GetOrderListFilterCommandModel model)
        {

            try
            {
                var response = await _orderService.GetOrders(model);
                if (response != null)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest("Failed to get a order.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("create-order")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Orders, ActionType = ActionType.Reading, Definition = "Create Order")]
        public async Task<ActionResult<bool>> CreateOrder(CreateOrderCommandModel model)
        {
            try
            {
                var response = await _orderService.CreateOrder(model);
                if (response != null)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest("Failed to complete a order.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("complete-order/{id}")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Orders, ActionType = ActionType.Writing, Definition = "Complete Order")]
        public async Task<ActionResult<bool>> CompleteOrder(CompleteOrderCommandModel model)
        {
            try
            {
                var response = await _orderService.CompleteOrder(model);
                if (response != null)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest("Failed to complete a order.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }


        [HttpDelete("delete-order/{id}")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Orders, ActionType = ActionType.Deleting, Definition = "Delete Order")]
        public async Task<ActionResult<bool>> DeleteOrder(int id)
        {
            try
            {

                var response = await _orderService.DeleteOrder(id);
                if (response != null)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest("Failed to delete a order.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }


        #region payment

        [HttpPost("get-payments-of-order-list")]
        public async Task<ActionResult<List<PaymentList_VM>>> GetPaymentList(PaymentFilter request)
        {
            List<PaymentList_VM> list = await _orderService.GetPaymentsOfOrderList(request);

            return Ok(list);
        }



        [HttpGet("check-iyzco-payment-status/{conversationId}/{paymentMethodDescription}")]
        public async Task<ActionResult<List<GetOrderDetail_ResponseModel>>> CheckIyzcoPaymentStatus(string conversationId)
        {
            List<GetOrderDetail_ResponseModel> models = new List<GetOrderDetail_ResponseModel>();
            GetOrderDetail_ResponseModel response = await _orderService.CheckIyzcoPaymentStatus(conversationId);
            models.Add(response);   
            return Ok(models);
        }

        [HttpGet("check-other-payment-status/{token}/{status}/{paymentMethodId}/{orderNo}")]
        public async Task<ActionResult<List<GetOrderDetail_ResponseModel>>> CheckOtherPaymentStatus(string token, bool status, int paymentMethodId, Guid orderNo)
        {
            List<GetOrderDetail_ResponseModel> models = new List<GetOrderDetail_ResponseModel>();
            GetOrderDetail_ResponseModel response = await _orderService.CheckOtherPaymentStatus(token, status, paymentMethodId, orderNo);
            models.Add(response);
            return Ok(models);
        }


        [HttpGet("ReturnOk")]
        public  ActionResult ReturnOk ()
        {
            Console.WriteLine("OK");
            return Ok();
        }

        #endregion


        // Add other actions as needed
    }
}
