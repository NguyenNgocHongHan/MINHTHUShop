using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MINHTHUShop.Model.Models
{
    public class Tb_Banner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BannerID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        [MaxLength(250)]
        public string Image { get; set; }

        [MaxLength(250)]
        public string Link { get; set; }

        public int? Sort { get; set; }

        public int? Position { get; set; }

        [Required]
        public DateTime CreateDate { get; set; } = DateTime.Now;
        
        [Required]
        public bool Status { get; set; } = true;
    }
}