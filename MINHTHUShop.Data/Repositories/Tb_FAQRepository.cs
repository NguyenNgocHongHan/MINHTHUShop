using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Model.Models;

namespace MINHTHUShop.Data.Repositories
{
    public interface ITb_FAQRepository : IRepository<Tb_FAQ>
    {
    }

    public class Tb_FAQRepository : RepositoryBase<Tb_FAQ>, ITb_FAQRepository
    {
        public Tb_FAQRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}