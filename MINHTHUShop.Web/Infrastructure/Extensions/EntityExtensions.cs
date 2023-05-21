﻿using MINHTHUShop.Model.Models;
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

        public static void UpdateNewsCategory(this Tb_NewsCategory nc, NewsCategoryVM vm)
        {
            nc.NewsCateID = vm.NewsCateID;
            nc.Name = vm.Name;
            nc.Sort = vm.Sort;
            nc.ParentID = vm.ParentID;
            nc.MetaTitle = vm.MetaTitle;
            nc.MetaKeywords = vm.MetaKeywords;
            nc.MetaDescriptions = vm.MetaDescriptions;
        }

        public static void UpdateNews(this Tb_News n, NewsVM vm)
        {
            n.NewsID = vm.NewsID;
            n.NewsCateID = vm.NewsCateID;
            n.Name = vm.Name;
            n.Image = vm.Image;
            n.Description = vm.Description;
            n.Tag = vm.Tag;
            n.CreateDate = vm.CreateDate;
            n.Status = vm.Status;
            n.MetaTitle = vm.MetaTitle;
            n.MetaKeywords = vm.MetaKeywords;
            n.MetaDescriptions = vm.MetaDescriptions;
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

    }
}