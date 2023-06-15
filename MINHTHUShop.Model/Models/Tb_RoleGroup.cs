using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MINHTHUShop.Model.Models
{
    public class Tb_RoleGroup
    {
        [Key]
        [Column(Order = 1)]
        [StringLength(128)]
        public string RoleID { get; set; }

        [Key]
        [Column(Order = 2)]
        public int GroupID { get; set; }

        [ForeignKey("RoleID")]
        public virtual Tb_Role Tb_Role { get; set; }

        [ForeignKey("GroupID")]
        public virtual Tb_Group Tb_Group { get; set; }
    }
}