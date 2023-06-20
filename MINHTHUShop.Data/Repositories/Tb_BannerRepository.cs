using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Model.Models;

namespace MINHTHUShop.Data.Repositories
{
    public interface ITb_BannerRepository : IRepository<Tb_Banner>
    {
    }

    public class Tb_BannerRepository : RepositoryBase<Tb_Banner>, ITb_BannerRepository
    {
        public Tb_BannerRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}