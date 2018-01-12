using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using TreeHierarchy.Controllers;
using TreeHierarchy.Models;

namespace UnitTestTreeHierarchy.Models
{
    /// <summary>
    /// Class TreeNodeTest is used for test <see cref="ValidationController"/> class.
    /// </summary>
    [TestClass]
    public class TreeNodeTest
    {
        /// <summary>
        /// Tests the folder name validation.
        /// </summary>
        [TestMethod]
        public void TestCreateFolder()
        {
            TreeNode el = new TreeNode(0, "Creating digital images folder");
            if (!Regex.IsMatch(el.Name, @"^[a-zA-Z ]+$"))
            {
                Assert.Fail();
            }
            ValidationController validation = new ValidationController();
            var isValid = validation.IsFolderNameUnique(el);
            isValid.Should().BeOfType<JsonResult>();
            if (!Convert.ToBoolean(isValid.Data))
            {
                Assert.Fail();
            }
        }
    }
}
