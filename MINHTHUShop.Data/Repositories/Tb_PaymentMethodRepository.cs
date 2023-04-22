using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Model.Models;

namespace MINHTHUShop.Data.Repositories
{
    public interface ITb_PaymentMethodRepository : IRepository<Tb_PaymentMethod>
    {
    }

    public class Tb_PaymentMethodRepository : RepositoryBase<Tb_PaymentMethod>, ITb_PaymentMethodRepository
    {
        public Tb_PaymentMethodRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}