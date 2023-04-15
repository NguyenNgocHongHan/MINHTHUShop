using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MINHTHUShop.Model.Models
{
    public class Tb_Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentID { get; set; }

        [Required]
        public int OrderID { get; set; }

        [Required]
        public int CustomerID { get; set; }

        [Required]
        public int PaymentMethodID { get; set; }

        public DateTime? PaymentDate { get; set; }

        [Column(TypeName = "decimal(12, 0)")]
        public decimal? PaymentAmount { get; set; }

        public bool? IsPaid { get; set; } = false;

        [ForeignKey("OrderID")]
        public virtual Tb_Order Tb_Order { get; set; }

        [ForeignKey("CustomerID")]
        public virtual Tb_Customer Tb_Customer { get; set; }

        [ForeignKey("PaymentMethodID")]
        public virtual Tb_PaymentMethod Tb_PaymentMethod { get; set; }
    }
}