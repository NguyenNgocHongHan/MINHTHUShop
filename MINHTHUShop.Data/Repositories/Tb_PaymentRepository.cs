using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Model.Models;

namespace MINHTHUShop.Data.Repositories
{
    public interface ITb_PaymentRepository : IRepository<Tb_Payment>
    {
    }

    public class Tb_PaymentRepository : RepositoryBase<Tb_Payment>, ITb_PaymentRepository
    {
        public Tb_PaymentRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}