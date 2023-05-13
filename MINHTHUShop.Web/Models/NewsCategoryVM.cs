using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MINHTHUShop.Web.Models
{
    public class NewsCategoryVM
    {
        public int NewsCateID { get; set; }
        public string Name { get; set; }
        public int? Sort { get; set; }
        public int? ParentID { get; set; }
        public string MetaTitle { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescriptions { get; set; }

        public virtual IEnumerable<NewsVM> NewsVM { get; set; }
    }
}