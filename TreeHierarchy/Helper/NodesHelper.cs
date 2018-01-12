using System.Collections.Generic;
using System.Linq;
using TreeHierarchy.Models;

namespace TreeHierarchy.Helper
{
    /// <summary>
    /// NodesHelper class is used for the creating folders tree and settings their path.
    /// </summary>
    public static class NodesHelper
    {
        /// <summary>
        /// Gets the folders subtree for the folder.
        /// </summary>
        /// <param name="source">The <see cref="List{TreeNode}" /> source.</param>
        /// <param name="parentId">The parent identifier.</param>
        /// <returns>
        ///   <see cref="List{TreeNode}" />
        /// </returns>
        public static List<TreeNode> GetChildren(List<TreeNode> source, int parentId)
        {
            TreeNode parent = source.FirstOrDefault(x => x.Id == parentId);
            List<TreeNode> children = source.Where(x => x.ParentID == parentId).ToList();

            children.ForEach(x => x.Path = $"{parent?.Path}/{x.Name}");
            children.ForEach(x => x.Children = GetChildren(source, x.Id));
            return children;
        }
        /// <summary>
        /// Gets the path of the folder.
        /// </summary>
        /// <param name="source">The <see cref="List{TreeNode}" /> list of the existed folders.</param>
        /// <param name="parentId">The parent identifier.</param>
        /// <param name="node">The node.</param>
        /// <returns>
        ///   <see cref="TreeNode" />
        /// </returns>
        public static TreeNode GetPath(List<TreeNode> source, int parentId, TreeNode node)
        {
            TreeNode parent = source.FirstOrDefault(x => x.Id == parentId);
            node.Path = parent == null ? $"/{node.Path}" : $"{parent.Name}/{node.Path}";
            if (parent != null)
            {
                GetPath(source, parent.ParentID, node);
            }
            return node;
        }
    }
}