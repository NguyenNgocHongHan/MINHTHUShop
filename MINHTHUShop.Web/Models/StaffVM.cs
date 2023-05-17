using System;

namespace MINHTHUShop.Web.Models
{
    public class StaffVM
    {
        public string StaffID { get; set; }
        public int RoleID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Avatar { get; set; }
        public DateTime CreateDate { get; set; }
        public bool? IsLoggedIn { get; set; }
        public DateTime? LastLogin { get; set; }
        public bool Status { get; set; }

        public virtual RoleStaffVM RoleStaffVM { get; set; }
    }
}