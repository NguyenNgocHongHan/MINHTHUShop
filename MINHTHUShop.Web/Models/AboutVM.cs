using System;

namespace MINHTHUShop.Web.Models
{
    public class AboutVM
    {
        public int AboutID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public double? MapLat { get; set; }
        public double? MapLong { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; }
    }
}