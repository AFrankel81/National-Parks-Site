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
    public class SurveyControllerTests
    {
        [TestMethod]
        public void TestFavParks()
        {
            //Arrange
            SurveyMockDAO surveyDAO = new SurveyMockDAO();
            ParkMockDAO parkDAO = new ParkMockDAO();
            SurveyController controller = new SurveyController(surveyDAO, parkDAO);

            //Act
            //IActionResult result = controller.FavParks();

        }

    }
}
