using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HIClaims;
using HIClaims.Controllers;
using HIClaims.Models;



namespace HIClaims.Tests.Controllers
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

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();
            
            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

 
        [TestMethod]
        public void AddClaims_Negative()
        {
            // Arrange
            HomeController controller = new HomeController();

            Claim myClaim = new Claim
            {
                ClaimNo = 1234,
                CustomerName = "Hexaware Technologies",
                ClaimAmount = 1500,
                ClaimedDate = DateTime.Now.AddDays(3),
                Gender = "Male",
                PolicyNo = 987654321
            };

            // Assert
            var result = controller.AddClaims(myClaim) as ViewResult;
            Assert.IsTrue(string.IsNullOrEmpty(result.ViewName) || result.ViewName == "ModalPopup");


        }
    }
}
