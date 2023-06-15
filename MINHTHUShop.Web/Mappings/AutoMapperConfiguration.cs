using AutoMapper;
using MINHTHUShop.Model.Models;
using MINHTHUShop.Web.Models;

namespace MINHTHUShop.Web.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Tb_Banner, BannerVM>();
                cfg.CreateMap<Tb_Brand, BrandVM>();
                cfg.CreateMap<Tb_FAQCategory, FAQCategoryVM>();
                cfg.CreateMap<Tb_FAQ, FAQVM>();
                cfg.CreateMap<Tb_Feedback, FeedbackVM>();
                cfg.CreateMap<Tb_OrderDetail, OrderDetailVM>();
                cfg.CreateMap<Tb_OrderStatus, OrderStatusVM>();
                cfg.CreateMap<Tb_Order, OrderVM>();
                cfg.CreateMap<Tb_Webpage, WebpageVM>();
                cfg.CreateMap<Tb_PaymentMethod, PaymentMethodVM>();
                cfg.CreateMap<Tb_ProductCategory, ProductCategoryVM>();
                cfg.CreateMap<Tb_Product, ProductVM>();
                cfg.CreateMap<Tb_ShippingMethod, ShippingMethodVM>();
                cfg.CreateMap<Tb_User, UserVM>();
                cfg.CreateMap<Tb_Role, RoleVM>();
                cfg.CreateMap<Tb_Group, GroupVM>();
                cfg.CreateMap<Tb_TagProduct, TagProductVM>();
                cfg.CreateMap<Tb_Tag, TagVM>();
            });
        }
    }
}