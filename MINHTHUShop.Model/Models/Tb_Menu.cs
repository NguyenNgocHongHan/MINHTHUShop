using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MINHTHUShop.Model.Models
{
    public class Tb_Menu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MenuID { get; set; }

        [Required]
        public int MenuGroupID { get; set; }

        [Required]
        public int TargetID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Icon { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

        [Required]
        [MaxLength(250)]
        public string Link { get; set; }

        public int? Sort { get; set; }
        
        public bool? Status { get; set; } = true;

        [ForeignKey("MenuGroupID")]
        public virtual Tb_MenuGroup Tb_MenuGroup { get; set; }
        [ForeignKey("TargetID")]
        public virtual Tb_Target Tb_Target { get; set; }
    }
}