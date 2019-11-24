using Capstone.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParksTests.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParksTests
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void TestIndex()
        {
            //Arrange
            ParkMockDAO parkDAO = new ParkMockDAO();
            HomeController controller = new HomeController(parkDAO);

            //Act
            //IActionResult result = controller.Index();

            //Assert

        }
    }
}
