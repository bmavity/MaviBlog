using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Spark.Web.Mvc;

namespace MaviBlog.Web.UI
{
    public class MvcApplication : HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("single_post", "posts/{seoFriendlyName}/{action}", new { controller = "Post", action = "Individual" });
            routes.MapRoute("recent_posts", "posts", new { controller = "Post", action = "Index" });
            routes.MapRoute("Default", "{controller}/{action}", new { controller = "Home", action = "Index", id = "" });

            ViewEngines.Engines.Add(new SparkViewFactory());
        }

        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
        }
    }
}