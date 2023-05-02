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
                /*cfg.CreateMap<Tb_About, AboutVM>();
                cfg.CreateMap<Tb_Banner, BannerVM>();*/
                cfg.CreateMap<Tb_Brand, BrandVM>();

                /*cfg.CreateMap<Tb_Customer, CustomerVM>();

                cfg.CreateMap<Tb_FAQ, FAQVM>();
                cfg.CreateMap<Tb_FAQCategory, FAQCategoryVM>();
                cfg.CreateMap<Tb_Feedback, FeedbackVM>();
                cfg.CreateMap<Tb_Menu, MenuVM>();
                cfg.CreateMap<Tb_MenuGroup, MenuGroupVM>();
                cfg.CreateMap<Tb_News, NewsVM>();
                cfg.CreateMap<Tb_NewsCategory, NewsCategoryVM>();

                cfg.CreateMap<Tb_Page, PageVM>();*/

                cfg.CreateMap<Tb_Product, ProductVM>();
                cfg.CreateMap<Tb_ProductCategory, ProductCategoryVM>();

               /* cfg.CreateMap<Tb_Role, RoleVM>();
                cfg.CreateMap<Tb_Staff, StaffVM>();
                cfg.CreateMap<Tb_Tag, TagVM>();
                cfg.CreateMap<Tb_TagNews, TagNewsVM>();
                cfg.CreateMap<Tb_TagProduct, TagProductVM>();
                cfg.CreateMap<Tb_Target, TargetVM>();*/
            });
        }
    }
}