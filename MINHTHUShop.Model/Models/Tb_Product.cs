using MINHTHUShop.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MINHTHUShop.Model.Models
{
    public class Tb_Product : SEO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductID { get; set; }

        [Required]
        public int CateID { get; set; }

        [Required]
        public int BrandID { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Image { get; set; }

        public string ListImg { get; set; }

        [Required]
        public decimal OriginalPrice { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public decimal PromotionPrice { get; set; }

        public string Description { get; set; }

        public string Detail { get; set; }

        [MaxLength(500)]
        public string Tag { get; set; }

        [Required]
        public DateTime CreateDate { get; set; } = DateTime.Now;

        [Required]
        [DefaultValue(true)]
        public bool Status { get; set; }

        [ForeignKey("CateID")]
        public virtual Tb_ProductCategory Tb_ProductCategory { get; set; }
        [ForeignKey("BrandID")]
        public virtual Tb_Brand Tb_Brand { get; set; }

        public virtual IEnumerable<Tb_TagProduct> Tb_TagProducts { get; set; }
    }
}