using MINHTHUShop.Model.Abstract;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MINHTHUShop.Model.Models
{
    public class Tb_Page : SEO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PageID { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        [MaxLength(250)]
        public string URL { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}