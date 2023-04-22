using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Model.Models;

namespace MINHTHUShop.Data.Repositories
{
    public interface ITb_ProductCategoryRepository : IRepository<Tb_ProductCategory>
    {
    }

    public class Tb_ProductCategoryRepository : RepositoryBase<Tb_ProductCategory>, ITb_ProductCategoryRepository
    {
        public Tb_ProductCategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}