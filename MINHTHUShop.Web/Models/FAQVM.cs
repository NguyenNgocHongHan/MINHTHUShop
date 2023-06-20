using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MINHTHUShop.Web.Models
{
    public class FAQVM
    {
        public int FAQID { get; set; }
        public int FAQCateID { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; }
        public string MetaTitle { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescriptions { get; set; }

        public virtual FAQCategoryVM FAQCategoryVM { get; set; }
    }
}