namespace MINHTHUShop.Web.Models
{
    public class ProductCategoryVM
    {
        public int CateID { get; set; }
        public string Name { get; set; }
        public int? Sort { get; set; }
        public int? ParentID { get; set; }
    }
}