using MINHTHUShop.Model.Abstract;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MINHTHUShop.Model.Models
{
    public class Tb_About
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AboutID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(10)]
        [Column(TypeName = "char")]
        public string Phone { get; set; }

        [MaxLength(250)]
        [Column(TypeName = "varchar")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }

        [MaxLength(250)]
        public string Fanpage { get; set; }

        [Required]
        [MaxLength(250)]
        public string Address { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime CreateDate { get; set; } = DateTime.Now;

        [Required]
        public bool Status { get; set; } = true;
    }
}