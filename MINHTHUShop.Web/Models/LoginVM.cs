using System.ComponentModel.DataAnnotations;

namespace MINHTHUShop.Web.Models
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Bạn chưa nhập tên tài khoản!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập mật khẩu!")]
        /*[DataType(DataType.Password)]*/
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}