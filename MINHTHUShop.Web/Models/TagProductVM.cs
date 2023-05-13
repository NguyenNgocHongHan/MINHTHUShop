namespace MINHTHUShop.Web.Models
{
    public class TagProductVM
    {
        public int ProductID { get; set; }
        public string TagID { get; set; }

        public virtual TagVM TagVM { get; set; }
        public virtual ProductVM ProductVM { get; set; }
    }
}