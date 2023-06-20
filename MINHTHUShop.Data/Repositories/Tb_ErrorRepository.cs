using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Model.Models;

namespace MINHTHUShop.Data.Repositories
{
    public interface ITb_ErrorRepository : IRepository<Tb_Error>
    {
    }

    public class Tb_ErrorRepository : RepositoryBase<Tb_Error>, ITb_ErrorRepository
    {
        public Tb_ErrorRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}