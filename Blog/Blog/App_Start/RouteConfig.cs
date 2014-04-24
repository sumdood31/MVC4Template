using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BlogWeb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                "Article", // Route name
                "{categoryUrl}/{textId}.html", // URL with parameters,
                new
                {
                    controller = "Home",
                    action = "Article",
                    categoryUrl = UrlParameter.Optional,
                }//, // Parameter defaults
            );
            
            routes.MapRoute(
                "Article2", // Route name
                "{categoryUrl}/{subCategoryUrl}/{textId}.html", // URL with parameters,
                new
                {
                    controller = "Home",
                    action = "Article",
                    categoryUrl = UrlParameter.Optional,
                    subCategoryUrl = UrlParameter.Optional,
                }//, // Parameter defaults
            );

            routes.MapRoute(
                "Article3", // Route name
                "{categoryUrl}/{subCategoryUrl}/{subSubCategoryUrl}/{textId}.html", // URL with parameters,
                new { controller = "Home", action = "Article",
                      categoryUrl = UrlParameter.Optional,
                      subCategoryUrl = UrlParameter.Optional,
                      subSubCategoryUrl = UrlParameter.Optional
                }//, // Parameter defaults
            );

            routes.MapRoute(
                name: "List",
                url: "List/{textId}",
                defaults: new { controller = "Home", action = "List", textId = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Tag",
                url: "Tag/{textId}",
                defaults: new { controller = "Home", action = "Tag", textId = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}