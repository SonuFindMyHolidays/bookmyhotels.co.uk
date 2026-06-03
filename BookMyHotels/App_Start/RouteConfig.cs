using System.Web.Mvc;
using System.Web.Routing;

namespace GetMeRoom
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            
            // API Routes
            //routes.MapRoute(
            //    name: "AutoSuggest",
            //    url: "api/autosuggest",
            //    defaults: new { controller = "Home", action = "GetLocation" }
            //);

            //routes.MapRoute(
            //    name: "AutoSearchHotel",
            //    url: "api/searchhotel",
            //    defaults: new { controller = "Home", action = "SearchHotel" }
            //);
            // Static SEO pages (WITHOUT controller name)
            routes.MapRoute(
                name: "StaticPages",
                url: "{slug}",
                defaults: new { controller = "Home", action = "StaticPage" }
            );

            // Default MVC Route
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapMvcAttributeRoutes();
        }
    }
}
