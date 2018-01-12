using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TreeHierarchy.DbContexts;
using TreeHierarchy.Helper;
using TreeHierarchy.Models;

namespace TreeHierarchy.Controllers
{
    /// <summary>
    /// Class HomeController is used for navigation through the application: get folders tree and sub-tree.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class HomeController : Controller
    {
        /// <summary>
        /// Default page. Shows the folders tree.
        /// </summary>
        /// <returns>
        ///   <see cref="ActionResult" />
        /// </returns>
        public ActionResult Index()
        {
            using (var _db = new DbContext())
            {
                List<TreeNode> nodes = _db.TreeNodes.ToList();
                List<TreeNode> nodesList = NodesHelper.GetChildren(nodes, 0);
                return View(nodesList);
            }
        }
        /// <summary>
        /// Shows the folder and its subfolders.
        /// </summary>
        /// <param name="path">The path of the folder.</param>
        /// <returns>
        ///   <see cref="ActionResult" />
        /// </returns>
        public ActionResult FolderInfoShowView(string path)
        {
            if (path != null)
            {
                using (var _db = new DbContext())
                {
                    string folderName = path.TrimEnd(new[] { '/' });
                    folderName = folderName.Substring(folderName.LastIndexOf('/') + 1);
                    TreeNode folder = _db.TreeNodes.FirstOrDefault(e => e.Name == folderName);
                    if (folder != null)
                    {
                        List<TreeNode> folders = new List<TreeNode>();
                        List<TreeNode> nodesList = _db.TreeNodes.ToList();
                        NodesHelper.GetPath(nodesList, folder.ParentID, folder);
                        List<TreeNode> childs = nodesList.Where(e => e.ParentID == folder.Id).ToList();
                        folder.Children = childs;
                        folder.Children.ForEach(e => NodesHelper.GetPath(nodesList, e.Id, e));
                        folders.Add(folder); 
                        return View(folders);
                    }
                }
            }
            return View("NotFound");
        }
    }
}