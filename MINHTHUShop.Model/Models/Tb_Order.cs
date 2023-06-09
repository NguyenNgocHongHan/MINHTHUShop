﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MINHTHUShop.Model.Models
{
    public class Tb_Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }

        [Required]
        public string CustomerID { get; set; }

        [Required]
        public int OrderStatusID { get; set; }

        [Required]
        [MaxLength(50)]
        public string CustomerName { get; set; }

        [Required]
        [MaxLength(250)]
        public string CustomerAddress { get; set; }

        [Required]
        public string CustomerMobile { get; set; }

        [Required]
        public int ShippingMethodID { get; set; }

        [Required]
        public int PaymentMethodID { get; set; }

        [Required]
        public DateTime CreateDate { get; set; } = DateTime.Now;

        [MaxLength(500)]
        public string Note { get; set; }

        [ForeignKey("CustomerID")]
        public virtual Tb_User Customer { get; set; }
        [ForeignKey("OrderStatusID")]
        public virtual Tb_OrderStatus Tb_OrderStatus { get; set; }
        [ForeignKey("ShippingMethodID")]
        public virtual Tb_ShippingMethod Tb_ShippingMethod { get; set; }
        [ForeignKey("PaymentMethodID")]
        public virtual Tb_PaymentMethod Tb_PaymentMethod { get; set; }

        public virtual IEnumerable<Tb_OrderDetail> Tb_OrderDetails { get; set; }
    }
}