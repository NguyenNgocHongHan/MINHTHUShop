using MINHTHUShop.Common;
using MINHTHUShop.Data.Repositories;
using System.Collections.Generic;

namespace MINHTHUShop.Service
{
    public interface IStatisticService
    {
        IEnumerable<RevenueStatisticsVM> GetRevenueStatistics(string fromDate, string toDate);
    }

    public class StatisticService : IStatisticService
    {
        private ITb_OrderRepository _orderRepository;

        public StatisticService(ITb_OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IEnumerable<RevenueStatisticsVM> GetRevenueStatistics(string fromDate, string toDate)
        {
            return _orderRepository.GetRevenueStatistics(fromDate, toDate);
        }
    }
}