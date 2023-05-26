using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Model.Models;
using System.Threading.Tasks;

namespace MINHTHUShop.Data.Repositories
{
    public interface ITb_CustomerRepository : IRepository<Tb_Customer>
    {
    }

    public class Tb_CustomerRepository : RepositoryBase<Tb_Customer>, ITb_CustomerRepository
    {
        public Tb_CustomerRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}