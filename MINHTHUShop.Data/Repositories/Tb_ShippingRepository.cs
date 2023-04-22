using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Model.Models;

namespace MINHTHUShop.Data.Repositories
{
    public interface ITb_ShippingRepository : IRepository<Tb_Shipping>
    {
    }

    public class Tb_ShippingRepository : RepositoryBase<Tb_Shipping>, ITb_ShippingRepository
    {
        public Tb_ShippingRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}