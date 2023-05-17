namespace MINHTHUShop.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MINHTHUShop.Model.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MINHTHUShop.Data.MINHTHUShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MINHTHUShop.Data.MINHTHUShopDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            CreateUser(context);

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
        private void CreateUser(MINHTHUShopDbContext context)
        {
            var manager = new UserManager<Tb_Staff>(new UserStore<Tb_Staff>(new MINHTHUShopDbContext()));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new MINHTHUShopDbContext()));

            var user = new Tb_Staff()
            {
                UserName = "admin",
                Email = "han.nnh.work@gmail.com",
                EmailConfirmed = true,
                CreateDate = DateTime.Now,
                Name = "Nguyễn Ngọc Hồng Hân",
                Address = "Nha Trang, Khánh Hòa",
                Status = true
            };
            if (manager.Users.Count(x => x.UserName == "admin") == 0)
            {
                manager.Create(user, "admin123");

                if (!roleManager.Roles.Any())
                {
                    roleManager.Create(new IdentityRole { Name = "Quản trị viên" });
                    roleManager.Create(new IdentityRole { Name = "Nhân viên" });
                }

                var adminUser = manager.FindByEmail("han.nnh.work@gmail.com");

                manager.AddToRoles(adminUser.Id, new string[] { "Quản trị viên"});
            }
        }
    }
}
