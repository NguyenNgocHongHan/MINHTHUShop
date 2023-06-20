using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Model.Models;

namespace MINHTHUShop.Data.Repositories
{
    public interface ITb_MenuGroupRepository : IRepository<Tb_MenuGroup>
    {
    }

    public class Tb_MenuGroupRepository : RepositoryBase<Tb_MenuGroup>, ITb_MenuGroupRepository
    {
        public Tb_MenuGroupRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}