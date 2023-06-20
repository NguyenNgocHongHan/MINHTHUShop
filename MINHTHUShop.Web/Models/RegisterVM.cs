using System;
using System.ComponentModel.DataAnnotations;

namespace MINHTHUShop.Web.Models
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Bạn chưa nhập tên!")]
        [MaxLength(50, ErrorMessage = "Tên không được quá 50 ký tự")]
        public string Name { set; get; }

        [Required(ErrorMessage = "Bạn chưa nhập tên tài khoản!")]
        public string UserName { set; get; }

        [Required(ErrorMessage = "Bạn chưa nhập mật khẩu!")]
        [MinLength(6, ErrorMessage = "Mật khẩu phải có ít nhất 6 ký tự")]
        public string Password { set; get; }

        [Required(ErrorMessage = "Bạn chưa nhập email!")]
        [EmailAddress(ErrorMessage = "Địa chỉ email không hợp lệ!")]
        public string Email { set; get; }

        [Required(ErrorMessage = "Bạn chưa nhập địa chỉ!")]
        [MaxLength(250, ErrorMessage = "Địa chỉ không vượt quá 250 ký tự")]
        public string Address { set; get; }

        [Required(ErrorMessage = "Bạn chưa nhập số điện thoại!")]
        [MaxLength(10, ErrorMessage = "Số điện thoại không được quá 10 số")]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ!")]
        public string Phone { set; get; }

        public DateTime CreateDat { get; set; }

        public bool Status { get; set; }
    }
}