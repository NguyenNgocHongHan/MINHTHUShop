using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Model.Models;

namespace MINHTHUShop.Data.Repositories
{
    public interface ITb_NewsCategoryRepository : IRepository<Tb_NewsCategory>
    {
    }

    public class Tb_NewsCategoryRepository : RepositoryBase<Tb_NewsCategory>, ITb_NewsCategoryRepository
    {
        public Tb_NewsCategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}