using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MINHTHUShop.Model.Models
{
    public class Tb_UserGroup
    {
        [Key]
        [Column(Order = 1)]
        [StringLength(128)]
        public string UserID { get; set; }

        [Key]
        [Column(Order = 2)]
        public int GroupID { get; set; }

        [ForeignKey("UserID")]
        public virtual Tb_User Tb_User { get; set; }

        [ForeignKey("GroupID")]
        public virtual Tb_Group Tb_Group { get; set; }
    }
}
