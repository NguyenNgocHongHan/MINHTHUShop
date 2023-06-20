using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Model.Models;

namespace MINHTHUShop.Data.Repositories
{
    public interface ITb_TargetRepository : IRepository<Tb_Target>
    {
    }

    public class Tb_TargetRepository : RepositoryBase<Tb_Target>, ITb_TargetRepository
    {
        public Tb_TargetRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}