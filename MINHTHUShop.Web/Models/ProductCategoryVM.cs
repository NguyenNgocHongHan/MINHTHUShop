using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MINHTHUShop.Web.Models
{
    public class ProductCategoryVM
    {
        public int CateID { get; set; }
        [Required]
        public string Name { get; set; }
        public int? Sort { get; set; }
        public int? ParentID { get; set; }
        [Required]
        public string MetaTitle { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescriptions { get; set; }
        public virtual IEnumerable<ProductVM> ProductVMs { get; set; }
    }
}