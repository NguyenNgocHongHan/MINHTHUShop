using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MINHTHUShop.Model.Models
{
    public class Tb_ProductComment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentID { get; set; }

        [Required]
        public int ProductID { get; set; }

        [Required]
        public int CustomerID { get; set; }

        [Required]
        public float Vote { get; set; }

        [Required]
        [MaxLength(500)]
        public string Comment { get; set; }

        //[System.ComponentModel.DefaultValue(typeof(DateTime), "")]
        public DateTime? CreateDate { get; set; } = DateTime.Now;

        [DefaultValue(true)]
        public bool? Status { get; set; }

        [ForeignKey("ProductID")]
        public virtual Tb_Product Tb_Product { get; set; }

        [ForeignKey("CustomerID")]
        public virtual Tb_Customer Tb_Customer { get; set; }
    }
}