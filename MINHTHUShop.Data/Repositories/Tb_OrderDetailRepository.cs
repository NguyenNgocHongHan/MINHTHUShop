using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Model.Models;

namespace MINHTHUShop.Data.Repositories
{
    public interface ITb_OrderDetailRepository : IRepository<Tb_OrderDetail>
    {
    }

    public class Tb_OrderDetailRepository : RepositoryBase<Tb_OrderDetail>, ITb_OrderDetailRepository
    {
        public Tb_OrderDetailRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}