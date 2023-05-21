using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Model.Models;

namespace MINHTHUShop.Data.Repositories
{
    public interface ITb_WebpageRepository : IRepository<Tb_Webpage>
    {
    }

    public class Tb_WebpageRepository : RepositoryBase<Tb_Webpage>, ITb_WebpageRepository
    {
        public Tb_WebpageRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}