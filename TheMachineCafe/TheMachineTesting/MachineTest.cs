using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheMachineCafe.Models;
using TheMachineCafe.Dtos;
using TheMachineCafe.Controllers.Api;
using TheMachineCafe.Controllers;
using System.Collections.Generic;
using System.Data.Entity;
using AutoMapper;
using TheMachineCafe.App_Start;
using System.Security.Principal;
using System.Threading;
using Moq;
using System.Web.Mvc;
using System.Web;
using System.Security.Claims;

namespace TheMachineTesting
{
    [TestClass]
    public class MachineTest
    {
        [TestMethod]
        public void Test_AddSelection()
        {
            Mapper.Initialize(m => m.AddProfile(new MappingProfile()));

            //var controllerContext = new Mock<ControllerContext>();
            //var principal = new Moq.Mock<IPrincipal>();
            //principal.Setup(p => p.IsInRole("Administrator")).Returns(true);
            //principal.SetupGet(x => x.Identity.Name).Returns("Test@machine.fr");
            //controllerContext.SetupGet(x => x.HttpContext.User).Returns(principal.Object);
            //var controller1 = new TheMachineCafe.Controllers.SelectionController();
            //controller1.ControllerContext = controllerContext.Object;

            //var context = new Mock<HttpContextBase>();
            //var mockIdentity = new Mock<IIdentity>();
            //context.SetupGet(x => x.User.Identity).Returns(mockIdentity.Object);
            //mockIdentity.Setup(x => x.Name).Returns("Test@machine.fr");

            var claim = new Claim("test", "IdOfYourChoosing");
            var mockIdentity =
                Mock.Of<ClaimsIdentity>(ci => ci.FindFirst(It.IsAny<string>()) == claim);
            var mockContext = Mock.Of<ControllerContext>(cc => cc.HttpContext.User == mockIdentity);
            var controller1 = new HomeController()
            {
                ControllerContext = mockContext
            };

            string tr = HttpContext.Current.User.Identity.Name;

            var testItem = GetTestSelection();
            var controller= new TheMachineCafe.Controllers.Api.SelectionController();


            var result = controller.AddSelection(testItem) as SelectionDto;

            Assert.AreEqual(testItem.BoissonId, result.BoissonId);
            Assert.AreEqual(testItem.Sucre, result.Sucre);
            Assert.AreEqual(testItem.HasMuge, result.HasMuge);
            Assert.AreEqual(testItem.Id, result.Id);
        }

        [TestMethod]
        public void Test_GetBoissons()
        {
            Mapper.Initialize(m => m.AddProfile(new MappingProfile()));
            var controller = new TheMachineCafe.Controllers.Api.BoissonController();

            var testItem = GetTestBoisson();
            var result = controller.GetBoissons() as List<Boisson>;

            //Assert.AreEqual(testItem.Count, result.Count);
            for (int i = 0; i< 4; i++ )
            {
                Assert.AreEqual(testItem[i].Id, result[i].Id);
                Assert.AreEqual(testItem[i].nom, result[i].nom);
            }
        }

        [TestMethod]
        public void Test_AddBoisson()
        {
            var controller = new TheMachineCafe.Controllers.Api.BoissonController();

            var testItem = GetOneBoisson();
            var result = controller.AddBoisson(testItem) as Boisson;
            Assert.AreEqual(testItem.nom, result.nom);
        }

        [TestMethod]
        public void Test_GetBoisson()
        {
            var controller = new TheMachineCafe.Controllers.Api.BoissonController();

            var testItem = GetOneBoisson();
            var result = controller.GetBoisson(testItem.nom) as Boisson;
            Assert.AreEqual(testItem.nom, result.nom);
        }

        [TestMethod]
        public void Test_DeleteBoisson()
        {
            var controller = new TheMachineCafe.Controllers.Api.BoissonController();

            var testItem = GetOneBoisson();
            bool result = controller.DeleteBoisson(testItem.nom);

            Assert.AreEqual(result, true);
        }


        // Tesst datas
        private SelectionDto GetTestSelection()
        {
            SelectionDto selection = new SelectionDto()
            {
                BoissonId = 1,
                HasMuge = true,
                Sucre = 3                                  
            };
            return selection;          
        }

        private List<Boisson> GetTestBoisson()
        {
            List<Boisson> boissons = new List<Boisson>();
            boissons.Add(new Boisson() { Id = 1, nom = "The a la menthe" });
            boissons.Add(new Boisson() { Id = 2, nom = "The citron" });
            boissons.Add(new Boisson() { Id = 3, nom = "Cafe" });
            boissons.Add(new Boisson() { Id = 4, nom = "Chocolat" });

            return boissons;
        }

        private Boisson GetOneBoisson()
        {
            Boisson boisson = new Boisson() {nom = "cappuccino" };
            return boisson;
        }
    }
}
