using MINHTHUShop.Model.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MINHTHUShop.Model.Models
{
    public class Tb_NewsCategory : SEO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NewsCateID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public int? Sort { get; set; }

        public int? ParentID { get; set; }

        public virtual IEnumerable<Tb_News> Tb_News { get; set; }
    }
}