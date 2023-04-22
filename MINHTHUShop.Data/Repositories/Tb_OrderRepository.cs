using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Model.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MINHTHUShop.Data.Repositories
{
    public interface ITb_OrderRepository : IRepository<Tb_Order>
    {
        /*IEnumerable<RevenueStatisticViewModel> GetRevenueStatistic(string fromDate, string toDate);*/
    }

    public class Tb_OrderRepository : RepositoryBase<Tb_Order>, ITb_OrderRepository
    {
        public Tb_OrderRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        /*public IEnumerable<RevenueStatisticViewModel> GetRevenueStatistic(string fromDate, string toDate)
        {
            var parameters = new SqlParameter[]{
                new SqlParameter("@fromDate",fromDate),
                new SqlParameter("@toDate",toDate)
            };
            return DbContext.Database.SqlQuery<RevenueStatisticViewModel>("GetRevenueStatistic @fromDate,@toDate", parameters);
        }*/
    }
}