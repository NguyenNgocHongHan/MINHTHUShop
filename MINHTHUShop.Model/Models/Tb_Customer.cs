using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MINHTHUShop.Model.Models
{
    public class Tb_Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerID { get; set; }

        [Required]
        [MaxLength(250)]
        [Column(TypeName = "varchar")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }

        [Required]
        [MaxLength(250)]
        [Column(TypeName = "varchar")]
        public string Password { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(10)]
        [Column(TypeName = "char")]
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
/*
        public async Task<ClaimsIdentity> GenerateCustomerIdentityAsync(UserManager<Tb_Customer> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var customerIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return customerIdentity;
        }
*/
        public virtual IEnumerable<Tb_Order> Tb_Orders { get; set; }
    }
}