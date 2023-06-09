﻿using System.Web.Mvc;
using System.Web.Routing;

namespace MINHTHUShop.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // BotDetect requests must not be routed
            routes.IgnoreRoute("{*botdetect}", new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });

            routes.MapRoute(
                name: "Login",
                url: "dang-nhap.html",
                defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional },
                namespaces: new string[] { "MINHTHUShop.Web.Controllers" }
            );

            routes.MapRoute(
                name: "Register",
                url: "dang-ky.html",
                defaults: new { controller = "Account", action = "Register", id = UrlParameter.Optional },
                namespaces: new string[] { "MINHTHUShop.Web.Controllers" }
            );

            routes.MapRoute(
                name: "Cart",
                url: "gio-hang.html",
                defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "MINHTHUShop.Web.Controllers" }
            );

            routes.MapRoute(
                name: "Checkout",
                url: "thanh-toan.html",
                defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "MINHTHUShop.Web.Controllers" }
            );

            routes.MapRoute(
                name: "Feedback",
                url: "lien-he.html",
                defaults: new { controller = "Feedback", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "MINHTHUShop.Web.Controllers" }
            );

            routes.MapRoute(
                name: "Webpage",
                url: "trang/{metaTitle}.html",
                defaults: new { controller = "Webpage", action = "Index", metaTitle = UrlParameter.Optional },
                namespaces: new string[] { "MINHTHUShop.Web.Controllers" }
            );

            routes.MapRoute(
                name: "Search",
                url: "tim-kiem.html",
                defaults: new { controller = "Product", action = "Search", id = UrlParameter.Optional },
                namespaces: new string[] { "MINHTHUShop.Web.Controllers" }
            );

            routes.MapRoute(
                name: "ListProducts",
                url: "san-pham.html",
                defaults: new { controller = "Product", action = "ListProducts", id = UrlParameter.Optional },
                namespaces: new string[] { "MINHTHUShop.Web.Controllers" }
            );

            routes.MapRoute(
                name: "TagList",
                url: "tag/{tagID}.html",
                defaults: new { controller = "Product", action = "ListProductByTag", tagID = UrlParameter.Optional },
                namespaces: new string[] { "MINHTHUShop.Web.Controllers" }
            );

            routes.MapRoute(
                name: "Product Category",
                url: "{metaTitle}.pc-{cateId}.html",
                defaults: new { controller = "Product", action = "DetailCategory", cateId = UrlParameter.Optional },
                namespaces: new string[] { "MINHTHUShop.Web.Controllers" }
            );

            routes.MapRoute(
                name: "Product",
                url: "{metaTitle}.p-{productId}.html",
                defaults: new { controller = "Product", action = "DetailProduct", productId = UrlParameter.Optional },
                namespaces: new string[] { "MINHTHUShop.Web.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "MINHTHUShop.Web.Controllers" }
            );
        }
    }
}