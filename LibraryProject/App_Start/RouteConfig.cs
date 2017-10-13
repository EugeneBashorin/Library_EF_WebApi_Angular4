using System.Web.Mvc;
using System.Web.Routing;

namespace LibraryProject
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{*anything}",//"{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index"/*"Books"*/, id = UrlParameter.Optional }
            );
        }
    }
}
