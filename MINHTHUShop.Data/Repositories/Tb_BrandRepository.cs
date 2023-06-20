using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Model.Models;

namespace MINHTHUShop.Data.Repositories
{
    public interface ITb_BrandRepository : IRepository<Tb_Brand>
    {
    }

    public class Tb_BrandRepository : RepositoryBase<Tb_Brand>, ITb_BrandRepository
    {
        public Tb_BrandRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}