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
                cfg.CreateMap<Tb_Brand, BrandVM>();
                cfg.CreateMap<Tb_Customer, CustomerVM>();
                cfg.CreateMap<Tb_OrderDetail, OrderDetailVM>();
                cfg.CreateMap<Tb_OrderStatus, OrderStatusVM>();
                cfg.CreateMap<Tb_Order, OrderVM>();
                cfg.CreateMap<Tb_PaymentMethod, PaymentMethodVM>();
                cfg.CreateMap<Tb_ProductCategory, ProductCategoryVM>();
                cfg.CreateMap<Tb_ProductComment, ProductCommentVM>();
                cfg.CreateMap<Tb_Product, ProductVM>();
                cfg.CreateMap<Tb_RoleStaff, RoleStaffVM>();
                cfg.CreateMap<Tb_ShippingMethod, ShippingMethodVM>();
                cfg.CreateMap<Tb_Staff, StaffVM>();
                cfg.CreateMap<Tb_TagProduct, TagProductVM>();
                cfg.CreateMap<Tb_Tag, TagVM>();
            });
        }
    }
}