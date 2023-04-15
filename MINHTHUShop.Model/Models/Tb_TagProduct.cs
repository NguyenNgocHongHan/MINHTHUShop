using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MINHTHUShop.Model.Models
{
    public class Tb_TagProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TagProductID { get; set; }

        [Required]
        public int TagID { get; set; }

        [Required]
        public int ProductID { get; set; }

        [ForeignKey("TagID")]
        public virtual Tb_Tag Tb_Tag { get; set; }
        [ForeignKey("ProductID")]
        public virtual Tb_Product Tb_Product { get; set; }
    }
}