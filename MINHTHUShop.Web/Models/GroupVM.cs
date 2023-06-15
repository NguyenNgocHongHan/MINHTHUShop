using System.Collections.Generic;

namespace MINHTHUShop.Web.Models
{
    public class GroupVM
    {
        public int GroupID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<RoleVM> RoleVMs { set; get; }
    }
}