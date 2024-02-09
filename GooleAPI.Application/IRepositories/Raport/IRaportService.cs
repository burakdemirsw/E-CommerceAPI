using GoogleAPI.Domain.Entities;
using GoogleAPI.Domain.Models.Raport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooleAPI.Application.IRepositories.Raport
{
    public  interface IRaportService
    {
        Task<OrderSaleRaportByTime_Response> GetOrderSaleRaportByTime(string type);
        Task<List<OrderRaportByTime>> GetOrderSaleCountByTimesRaport( );

        Task<OrderEarningRaportByTime_Response> GetOrderEarningRaportByTime(string type);

        Task<OrderSaleRaportByTime_Response> TransformRaportForClient(List<OrderRaportByTime> raportList);
        public decimal CalculateTotalEarningOfOrder(Order order);
    }
    //public class OrderSaleRaportByTime_Response
    //{
    //    public List<string> Time {  get; set; }
    //    public List<int> Count { get; set; }    
    //}

    //public class OrderEarningRaportByTime_Response
    //{
    //    public List<string> Time { get; set; }
    //    public List<decimal> Earnings { get; set; }
    //}

    //public class OrderRaportByTime
    //{
    //    public string Time { get; set; }
    //    public int Count { get; set; }

    //    public decimal TotalEarnings { get; set; }  
    //}


}
