namespace MINHTHUShop.Web.Models
{
    public class ShippingMethodVM
    {
        public int ShippingMethodID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public bool Status { get; set; }
    }
}