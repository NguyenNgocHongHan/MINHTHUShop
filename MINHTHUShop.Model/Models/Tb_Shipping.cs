using System;
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
        public int OrderID { get; set; }

        public DateTime? ShippingDate { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool? IsShipping { get; set; } = false;

        [ForeignKey("OrderID")]
        public virtual Tb_Order Tb_Order { get; set; }
    }
}