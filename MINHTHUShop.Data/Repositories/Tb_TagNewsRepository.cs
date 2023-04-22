using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Model.Models;

namespace MINHTHUShop.Data.Repositories
{
    public interface ITb_TagNewsRepository : IRepository<Tb_TagNews>
    {
    }

    public class Tb_TagNewsRepository : RepositoryBase<Tb_TagNews>, ITb_TagNewsRepository
    {
        public Tb_TagNewsRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}