﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MINHTHUShop.Model.Models
{
    public class Tb_Shipping
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ShippingID { get; set; }

        [Required]
        public int ShippingMethodID { get; set; }

        public DateTime? ShippingDate { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool? IsShipping { get; set; } = false;

        [ForeignKey("ShippingMethodID")]
        public virtual Tb_ShippingMethod Tb_ShippingMethod { get; set; }
    }
}