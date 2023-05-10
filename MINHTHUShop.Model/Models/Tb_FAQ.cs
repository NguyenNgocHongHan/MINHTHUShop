﻿using MINHTHUShop.Model.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MINHTHUShop.Model.Models
{
    public class Tb_FAQ
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FAQID { get; set; }

        [Required]
        public int FAQCateID { get; set; }

        [Required]
        [MaxLength(250)]
        public string Question { get; set; }

        [Required]
        public string Answer { get; set; }

        public bool? Status { get; set; }

        [ForeignKey("FAQCateID")]
        public virtual Tb_FAQCategory Tb_FAQCategory { get; set; }
    }
}