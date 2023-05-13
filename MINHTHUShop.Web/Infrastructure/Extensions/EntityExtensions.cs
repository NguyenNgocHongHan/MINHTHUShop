using MINHTHUShop.Model.Models;
using MINHTHUShop.Web.Models;

namespace MINHTHUShop.Web.Infrastructure.Extensions
{
    public static class EntityExtensions
    {
        public static void UpdateBrand(this Tb_Brand b, BrandVM vm)
        {
            b.BrandID = vm.BrandID;
            b.Name = vm.Name;
            b.BrandOrigin = vm.BrandOrigin;
        }

        public static void UpdateProductCategory(this Tb_ProductCategory pc, ProductCategoryVM vm)
        {
            pc.CateID = vm.CateID;
            pc.Name = vm.Name;
            pc.Sort = vm.Sort;
            pc.ParentID = vm.ParentID;
            pc.MetaTitle = vm.MetaTitle;
            pc.MetaKeywords = vm.MetaKeywords;
            pc.MetaDescriptions = vm.MetaDescriptions;
        }

        public static void UpdateProduct(this Tb_Product p, ProductVM vm)
        {
            p.ProductID = vm.ProductID;
            p.CateID = vm.CateID;
            p.BrandID = vm.BrandID;
            p.Name = vm.Name;
            p.Image = vm.Image;
            p.ListImg = vm.ListImg;
            p.OriginalPrice = vm.OriginalPrice;
            p.Price = vm.Price;
            p.PromotionPrice = vm.PromotionPrice;
            p.Description = vm.Description;
            p.Detail = vm.Detail;
            p.Tag = vm.Tag;
            p.CreateDate = vm.CreateDate;
            p.Status = vm.Status;
            p.MetaTitle = vm.MetaTitle;
            p.MetaKeywords = vm.MetaKeywords;
            p.MetaDescriptions = vm.MetaDescriptions;
        }
    }
}