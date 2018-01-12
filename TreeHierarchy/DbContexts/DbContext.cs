using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using TreeHierarchy.Models;

namespace TreeHierarchy.DbContexts
{
    /// <summary>
    /// Class DbContext is used to represent a session with database and to provide DbSet for each type of model.
    /// </summary>
    /// <seealso cref="System.Data.Entity.DbContext" />
    [Localizable(false)]
    [DbConfigurationType(typeof(TreeNodeDbConfiguration))]
    public class DbContext : System.Data.Entity.DbContext
    {
        public DbSet<TreeNode> TreeNodes { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DbContext" /> class.
        /// </summary>
        public DbContext() : base("name=DefaultConnection")
        {
        }
    }
}