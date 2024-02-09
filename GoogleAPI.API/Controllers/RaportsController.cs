using GoogleAPI.Domain.Models.Raport;
using GooleAPI.Application.IRepositories.Raport;
using Microsoft.AspNetCore.Mvc;

namespace GoogleAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaportsController : ControllerBase
    {
        readonly IRaportService _raportService;

        public RaportsController(
            IRaportService raportService)
        {

            _raportService = raportService;
        }

        [HttpGet("get-order-sale-raport/{type}")]
        public async Task<ActionResult<List<OrderSaleRaportByTime_Response>>> GetOrderSaleRaport(string type)
        {

            try
            {
                List<OrderSaleRaportByTime_Response> list = new List<OrderSaleRaportByTime_Response>();
                var response = await _raportService.GetOrderSaleRaportByTime(type);
                list.Add(response);
                return Ok(list);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message + ex.StackTrace);
            }

        }

        [HttpGet("get-order-earning-raport/{type}")]
        public async Task<ActionResult<List<OrderEarningRaportByTime_Response>>> GetOrderEarningRaport(string type)
        {
            try
            {
                List<OrderEarningRaportByTime_Response> list = new List<OrderEarningRaportByTime_Response>();
                var response = await _raportService.GetOrderEarningRaportByTime(type);
                list.Add(response);
                return Ok(list);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message + ex.StackTrace);
            }
        }

        [HttpGet("get-order-sale-count-by-times")]
        public async Task<ActionResult<List<OrderRaportByTime>>> GetOrderSaleCountByTimesRaport( )
        {
            try
            {
                var response = await _raportService.GetOrderSaleCountByTimesRaport();

                return Ok(response);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message + ex.StackTrace);
            }
        }
    }
}
