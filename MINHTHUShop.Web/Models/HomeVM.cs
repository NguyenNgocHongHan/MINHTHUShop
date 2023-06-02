using System.Collections.Generic;

namespace MINHTHUShop.Web.Models
{
    public class HomeVM
    {
        public IEnumerable<BannerVM> Banners { get; set; }
        public IEnumerable<ProductVM> LastestProducts { get; set; }
        public IEnumerable<ProductCategoryVM> ProductCategories { get; set; }
        public IEnumerable<ProductVM> ProductsByCategory { get; set; }
        public IEnumerable<BrandVM> Brand { get; set; }
    }
}