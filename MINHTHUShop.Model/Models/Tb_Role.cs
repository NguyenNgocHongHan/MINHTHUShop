using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MINHTHUShop.Model.Models
{
    //quản lý quyền truy cập
    public class Tb_Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        /*public Tb_ApplicationRole() : base()
        {
        }*/

        [MaxLength(250)]
        public string Description { get; set; }
    }
}