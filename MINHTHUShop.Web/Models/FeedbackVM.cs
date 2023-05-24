using System;
using System.ComponentModel.DataAnnotations;

namespace MINHTHUShop.Web.Models
{
    public class FeedbackVM
    {
        public int FeedbackID { get; set; }
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập nội dung phản hồi!")]
        public string Message { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool? IsRead { get; set; }
        public virtual CustomerVM CustomerVM { get; set; }
        public AboutVM About { get; set; }
    }
}