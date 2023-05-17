using System.ComponentModel.DataAnnotations;

namespace MINHTHUShop.Model.Models
{
    public class Tb_Footer
    {
        [Key]
        [MaxLength(50)]
        public string FooterID { set; get; }

        [Required]
        public string Description { set; get; }
    }
}