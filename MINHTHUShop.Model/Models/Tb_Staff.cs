using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MINHTHUShop.Model.Models
{
    public class Tb_Staff
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StaffID { get; set; }

        [Required]
        public int RoleID { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string UserName { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Password { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "varchar(250)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "char(10)")]
        public string Phone { get; set; }

        [Required]
        [MaxLength(250)]
        public string Address { get; set; }

        public bool? Gender { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [MaxLength(250)]
        public string Avatar { get; set; }

        public DateTime? CreateDate { get; set; } = DateTime.Now;

        public bool? IsLoggedIn { get; set; }

        public DateTime? LastLogin { get; set; }

        public bool? Status { get; set; } = true;

        [ForeignKey("RoleID")]
        public virtual Tb_Role Tb_Role { get; set; }
    }
}