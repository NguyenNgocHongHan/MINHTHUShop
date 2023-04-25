﻿using MINHTHUShop.Model.Abstract;
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
        public decimal Price { get; set; }

        public decimal? PromotionPrice { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public string Detail { get; set; }

        public DateTime? CreateDate { get; set; } = DateTime.Now;

        [DefaultValue(true)]
        public bool? Status { get; set; }

        [ForeignKey("CateID")]
        public virtual Tb_ProductCategory Tb_ProductCategory { get; set; }
        [ForeignKey("BrandID")]
        public virtual Tb_Brand Tb_Brand { get; set; }

        public virtual IEnumerable<Tb_TagProduct> Tb_TagProducts { get; set; }
        public virtual IEnumerable<Tb_ProductComment> Tb_ProductComments { get; set; }
    }
}