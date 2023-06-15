using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace MINHTHUShop.Model.Models
{
    public class Tb_Role : IdentityRole
    {
        public Tb_Role() : base()
        {
        }

        [StringLength(250)]
        public string Description { get; set; }
    }
}