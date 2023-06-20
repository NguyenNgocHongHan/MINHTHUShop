using System.Collections.Generic;

namespace MINHTHUShop.Web.Models
{
    public class FAQCategoryVM
    {
        public int FAQCateID { get; set; }
        public string Name { get; set; }
        public int? Sort { get; set; }
        public int? ParentID { get; set; }
        public string MetaTitle { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescriptions { get; set; }

        public virtual IEnumerable<FAQVM> FAQVMs { get; set; }
    }
}