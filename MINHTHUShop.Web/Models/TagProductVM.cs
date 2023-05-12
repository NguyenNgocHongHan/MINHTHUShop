namespace MINHTHUShop.Web.Models
{
    public class TagProductVM
    {
        public int TagProductID { get; set; }
        public int TagID { get; set; }
        public int ProductID { get; set; }

        public virtual TagVM TagVM { get; set; }
        public virtual ProductVM ProductVM { get; set; }
    }
}