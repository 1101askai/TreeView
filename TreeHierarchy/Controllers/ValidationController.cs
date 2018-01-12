using System.Linq;
using System.Web.Mvc;
using TreeHierarchy.DbContexts;
using TreeHierarchy.Models;

namespace TreeHierarchy.Controllers
{
    /// <summary>
    /// Class ValidationController is used for validation <see cref="TreeNode"/> model.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class ValidationController : Controller
    {
        /// <summary>
        /// Determines whether [folder name] is unique in catalog or no.
        /// </summary>
        /// <param name="model">The <see cref="TreeNode" /> model.</param>
        /// <returns>
        ///   <see cref="JsonResult" />
        /// </returns>
        [ValidateInput(false)]
        public JsonResult IsFolderNameUnique(TreeNode model)
        {
            if (model != null)
            {
                using (var _db = new DbContext())
                {
                    int countDuplicates = _db.TreeNodes.Count(e => e.Name == model.Name && e.ParentID == model.ParentID);
                    return Json(countDuplicates == 0, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }
    }
}