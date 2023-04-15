using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MINHTHUShop.Model
{
    public class Tb_Config
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ConfigID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public int? ValueNum { get; set; }

        [MaxLength(50)]
        public string ValueString { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public bool? Status { get; set; } = true;
    }
}