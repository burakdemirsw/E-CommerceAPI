using GoogleAPI.Domain.Models.Order.CommandModel;
using GoogleAPI.Domain.Models.Order.Filters;
using GoogleAPI.Domain.Models.Order.ViewModel;
using GooleAPI.Application.Abstractions.IServices.IOrder;
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

        [HttpGet("get-basket-items  /{basketId}")]
        public async Task<ActionResult<List<BasketItemList_VM>>> GetBasketItems(int basketId)
        {
            try
            {
                // Call the service method to get basket items
                var basketItems = await _basketService.GetBasketItems(basketId);

                if (basketItems != null)
                {
                    return Ok(basketItems);
                }
                else
                {
                    return NotFound("Basket not found or empty.");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions here
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpDelete("delete-basket/{id}")]
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


        [HttpPost("add-basket-item")]
        public async Task<ActionResult<bool>> AddBasketItem([FromBody] BasketItem_VM model)
        {
            try
            {
                // Call the service method to add the basket item
                bool isSuccess = await _basketService.AddBasketITem(model);

                if (isSuccess)
                {
                    return Ok(isSuccess);
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
        public async Task<ActionResult<bool>> GetOrders(OrderListFilterCommandModel model)
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
        public async Task<ActionResult<bool>> GetOrder(int id)
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
