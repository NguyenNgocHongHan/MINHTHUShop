using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Model.Models;

namespace MINHTHUShop.Data.Repositories
{
    public interface ITb_FAQCategoryRepository : IRepository<Tb_FAQCategory>
    {
    }

    public class Tb_FAQCategoryRepository : RepositoryBase<Tb_FAQCategory>, ITb_FAQCategoryRepository
    {
        public Tb_FAQCategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}