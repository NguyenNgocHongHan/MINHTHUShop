using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MINHTHUShop.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

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
                name: "About",
                url: "gioi-thieu.html",
                defaults: new { controller = "About", action = "Index", id = UrlParameter.Optional },
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
