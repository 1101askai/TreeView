using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Web.Mvc;
using TreeHierarchy.Controllers;
using TreeHierarchy.Models;

namespace UnitTestTreeHierarchy
{
    /// <summary>
    /// Class HomeControllerTest is used for test <see cref="HomeController"/> class.
    /// </summary>
    [TestClass]
    public class HomeControllerTest
    {
        /// <summary>
        /// Tests the TreeNodeView method.
        /// </summary>
        [TestMethod]
        public void TestTreeNodeView()
        {
            var controller = new HomeController();
            var actionResult = controller.Index();
            var result = actionResult as ViewResult;
            result.Should().NotBeNull();
            if (result != null)
            {
                var model = result.Model as List<TreeNode>;
                if (model != null)
                {
                    model.Should().NotBeNull();
                }
                else
                {
                    Assert.Fail();
                }
            }
            else
            {
                Assert.Fail();
            }
        }
        /// <summary>
        /// Tests the FolderInfoShowView method.
        /// </summary>
        [TestMethod]
        public void TestFolderInfoShowView()
        {
            var controller = new HomeController();
            string path = "http://localhost/Creating digital images/Graphic Products/Final Product";
            path.Should().BeOfType<string>();
            path.Should().NotBeNull();
            var actionResult = controller.FolderInfoShowView(path);
            var result = actionResult as ViewResult;
            result.Should().NotBeNull();
            if (result != null)
            {
                var model = result.Model as List<TreeNode>;
                if (model == null && result.ViewName == "FolderInfoShowView")
                {
                    model.Should().NotBeNull();
                }
                else if (model != null && result.ViewName == "NotFound")
                {
                    Assert.Fail();
                }
            }
            else
            {
                Assert.Fail();
            }
        }
    }
}
