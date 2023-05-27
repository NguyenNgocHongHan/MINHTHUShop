using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MINHTHUShop.Web.Models
{
    public class FeedbackVM
    {
        public int FeedbackID { get; set; }

        [Required(ErrorMessage ="Bạn chưa nhập tên!")]
        [MaxLength(50, ErrorMessage = "Độ dài tên tối đa 50 ký tự")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập số điện thoại!")]
        [MaxLength(10, ErrorMessage = "Độ dài số điện thoại tối đa 10 ký tự")]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ!")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập email!")]
        [MaxLength(250, ErrorMessage = "Độ dài email tối đa 250 ký tự")]
        [EmailAddress(ErrorMessage = "Địa chỉ email không hợp lệ!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập nội dung phản hồi!")]
        public string Message { get; set; }

        public string Note { get; set; }

        public DateTime CreateDate { get; set; }

        public bool IsRead { get; set; }

        public IEnumerable<AboutVM> AboutVMs { set; get; }
    }
}