using System;

namespace MINHTHUShop.Common
{
    public class RevenueStatisticsVM
    {
        public DateTime Date { set; get; }
        public decimal Revenues { set; get; } //Doanh thu
        public decimal Benefit { set; get; } //Lợi nhuận
    }
}