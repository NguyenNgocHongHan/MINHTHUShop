using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Model.Models;

namespace MINHTHUShop.Data.Repositories
{
    public interface ITb_ShippingMethodRepository : IRepository<Tb_ShippingMethod>
    {
    }

    public class Tb_ShippingMethodRepository : RepositoryBase<Tb_ShippingMethod>, ITb_ShippingMethodRepository
    {
        public Tb_ShippingMethodRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}