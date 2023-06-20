using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Model.Models;

namespace MINHTHUShop.Data.Repositories
{
    public interface ITb_MenuRepository : IRepository<Tb_Menu>
    {
    }

    public class Tb_MenuRepository : RepositoryBase<Tb_Menu>, ITb_MenuRepository
    {
        public Tb_MenuRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}