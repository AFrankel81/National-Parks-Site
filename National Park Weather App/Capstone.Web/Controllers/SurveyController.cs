using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        private ISurvey surveyDAO;
        private IPark parkDAO;

        public SurveyController(ISurvey surveyDAO, IPark parkDAO)
        {
            this.surveyDAO = surveyDAO;
            this.parkDAO = parkDAO;

        }

        public IActionResult Index()
        {
            return RedirectToAction("TakeSurvey", "Survey");
        }

        [HttpGet]
        public IActionResult TakeSurvey()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TakeSurvey(SurveyModel sm)
        {

            if (!ModelState.IsValid)
            {
                return View(sm);
            }

            surveyDAO.TakeSurvey(sm);
            return RedirectToAction("FavParks");
        }

        public IActionResult FavParks()
        {
            IList<SurveyModel> sm = new List<SurveyModel>();
            sm = surveyDAO.GetSurveys();
            return View(sm);
        }
    }
}