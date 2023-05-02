using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace MINHTHUShop.Data.Repositories
{
    public interface ITb_RoleRepository : IRepository<Tb_RoleStaff>
    {
        IEnumerable<Tb_Staff> GetListStaffByRoleID(int RoleID); 
    }

    public class Tb_RoleRepository : RepositoryBase<Tb_RoleStaff>, ITb_RoleRepository
    {
        public Tb_RoleRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Tb_Staff> GetListStaffByRoleID(int RoleID)
        {
            var query = from role in DbContext.Tb_Roles
                        join staff in DbContext.Tb_Staffs
                        on role.RoleID equals staff.RoleID
                        where staff.RoleID == RoleID
                        select staff;
            return query;
        }
    }
}