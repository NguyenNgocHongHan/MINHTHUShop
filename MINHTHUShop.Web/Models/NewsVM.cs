using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MINHTHUShop.Web.Models
{
    public class NewsVM
    {
        public int NewsID { get; set; }
        public int NewsCateID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Tag { get; set; }
        public string MetaTitle { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescriptions { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; }

        public virtual NewsCategoryVM NewsCategoryVM { get; set; }
        public virtual IEnumerable<TagNewsVM> TagNewsVM { get; set; }
    }
}