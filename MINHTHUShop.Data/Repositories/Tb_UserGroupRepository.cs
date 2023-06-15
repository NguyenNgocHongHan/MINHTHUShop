using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MINHTHUShop.Data.Repositories
{
    public class Tb_UserGroupRepository : RepositoryBase<Tb_UserGroup>, ITb_UserGroupRepository
    {
        public Tb_UserGroupRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface ITb_UserGroupRepository : IRepository<Tb_UserGroup>
    {
    }
}
