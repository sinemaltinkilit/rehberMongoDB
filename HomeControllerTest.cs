using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RehberMongoDB;
using RehberMongoDB.Controllers;

namespace RehberMongoDB.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        HomeController hc = new HomeController();
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            
            Assert.AreEqual("Modify this template to jump-start your ASP.NET MVC application.", result.ViewBag.Message);
        }
        [TestMethod]
        public void Kayit()
        {
            HomeController controller = new HomeController();
            RehberMongoDB.Models.rehberModel rm = new Models.rehberModel()
            {
                //id = 3,
                adi = "unit",
                soyadi = "test",
                telNo = "5555"
            };
            bool expected = true;
            ViewResult actual;
            actual = controller.Kayit(rm) as ViewResult;
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void Listele()
        {

            HomeController controller = new HomeController();
            List<RehberMongoDB.Models.rehberModel> expected = new List<Models.rehberModel>();
            
            List<RehberMongoDB.Models.rehberModel> actual = new List<Models.rehberModel>().ToList();        
            Assert.AreEqual(expected,actual);
        }
        [TestMethod]
        public void Duzenle()
        {
            HomeController controller = new HomeController();
            RehberMongoDB.Models.rehberModel rm = new Models.rehberModel();
           
            ViewResult result = controller.Duzenle(rm) as ViewResult;
            Assert.AreEqual("Modify this template to jump-start your ASP.NET MVC application.", result.ViewBag.Message);
           
        }
        

        [TestMethod]
        public void Sil()
        {
            HomeController controller = new HomeController();
            RehberMongoDB.Models.rehberModel rm = new Models.rehberModel();
            int id = 1; 
            bool expected = true;
            ViewResult actual = controller.Sil(id) as ViewResult;
            Assert.AreEqual(expected, actual);
        }
    }
}
