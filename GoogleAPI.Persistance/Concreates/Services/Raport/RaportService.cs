using GoogleAPI.Domain.Entities;
using GoogleAPI.Domain.Models.Raport;
using GoogleAPI.Persistance.Contexts;
using GooleAPI.Application.IRepositories.Raport;
using System.Globalization;

namespace GoogleAPI.Persistance.Concreates.Services.Raport
{
    public class RaportService : IRaportService
    {
        private readonly GooleAPIDbContext _context;
        public RaportService(GooleAPIDbContext context)
        {
            _context = context;

        }

        public async Task<OrderSaleRaportByTime_Response> GetOrderSaleRaportByTime(string type)
        {
            //types ; 
            //week: 1 , month :2 ,year : 3
            if (type == "week")
            {
                DateTime endDate = DateTime.Now;
                DateTime startDate = endDate.AddDays(-7);

                List<OrderRaportByTime> reports = new List<OrderRaportByTime>();

                while (startDate < endDate)
                {
                    List<Domain.Entities.Order> ordersInPeriod = _context.Orders
                        .Where(o => o.CreatedDate >= startDate && o.CreatedDate < startDate.AddDays(1))
                        .ToList();

                    decimal totalEarningsInPeriod = 0;

                    foreach (var order in ordersInPeriod)
                    {
                        totalEarningsInPeriod += CalculateTotalEarningOfOrder(order);
                    }

                    string dayNameInTurkish = startDate.ToString("dddd", new CultureInfo("tr-TR"));

                    OrderRaportByTime report = new OrderRaportByTime
                    {
                        Time = dayNameInTurkish, // Türkçe gün adını yazdırır
                        Count = ordersInPeriod.Count,
                        TotalEarnings = totalEarningsInPeriod
                    };

                    reports.Add(report);

                    startDate = startDate.AddDays(1);
                }

                OrderSaleRaportByTime_Response model = new OrderSaleRaportByTime_Response();
                model.Time = new List<string>();
                model.Count = new List<int>();
                foreach (var order in reports)
                {
                    model.Time.Add(order.Time);
                    model.Count.Add(order.Count);

                }

                return model;


                //return reports;
            }
            else if (type == "month")
            {
                DateTime endDate = DateTime.Now;
                DateTime startDate = endDate.AddMonths(-6); // 6 ay önce

                List<OrderRaportByTime> reports = new List<OrderRaportByTime>();

                while (startDate <= endDate)
                {
                    List<Domain.Entities.Order> ordersInPeriod = _context.Orders
                        .Where(o => o.CreatedDate >= startDate && o.CreatedDate <= startDate.AddMonths(1).AddDays(-1))
                        .ToList();

                    decimal totalEarningsInPeriod = 0;

                    foreach (var order in ordersInPeriod)
                    {
                        totalEarningsInPeriod += CalculateTotalEarningOfOrder(order);
                    }

                    string monthNameInTurkish = startDate.ToString("MMMM", new CultureInfo("tr-TR"));

                    OrderRaportByTime report = new OrderRaportByTime
                    {
                        Time = monthNameInTurkish, // Türkçe ay adını yazdırır
                        Count = ordersInPeriod.Count,
                        TotalEarnings = totalEarningsInPeriod
                    };

                    reports.Add(report);

                    startDate = startDate.AddMonths(1);
                }

                OrderSaleRaportByTime_Response model = new OrderSaleRaportByTime_Response();
                model.Time = new List<string>();
                model.Count = new List<int>();
                foreach (var order in reports)
                {
                    model.Time.Add(order.Time);
                    model.Count.Add(order.Count);

                }

                return model;
            }

            return null; // Diğer durumlar için gerekli işlemleri ekleyebilirsiniz.
        }

        public async Task<OrderEarningRaportByTime_Response> GetOrderEarningRaportByTime(string type)
        {
            //types ; 
            //week: 1 , month :2 ,year : 3
            if (type == "week")
            {
                DateTime endDate = DateTime.Now;
                DateTime startDate = endDate.AddDays(-7);

                List<OrderRaportByTime> reports = new List<OrderRaportByTime>();

                while (startDate < endDate)
                {
                    List<Domain.Entities.Order> ordersInPeriod = _context.Orders
                        .Where(o => o.CreatedDate >= startDate && o.CreatedDate < startDate.AddDays(1))
                        .ToList();

                    decimal totalEarningsInPeriod = 0;

                    foreach (var order in ordersInPeriod)
                    {
                        totalEarningsInPeriod += CalculateTotalEarningOfOrder(order);
                    }

                    string dayNameInTurkish = startDate.ToString("dddd", new CultureInfo("tr-TR"));

                    OrderRaportByTime report = new OrderRaportByTime
                    {
                        Time = dayNameInTurkish, // Türkçe gün adını yazdırır
                        Count = ordersInPeriod.Count,
                        TotalEarnings = totalEarningsInPeriod
                    };

                    reports.Add(report);

                    startDate = startDate.AddDays(1);
                }

                OrderEarningRaportByTime_Response model = new OrderEarningRaportByTime_Response();
                model.Time = new List<string>();
                model.Earnings = new List<decimal>();
                foreach (var order in reports)
                {
                    model.Time.Add(order.Time);
                    model.Earnings.Add(order.TotalEarnings);

                }

                return model;


                //return reports;
            }
            else if (type == "month")
            {
                DateTime endDate = DateTime.Now;
                DateTime startDate = endDate.AddMonths(-6); // 6 ay önce

                List<OrderRaportByTime> reports = new List<OrderRaportByTime>();

                while (startDate <= endDate)
                {
                    List<Domain.Entities.Order> ordersInPeriod = _context.Orders
                        .Where(o => o.CreatedDate >= startDate && o.CreatedDate <= startDate.AddMonths(1).AddDays(-1))
                        .ToList();

                    decimal totalEarningsInPeriod = 0;

                    foreach (var order in ordersInPeriod)
                    {
                        totalEarningsInPeriod += CalculateTotalEarningOfOrder(order);
                    }

                    string monthNameInTurkish = startDate.ToString("MMMM", new CultureInfo("tr-TR"));

                    OrderRaportByTime report = new OrderRaportByTime
                    {
                        Time = monthNameInTurkish, // Türkçe ay adını yazdırır
                        Count = ordersInPeriod.Count,
                        TotalEarnings = totalEarningsInPeriod
                    };

                    reports.Add(report);

                    startDate = startDate.AddMonths(1);
                }
                OrderEarningRaportByTime_Response model = new OrderEarningRaportByTime_Response();
                model.Time = new List<string>();
                model.Earnings = new List<decimal>();
                foreach (var order in reports)
                {
                    model.Time.Add(order.Time);
                    model.Earnings.Add(order.TotalEarnings);

                }

                return model;
            }

            return null; // Diğer durumlar için gerekli işlemleri ekleyebilirsiniz.
        }
        public async Task<OrderSaleRaportByTime_Response> TransformRaportForClient(List<OrderRaportByTime> raportList)
        {
            OrderSaleRaportByTime_Response model = new OrderSaleRaportByTime_Response();

            foreach (var order in raportList)
            {
                model.Time.Add(order.Time);
                model.Count.Add(order.Count);

            }

            return model;
        }

        public decimal CalculateTotalEarningOfOrder(Domain.Entities.Order order)
        {
            decimal totalEarningOfOrder = 0;
            List<BasketItem> basketItems = _context.BasketItems.Where(b => b.BasketId == order.BasketId).ToList();

            foreach (var item in basketItems)
            {
                totalEarningOfOrder += _context.Products.FirstOrDefault(p => p.Id == item.ProductId)?.NormalPrice ?? 0;
            }

            return totalEarningOfOrder;
        }

        public async Task<List<OrderRaportByTime>> GetOrderSaleCountByTimesRaport( )
        {
            DateTime currentDate = DateTime.Now;
            List<OrderRaportByTime> reports = new List<OrderRaportByTime>();

            // Aylık satış adedi raporu
            DateTime firstDayOfMonth = new DateTime(currentDate.Year, currentDate.Month, 1);
            DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            int monthlyOrderCount = _context.Orders.Count(o => o.CreatedDate >= firstDayOfMonth && o.CreatedDate <= lastDayOfMonth);

            reports.Add(new OrderRaportByTime
            {
                Time = "Aylık",
                Count = monthlyOrderCount
            });

            // Haftalık satış adedi raporu
            DateTime firstDayOfWeek = currentDate.Date.AddDays(-(int)currentDate.DayOfWeek); // Bu haftanın başlangıcı
            DateTime lastDayOfWeek = firstDayOfWeek.AddDays(6); // Bu haftanın sonu
            int weeklyOrderCount = _context.Orders.Count(o => o.CreatedDate >= firstDayOfWeek && o.CreatedDate <= lastDayOfWeek);

            reports.Add(new OrderRaportByTime
            {
                Time = "Haftalık",
                Count = weeklyOrderCount
            });

            // Günlük satış adedi raporu
            DateTime today = currentDate.Date;
            int dailyOrderCount = _context.Orders.Count(o => o.CreatedDate >= today && o.CreatedDate <= today.AddDays(1));

            reports.Add(new OrderRaportByTime
            {
                Time = "Günlük",
                Count = dailyOrderCount
            });

            return reports;
        }

    }
}
