using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace TreeHierarchy.Models
{
    /// <summary>
    /// Class TreeNode is a model for the folders tree node.
    /// </summary>
    public class TreeNode
    {
        /// <summary>
        /// Gets or sets the folder identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the parent identifier of the folder.
        /// </summary>
        /// <value>
        /// The parent identifier.
        /// </value>
        public int ParentID { get; set; }

        /// <summary>
        /// Gets or sets the folder name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Required]
        [RegularExpression("^[a-zA-Z ]+$")]
        [Remote("IsFolderNameUnique", "Validation", ErrorMessage = "Folder with the same name already exist")]
        public string Name { get; set; }

        /// <summary>
        /// The List of the sub folders.
        /// </summary>
        [NotMapped]
        public List<TreeNode> Children = new List<TreeNode>();

        /// <summary>
        /// Gets or sets the path of the folder.
        /// </summary>
        /// <value>
        /// The path of the folder.
        /// </value>
        [NotMapped]
        public string Path { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TreeNode"/> class.
        /// </summary>
        public TreeNode()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TreeNode"/> class.
        /// </summary>
        /// <param name="_parentID">The parent identifier.</param>
        /// <param name="_name">The folder name.</param>
        public TreeNode(int _parentID, string _name)
        {
            ParentID = _parentID;
            Name = _name;
        }
    }
}