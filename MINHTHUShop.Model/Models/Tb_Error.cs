using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MINHTHUShop.Model.Models
{
    public class Tb_Error
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ErrorID { get; set; }

        public string Message { get; set; }

        public string StackTrace { get; set; }

        public DateTime? CreateDate { get; set; } = DateTime.Now;
    }
}