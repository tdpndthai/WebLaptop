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
            routes.MapRoute(
                name: "Login",
                url: "dang-nhap.html",
                defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional },
                namespaces: new string[] { "WebLaptop.Controllers" } //check lỗi nếu trùng namespace
            );

            routes.MapRoute(
                name: "About",
                url: "gioi-thieu.html",
                defaults: new { controller = "Product", action = "Index", id = UrlParameter.Optional },
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


            //mặc định để cuối cùng
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
