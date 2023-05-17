﻿namespace MINHTHUShop.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MINHTHUShop.Common;
    using MINHTHUShop.Model.Models;
    using System;
    using System.Collections.Generic;
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
            CreateBanner(context);
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

                manager.AddToRoles(adminUser.Id, new string[] { "Quản trị viên" });
            }
        }

        private void CreateFooter(MINHTHUShopDbContext context)
        {
            if (context.Tb_Footers.Count(x => x.FooterID == CommonConstants.DefaultFooterId) == 0)
            {
                string content = "";
            }
        }

        private void CreateBanner(MINHTHUShopDbContext context)
        {
            if (context.Tb_Banners.Count() == 0)
            {
                List<Tb_Banner> listBanner = new List<Tb_Banner>()
                {
                    new Tb_Banner() {
                        Name ="Slide 1",
                        Sort =1,
                        Status =true,
                        Link ="#",
                        CreateDate = DateTime.Now,
                        Image ="/Content/Client/images/bag.jpg",
                        Description =@"	<h2>FLAT 50% 0FF</h2>
                                <label>FOR ALL PURCHASE <b>VALUE</b></label>
                                <p>Lorem ipsum dolor sit amet, consectetur 
                            adipisicing elit, sed do eiusmod tempor incididunt ut labore et </ p >
                        <span class=""on-get"">GET NOW</span>" },
                    new Tb_Banner() {
                        Name ="Slide 2",
                        Sort =2,
                        Status =true,
                        CreateDate = DateTime.Now,
                        Link ="#",
                        Image ="/Content/Client/images/bag1.jpg",
                        Description=@"<h2>FLAT 50% 0FF</h2>
                                <label>FOR ALL PURCHASE <b>VALUE</b></label>
                                <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et </ p >
                                <span class=""on-get"">GET NOW</span>"},
                    };
                    context.Tb_Banners.AddRange(listBanner);
                    context.SaveChanges();
            }
        }
    }
}
