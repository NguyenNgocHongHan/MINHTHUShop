using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Model.Models;

namespace MINHTHUShop.Data.Repositories
{
    public interface ITb_TagRepository : IRepository<Tb_Tag>
    {
    }

    public class Tb_TagRepository : RepositoryBase<Tb_Tag>, ITb_TagRepository
    {
        public Tb_TagRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}