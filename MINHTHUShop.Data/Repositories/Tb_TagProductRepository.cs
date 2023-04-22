using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Model.Models;

namespace MINHTHUShop.Data.Repositories
{
    public interface ITb_TagProductRepository : IRepository<Tb_TagProduct>
    {
    }

    public class Tb_TagProductRepository : RepositoryBase<Tb_TagProduct>, ITb_TagProductRepository
    {
        public Tb_TagProductRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}