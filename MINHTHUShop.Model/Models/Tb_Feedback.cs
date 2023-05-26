using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MINHTHUShop.Model.Models
{
    public class Tb_Feedback
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FeedbackID { get; set; }

        [Required]
        public string CustomerID { get; set; }

        [Required]
        public string Message { get; set; }

        public DateTime? CreateDate { get; set; } = DateTime.Now;

        public bool? IsRead { get; set; } = false;

        [ForeignKey("CustomerID")]
        public virtual Tb_User Customer { get; set; }
    }
}