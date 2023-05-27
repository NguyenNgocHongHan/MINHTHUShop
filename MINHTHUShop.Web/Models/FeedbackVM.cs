using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MINHTHUShop.Web.Models
{
    public class FeedbackVM
    {
        public int FeedbackID { get; set; }
        public string CustomerID { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập nội dung phản hồi!")]
        public string Message { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool? IsRead { get; set; }

        [ForeignKey("CustomerID")]
        public virtual UserVM CustomerVM { get; set; }
        public IEnumerable<AboutVM> AboutVMs { set; get; }
    }
}