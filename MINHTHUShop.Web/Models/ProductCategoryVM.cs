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
    }
}