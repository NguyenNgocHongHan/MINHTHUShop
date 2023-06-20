using System.Collections.Generic;

namespace MINHTHUShop.Web.Models
{
    public class ProductCategoryVM
    {
        public int CateID { get; set; }
        public string Name { get; set; }
        public int? Sort { get; set; }
        public int? ParentID { get; set; }
        public string MetaTitle { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescriptions { get; set; }

        public virtual IEnumerable<ProductVM> ProductVMs { get; set; }
    }
}