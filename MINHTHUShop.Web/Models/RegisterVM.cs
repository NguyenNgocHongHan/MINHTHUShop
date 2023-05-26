using System.ComponentModel.DataAnnotations;

namespace MINHTHUShop.Web.Models
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Bạn chưa nhập tên!")]
        public string Name { set; get; }

        [Required(ErrorMessage = "Bạn chưa nhập mật khẩu!")]
        [MinLength(6, ErrorMessage = "Mật khẩu phải có ít nhất 6 ký tự!")]
        public string Password { set; get; }

        [Required(ErrorMessage = "Bạn chưa nhập email!")]
        [EmailAddress(ErrorMessage = "Địa chỉ email không đúng!")]
        public string Email { set; get; }

        [Required(ErrorMessage = "Bạn chưa nhập địa chỉ!")]
        public string Address { set; get; }

        [Required(ErrorMessage = "Bạn chưa nhập số điện thoại!")]
        public string PhoneNumber { set; get; }
    }
}