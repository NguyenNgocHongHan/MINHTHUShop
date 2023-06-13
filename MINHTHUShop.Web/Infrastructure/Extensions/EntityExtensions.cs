using MINHTHUShop.Model.Models;
using MINHTHUShop.Web.Models;
using System;

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

        public static void UpdateFAQCategory(this Tb_FAQCategory fc, FAQCategoryVM vm)
        {
            fc.FAQCateID = vm.FAQCateID;
            fc.Name = vm.Name;
            fc.Sort = vm.Sort;
            fc.ParentID = vm.ParentID;
            fc.MetaTitle = vm.MetaTitle;
            fc.MetaKeywords = vm.MetaKeywords;
            fc.MetaDescriptions = vm.MetaDescriptions;
        }

        public static void UpdateFAQ(this Tb_FAQ f, FAQVM vm)
        {
            f.FAQID = vm.FAQID;
            f.FAQCateID = vm.FAQCateID;
            f.Question = vm.Question;
            f.Answer = vm.Answer;
            f.CreateDate = vm.CreateDate;
            f.Status = vm.Status;
            f.MetaTitle = vm.MetaTitle;
            f.MetaKeywords = vm.MetaKeywords;
            f.MetaDescriptions = vm.MetaDescriptions;
        }

        public static void UpdateWebpage(this Tb_Webpage wp, WebpageVM vm)
        {
            wp.PageID = vm.PageID;
            wp.Name = vm.Name;
            wp.Description = vm.Description;
            wp.CreateDate = vm.CreateDate;
            wp.Status = vm.Status;
            wp.MetaTitle = vm.MetaTitle;
            wp.MetaKeywords = vm.MetaKeywords;
            wp.MetaDescriptions = vm.MetaDescriptions;
        }

        public static void UpdateFeedback(this Tb_Feedback fb, FeedbackVM vm)
        {
            fb.FeedbackID = vm.FeedbackID;
            fb.Name = vm.Name;
            fb.Phone = vm.Phone;
            fb.Email = vm.Email;
            fb.Message = vm.Message;
            fb.Note = vm.Note;
            fb.CreateDate = vm.CreateDate;
            fb.IsRead = vm.IsRead;
        }

        public static void UpdateBanner(this Tb_Banner bn, BannerVM vm)
        {
            bn.BannerID = vm.BannerID;
            bn.Name = vm.Name;
            bn.Description = vm.Description;
            bn.Image = vm.Image;
            bn.Link = vm.Link;
            bn.Sort = vm.Sort;
            bn.CreateDate = vm.CreateDate;
            bn.Status = vm.Status;
        }

        public static void UpdateOrder(this Tb_Order od, OrderVM vm)
        {
            od.OrderID = vm.OrderID;
            od.CustomerID = vm.CustomerID;
            od.CustomerName = vm.CustomerName;
            od.CustomerAddress = vm.CustomerAddress;
            od.CustomerMobile = vm.CustomerMobile;
            od.OrderStatusID = vm.OrderStatusID;
            od.ShippingMethodID = vm.ShippingMethodID;
            od.PaymentMethodID = vm.PaymentMethodID;
            od.Note = vm.Note;
            od.CreateDate = DateTime.Now;
    }

    }

}