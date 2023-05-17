using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Model.Models;

namespace MINHTHUShop.Data.Repositories
{
    public interface ITb_FooterRepository : IRepository<Tb_Footer>
    {
    }

    public class Tb_FooterRepository : RepositoryBase<Tb_Footer>, ITb_FooterRepository
    {
        public Tb_FooterRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}