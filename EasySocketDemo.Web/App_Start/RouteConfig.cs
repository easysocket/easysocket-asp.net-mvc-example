using System.Web.Mvc;
using System.Web.Routing;

namespace EasySocketDemo.Web.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute("Default", "{action}", new { controller = "Home", action = "Index"});
        }
    }
}