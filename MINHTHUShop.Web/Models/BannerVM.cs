using System;

namespace MINHTHUShop.Web.Models
{
    public class BannerVM
    {
        public int BannerID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Link { get; set; }
        public int? Sort { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; }
    }
}