using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheMachineCafe;
using TheMachineCafe.Controllers;
using System.Web.Mvc;

namespace TheMachineTesting.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
