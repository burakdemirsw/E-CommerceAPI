using GoogleAPI.Domain.Models.Category.CommandModel;
using GoogleAPI.Domain.Models.Order.CommandModel;
using GoogleAPI.Domain.Models.Order.Filters;
using GoogleAPI.Domain.Models.Order.ViewModel;
using GoogleAPI.Domain.Models.Response;
using GooleAPI.Application.Abstractions.IServices.IOrder;
using GooleAPI.Application.Consts;
using GooleAPI.Application.CustomAttributes;
using GooleAPI.Application.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoogleAPI.API.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _basketService;

        public OrdersController(IOrderService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet("get-basket-items/{basketId}")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Orders, ActionType = ActionType.Reading, Definition = "Get Basket Items")]
        public async Task<ActionResult<List<BasketItemList_VM>>> GetBasketItems(int basketId)
        {
            try
            {
                // Call the service method to get basket items
                var basketItems = await _basketService.GetBasketItems(basketId);

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


        [HttpDelete("delete-basket/{id}")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Orders, ActionType = ActionType.Deleting, Definition = "Delete Basket")]
        public async Task<ActionResult<bool>> DeleteBasket(int id)
        {
            try
            {
                bool result = await _basketService.DeleteBasket(id);
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
                bool result = await _basketService.DeleteBasketItem(id);
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
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Orders, ActionType = ActionType.Reading, Definition = "Get Basket")]
        public async Task<ActionResult> GetBasket(int userId)
        {
            try
            {
                int basketId = await _basketService.GetBasket(userId);
                return Ok(basketId);
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
                var response = await _basketService.AddBasket(userId);
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
        public async Task<ActionResult<UpdateBasketItemCommandResponse>> AddItemToBasket([FromBody] AddBasketItem_VM model)
        {
            try
            {
                // Call the service method to add the basket item
                UpdateBasketItemCommandResponse updateBasketItemCommandResponse = await _basketService.AddItemToBasket(model);

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
                var response = await _basketService.UpdateBasketItemQuantity(model);
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
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Orders, ActionType = ActionType.Reading, Definition = "GetOrders")]
        public async Task<ActionResult<ResponseModel<OrderList_VM>>> GetOrders(GetOrderListFilterCommandModel model)
        {
           
            try
            {
                var response = await _basketService.GetOrders(model);
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
                var response = await _basketService.CreateOrder(model);
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
                var response = await _basketService.CompleteOrder(model);
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

                var response = await _basketService.DeleteOrder(id);
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





        // Add other actions as needed
    }
}
