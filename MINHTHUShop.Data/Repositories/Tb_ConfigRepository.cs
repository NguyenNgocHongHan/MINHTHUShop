using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Model.Models;

namespace MINHTHUShop.Data.Repositories
{
    public interface ITb_ConfigRepository : IRepository<Tb_Config>
    {
    }

    public class Tb_ConfigRepository : RepositoryBase<Tb_Config>, ITb_ConfigRepository
    {
        public Tb_ConfigRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}