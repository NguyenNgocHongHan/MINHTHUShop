using MINHTHUShop.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MINHTHUShop.Model.Models
{
    public class Tb_News : SEO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NewsID { get; set; }

        [Required]
        public int NewsCateID { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Image { get; set; }

        [Required]
        public string Description { get; set; }

        [MaxLength(500)]
        public string Tag { get; set; }

        [Required]
        public DateTime CreateDate { get; set; } = DateTime.Now;

        [Required]
        public bool Status { get; set; } = true;

        [ForeignKey("NewsCateID")]
        public virtual Tb_NewsCategory Tb_NewsCategory { get; set; }

        public virtual IEnumerable<Tb_TagNews> Tb_TagNews { get; set; }
    }
}