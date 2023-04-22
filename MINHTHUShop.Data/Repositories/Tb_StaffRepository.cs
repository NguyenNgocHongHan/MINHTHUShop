using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Model.Models;

namespace MINHTHUShop.Data.Repositories
{
    public interface ITb_StaffRepository : IRepository<Tb_Staff>
    {
    }

    public class Tb_StaffRepository : RepositoryBase<Tb_Staff>, ITb_StaffRepository
    {
        public Tb_StaffRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}