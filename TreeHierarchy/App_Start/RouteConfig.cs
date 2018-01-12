using System.Web.Mvc;
using System.Web.Routing;
using TreeHierarchy.App_Start;

namespace TreeHierarchy
{
    /// <summary>
    /// Class RouteConfig is used to register routes.
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// Registers the routes.
        /// </summary>
        /// <param name="routes">The routes.</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "DefaultMap",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            ).RouteHandler = new FriendlyURLRoute();

            routes.MapRoute(
               name: "FoldersRoute",
               url: "{*path}",
               defaults: new { controller = "Home", action = "FolderInfoShowView"}
            );
        }
    }
}
