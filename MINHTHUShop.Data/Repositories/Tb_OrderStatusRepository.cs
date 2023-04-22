using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Model.Models;

namespace MINHTHUShop.Data.Repositories
{
    public interface ITb_OrderStatusRepository : IRepository<Tb_OrderStatus>
    {
    }

    public class Tb_OrderStatusRepository : RepositoryBase<Tb_OrderStatus>, ITb_OrderStatusRepository
    {
        public Tb_OrderStatusRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}