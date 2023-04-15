using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MINHTHUShop.Model.Models
{
    public class Tb_FAQCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FAQCateID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public int? Sort { get; set; }

        public int? ParentID { get; set; }

        public virtual IEnumerable<Tb_FAQ> Tb_FAQs { get; set; }
    }
}