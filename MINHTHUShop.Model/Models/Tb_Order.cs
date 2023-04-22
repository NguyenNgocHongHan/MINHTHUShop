using System;
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
        public int CustomerID { get; set; }

        [Required]
        public int StaffID { get; set; }

        [Required]
        public int OrderStatusID { get; set; }

        [Required]
        public int ShippingMethodID { get; set; }

        [Required]
        public int PaymentMethodID { get; set; }

        public decimal? Total { get; set; }

        public DateTime? CreateDate { get; set; } = DateTime.Now;

        public string Note { get; set; }

        public bool? IsCancel { get; set; } = false;

        [ForeignKey("CustomerID")]
        public virtual Tb_Customer Tb_Customer { get; set; }
        [ForeignKey("StaffID")]
        public virtual Tb_Staff Tb_Staff { get; set; }
        [ForeignKey("OrderStatusID")]
        public virtual Tb_OrderStatus Tb_OrderStatus { get; set; }
        [ForeignKey("ShippingMethodID")]
        public virtual Tb_ShippingMethod Tb_ShippingMethod { get; set; }
        [ForeignKey("PaymentMethodID")]
        public virtual Tb_PaymentMethod Tb_PaymentMethod { get; set; }

        public virtual IEnumerable<Tb_OrderDetail> Tb_OrderDetails { get; set; }
    }
}