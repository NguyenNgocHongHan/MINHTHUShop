namespace MINHTHUShop.Web.Models
{
    public class OrderDetailVM
    {
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }

        public virtual OrderVM OrderVM { get; set; }
        public virtual ProductVM ProductVM { get; set; }
    }
}