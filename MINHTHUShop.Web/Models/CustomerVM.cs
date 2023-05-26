using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MINHTHUShop.Web.Models
{
    public class CustomerVM
    {
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập email!")]
        [EmailAddress(ErrorMessage = "Địa chỉ email không đúng!")]
        public string Email { set; get; }

        [Required(ErrorMessage = "Bạn chưa nhập mật khẩu!")]
        public string Password { set; get; }

        [Required(ErrorMessage = "Bạn chưa nhập lại mật khẩu!")]
        [System.ComponentModel.DataAnnotations.Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập tên!")]
        public string Name { set; get; }

        [Required(ErrorMessage = "Bạn chưa nhập số điện thoại!")]
        public string Phone { set; get; }


        [Required(ErrorMessage = "Bạn chưa nhập địa chỉ!")]
        public string Address { set; get; }

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