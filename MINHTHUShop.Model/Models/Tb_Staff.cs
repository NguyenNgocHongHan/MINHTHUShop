﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MINHTHUShop.Model.Models
{
    public class Tb_Staff : IdentityUser
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(250)]
        public string Address { get; set; }

        public bool? Gender { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [MaxLength(250)]
        public string Avatar { get; set; }

        [Required]
        public DateTime CreateDate { get; set; } = DateTime.Now;

        public bool? IsLoggedIn { get; set; }

        public DateTime? LastLogin { get; set; }

        [Required]
        public bool Status { get; set; } = true;

        public async Task<ClaimsIdentity> GenerateStaffIdentityAsync(UserManager<Tb_Staff> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var staffIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return staffIdentity;
        }
    }
}