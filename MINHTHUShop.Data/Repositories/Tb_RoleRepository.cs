using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace MINHTHUShop.Data.Repositories
{
    public class Tb_RoleRepository : RepositoryBase<Tb_Role>, ITb_RoleRepository
    {
        public Tb_RoleRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Tb_Role> GetListRoleByGroupID(int groupID)
        {
            var query = from g in DbContext.Tb_Roles
                        join ug in DbContext.Tb_RoleGroups
                        on g.Id equals ug.RoleID
                        where ug.GroupID == groupID
                        select g;
            return query;
        }
    }

    public interface ITb_RoleRepository : IRepository<Tb_Role>
    {
        IEnumerable<Tb_Role> GetListRoleByGroupID(int groupID);
    }
}