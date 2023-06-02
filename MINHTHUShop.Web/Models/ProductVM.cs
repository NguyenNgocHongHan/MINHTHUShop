using System;
using System.Collections.Generic;

namespace MINHTHUShop.Web.Models
{
    public class ProductVM
    {
        public int ProductID { get; set; }
        public int CateID { get; set; }
        public int BrandID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string ListImg { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal Price { get; set; }
        public decimal PromotionPrice { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }
        public string Tag { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; }
        public string MetaTitle { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescriptions { get; set; }

        public virtual ProductCategoryVM ProductCategory { get; set; }
        public virtual BrandVM Brand { get; set; }

        public virtual IEnumerable<TagProductVM> TagProductVMs { get; set; }
    }
}