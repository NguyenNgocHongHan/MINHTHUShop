using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MINHTHUShop.Model.Models
{
    public class Tb_ProductCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CateID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public int? Sort { get; set; }

        public int? ParentID { get; set; }

        public virtual IEnumerable<Tb_Product> Tb_Products { get; set; }
    }
}