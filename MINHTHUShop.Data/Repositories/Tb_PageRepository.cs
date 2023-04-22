using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Model.Models;

namespace MINHTHUShop.Data.Repositories
{
    public interface ITb_PageRepository : IRepository<Tb_Page>
    {
    }

    public class Tb_PageRepository : RepositoryBase<Tb_Page>, ITb_PageRepository
    {
        public Tb_PageRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}