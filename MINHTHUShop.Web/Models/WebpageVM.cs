using System;

namespace MINHTHUShop.Web.Models
{
    public class WebpageVM
    {
        public int PageID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; }
        public string MetaTitle { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescriptions { get; set; }
    }
}