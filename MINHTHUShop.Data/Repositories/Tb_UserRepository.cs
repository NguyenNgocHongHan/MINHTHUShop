using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Model.Models;

namespace MINHTHUShop.Data.Repositories
{
    public interface ITb_UserRepository : IRepository<Tb_User>
    {
    }

    public class Tb_UserRepository : RepositoryBase<Tb_User>, ITb_UserRepository
    {
        public Tb_UserRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}