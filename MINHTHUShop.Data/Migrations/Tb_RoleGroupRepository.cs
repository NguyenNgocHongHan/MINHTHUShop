using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Model.Models;

namespace MINHTHUShop.Data.Migrations
{
    public class Tb_RoleGroupRepository : RepositoryBase<Tb_RoleGroup>, ITb_RoleGroupRepository
    {
        public Tb_RoleGroupRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface ITb_RoleGroupRepository : IRepository<Tb_RoleGroup>
    {
    }
}