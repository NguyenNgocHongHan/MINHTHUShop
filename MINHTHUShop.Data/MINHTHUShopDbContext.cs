using Microsoft.AspNet.Identity.EntityFramework;
using MINHTHUShop.Model.Models;
using System.Data.Entity;

namespace MINHTHUShop.Data
{
    public class MINHTHUShopDbContext : IdentityDbContext<Tb_Staff>
    {
        public MINHTHUShopDbContext() : base("MINHTHUShopConnection")
        {
            this.Configuration.LazyLoadingEnabled = false; //khi load bảng cha sẽ không tự động includes bảng con
        }

        public DbSet<Tb_About> Tb_Abouts { get; set; }
        public DbSet<Tb_Banner> Tb_Banners { get; set; }
        public DbSet<Tb_Brand> Tb_Brands { get; set; }
        public DbSet<Tb_Config> Tb_Configs { get; set; }
        public DbSet<Tb_Customer> Tb_Customers { get; set; }
        public DbSet<Tb_FAQ> Tb_FAQs { get; set; }
        public DbSet<Tb_FAQCategory> Tb_FAQCategories { get; set; }
        public DbSet<Tb_Feedback> Tb_Feedbacks { get; set; }
        public DbSet<Tb_Menu> Tb_Menus { get; set; }
        public DbSet<Tb_MenuGroup> Tb_MenuGroups { get; set; }
        public DbSet<Tb_News> Tb_News { get; set; }
        public DbSet<Tb_NewsCategory> Tb_NewsCategories { get; set; }
        public DbSet<Tb_Order> Tb_Orders { get; set; }
        public DbSet<Tb_OrderDetail> Tb_OrderDetails { get; set; }
        public DbSet<Tb_OrderStatus> Tb_OrderStatuses { get; set; }
        public DbSet<Tb_Page> Tb_Pages { get; set; }
        public DbSet<Tb_Payment> Tb_Payments { get; set; }
        public DbSet<Tb_PaymentMethod> Tb_PaymentMethods { get; set; }
        public DbSet<Tb_Product> Tb_Products { get; set; }
        public DbSet<Tb_ProductCategory> Tb_ProductCategories { get; set; }
        public DbSet<Tb_ProductComment> Tb_ProductComments { get; set; }
        public DbSet<Tb_Shipping> Tb_Shippings { get; set; }
        public DbSet<Tb_ShippingMethod> Tb_ShippingMethods { get; set; }
        //public DbSet<Tb_Staff> Tb_Staffs { get; set; }
        public DbSet<Tb_Tag> Tb_Tags { get; set; }
        public DbSet<Tb_TagNews> Tb_TagNews { get; set; }
        public DbSet<Tb_TagProduct> Tb_TagProducts { get; set; }
        public DbSet<Tb_Target> Tb_Targets { get; set; }

        public DbSet<Tb_Error> Tb_Errors { get; set; }

        //phương thức tạo mới chính nó
        public static MINHTHUShopDbContext Create()
        {
            return new MINHTHUShopDbContext();
        }

        //phương thức ghi đè DbContext
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole>().HasKey(i => new { i.UserId, i.RoleId }).ToTable("ApplicationStaffRoles");
            modelBuilder.Entity<IdentityUserLogin>().HasKey(i => i.UserId).ToTable("ApplicationStaffLogins");
            modelBuilder.Entity<IdentityRole>().ToTable("ApplicationRoles");
            modelBuilder.Entity<IdentityUserClaim>().HasKey(i => i.UserId).ToTable("ApplicationStaffClaims");

        }
    }
}