using System.ComponentModel.DataAnnotations;

namespace MINHTHUShop.Web.Models
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Bạn chưa nhập email!")]
        [EmailAddress(ErrorMessage = "Địa chỉ email không hợp lệ!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập mật khẩu!")]
        /*[DataType(DataType.Password)]*/
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}