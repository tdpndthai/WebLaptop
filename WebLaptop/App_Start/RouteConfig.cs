using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebLaptop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //trang tĩnh nên để trên cùng
            routes.IgnoreRoute("{*botdetect}", new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });

            routes.MapRoute(
                name: "Contact",
                url: "lien-he.html",
                defaults: new { controller = "Contact", action = "Index", alias = UrlParameter.Optional },
                namespaces: new string[] { "WebLaptop.Controllers" } //check lỗi nếu trùng namespace
            );
            routes.MapRoute(
                name: "Search",
                url: "tim-kiem.html",
                defaults: new { controller = "Product", action = "Search", id = UrlParameter.Optional },
                namespaces: new string[] { "WebLaptop.Controllers" } //check lỗi nếu trùng namespace
            );
            routes.MapRoute(
                name: "Login",
                url: "dang-nhap.html",
                defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional },
                namespaces: new string[] { "WebLaptop.Controllers" } //check lỗi nếu trùng namespace
            );

            routes.MapRoute(
                name: "Page",
                url: "{alias}.html",
                defaults: new { controller = "Page", action = "Index", alias = UrlParameter.Optional },
                namespaces: new string[] { "WebLaptop.Controllers" } //check lỗi nếu trùng namespace
            );

            routes.MapRoute(
                name: "Product Category",
                url: "{alias}.pc-{id}.html",
                defaults: new { controller = "Product", action = "Category", id = UrlParameter.Optional },
                namespaces: new string[] { "WebLaptop.Controllers" } //check lỗi nếu trùng namespace
            );

            routes.MapRoute(
                name: "Product",
                url: "{alias}.p-{productId}.html",
                defaults: new { controller = "Product", action = "Detail", productId = UrlParameter.Optional },
                namespaces: new string[] { "WebLaptop.Controllers" } //check lỗi nếu trùng namespace
            );

            routes.MapRoute(
            name: "TagList",
            url: "tag/{tagid}.html",
            defaults: new { controller = "Product", action = "ListByTag", tagid = UrlParameter.Optional },
            namespaces: new string[] { "WebLaptop.Controllers" } //check lỗi nếu trùng namespace
        );


            //mặc định để cuối cùng
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
