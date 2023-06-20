using System.ComponentModel.DataAnnotations;

namespace MINHTHUShop.Model.Abstract
{
    public abstract class SEO : ISEO
    {
        [Required]
        [MaxLength(250)]
        public string MetaTitle { get; set; }

        [MaxLength(250)]
        public string MetaKeywords { get; set; }

        [MaxLength(500)]
        public string MetaDescriptions { get; set; }
    }
}