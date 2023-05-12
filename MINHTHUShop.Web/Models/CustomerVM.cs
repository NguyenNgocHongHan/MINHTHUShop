using System;
using System.Collections.Generic;

namespace MINHTHUShop.Web.Models
{
    public class CustomerVM
    {
        public int CustomerID { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public bool? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Avatar { get; set; }
        public DateTime CreateDate { get; set; }
        public bool? IsLoggedIn { get; set; }
        public DateTime? LastLogin { get; set; }
        public bool Status { get; set; }

        public virtual IEnumerable<OrderVM> OrderVMs { get; set; }
    }
}