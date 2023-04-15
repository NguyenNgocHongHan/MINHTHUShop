using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MINHTHUShop.Model.Models
{
    public class Tb_MenuGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MenuGroup { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public int? Sort { get; set; }

        public virtual IEnumerable<Tb_Menu> Tb_Menus { get; set; }
    }
}