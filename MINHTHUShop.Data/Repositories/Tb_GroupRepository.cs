using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace MINHTHUShop.Data.Repositories
{
    public class Tb_GroupRepository : RepositoryBase<Tb_Group>, ITb_GroupRepository
    {
        public Tb_GroupRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Tb_Group> GetListGroupByUserID(string userID)
        {
            var query = from g in DbContext.Tb_Groups
                        join ug in DbContext.Tb_UserGroups
                        on g.GroupID equals ug.GroupID
                        where ug.UserID == userID
                        select g;
            return query;
        }

        public IEnumerable<Tb_User> GetListUserByGroupID(int groupID)
        {
            var query = from g in DbContext.Tb_Groups
                        join ug in DbContext.Tb_UserGroups
                        on g.GroupID equals ug.GroupID
                        join u in DbContext.Users
                        on ug.UserID equals u.Id
                        where ug.GroupID == groupID
                        select u;
            return query;
        }
    }

    public interface ITb_GroupRepository : IRepository<Tb_Group>
    {
        IEnumerable<Tb_Group> GetListGroupByUserID(string userID);
        IEnumerable<Tb_User> GetListUserByGroupID(int groupID);
    }
}