using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TreeHierarchy.DbContexts;
using TreeHierarchy.Models;

namespace TreeHierarchy.App_Start
{
    /// <summary>
    /// Class FriendlyURLRoute is used for matching user-friendly URLs of the folders.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.MvcRouteHandler" />
    public class FriendlyURLRoute : MvcRouteHandler
    {
        /// <summary>
        /// Returns the HTTP handler by using the specified HTTP context.
        /// </summary>
        /// <param name="requestContext">The request <seealso cref="RequestContext"/> context.</param>
        /// <returns>
        /// The <seealso cref="IHttpHandler"/> HTTP handler.
        /// </returns>
        protected override IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            RouteValueDictionary pathValues = requestContext.RouteData.Values;
            if (pathValues != null)
            {
                using (var _db = new DbContext())
                {
                    TreeNode root = _db.TreeNodes.FirstOrDefault(e => e.ParentID == 0);
                    if (root != null && root.Name == pathValues.Values.ElementAt(0).ToString())
                    {
                        requestContext.RouteData.Values["controller"] = "Home";
                        requestContext.RouteData.Values["action"] = "FolderInfoShowView";
                        requestContext.RouteData.Values["path"] = requestContext.HttpContext.Request.RawUrl;
                    }
                }
            }
            if (requestContext.RouteData.Values["controller"] == null)
            {
                requestContext.RouteData.Values["controller"] = "Home";
                requestContext.RouteData.Values["action"] = "Index";
            }
            return base.GetHttpHandler(requestContext);
        }
    }
}