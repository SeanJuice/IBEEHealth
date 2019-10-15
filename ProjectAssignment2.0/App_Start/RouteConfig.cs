using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProjectAssignment2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "dashhome",
                url: "dashboard/home",
                defaults: new { controller = "Dashboard", action = "Home", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "diseases",
                url: "dashboard/diseases",
                defaults: new { controller = "Dashboard", action = "Diseases", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "healthcentres",
                url: "dashboard/healthcentres",
                defaults: new { controller = "Dashboard", action = "HealthCentres", id = UrlParameter.Optional }
            );

            routes.MapRoute("register", "auth/register", new { controller = "Auth", action = "Register", id = UrlParameter.Optional }
            );

            routes.MapRoute("login", "auth/login", new { controller = "Auth", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute("welcome", "home/index", new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute("about", "home/about", new { controller = "Home", action = "About", id = UrlParameter.Optional }
            );

            routes.MapRoute("contact", "home/contact", new { controller = "Home", action = "Contact", id = UrlParameter.Optional }
            );
        }
    }
}
