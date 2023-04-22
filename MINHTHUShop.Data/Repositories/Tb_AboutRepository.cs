using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Model.Models;

namespace MINHTHUShop.Data.Repositories
{
    public interface ITb_AboutRepository : IRepository<Tb_About>
    {
    }

    public class Tb_AboutRepository : RepositoryBase<Tb_About>, ITb_AboutRepository
    {
        public Tb_AboutRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}