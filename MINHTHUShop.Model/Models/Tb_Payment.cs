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
        public int PaymentMethodID { get; set; }

        public DateTime? PaymentDate { get; set; }

        public decimal? PaymentAmount { get; set; }

        public bool? IsPaid { get; set; } = false;

        [ForeignKey("PaymentMethodID")]
        public virtual Tb_PaymentMethod Tb_PaymentMethod { get; set; }
    }
}