using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Web.Controllers
{
    
    public class ParkController : Controller
    {
        private IPark parkDAO;

        public ParkController(IPark parkDAO)
        {
            this.parkDAO = parkDAO;

        }

        public IActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Details(ParkWeatherViewModel vm)
        {
            string degreeString = HttpContext.Session.GetString("Access");

            if (degreeString == null || degreeString.Length == 0)
            {
                degreeString = "f";
                HttpContext.Session.SetString("Access", degreeString);
                ViewData["Message"] = "f";
            }
            else
            {
                ViewData["Message"] = degreeString;
            }

            ParkModel park = parkDAO.GetPark(vm.ParkCode);

            IList<WeatherModel> weatherList = parkDAO.GetWeather(vm.ParkCode, degreeString);
            park.WeatherList = weatherList;
            return View(park);
        }

        [HttpPost]
        public IActionResult Details(ParkWeatherViewModel vm, ParkModel park)
        {
            HttpContext.Session.SetString("Access", park.WeatherChoice);

            ViewData["Message"] = HttpContext.Session.GetString("Access");

            park = parkDAO.GetPark(vm.ParkCode);

            IList<WeatherModel> weatherList = parkDAO.GetWeather(vm.ParkCode, HttpContext.Session.GetString("Access"));
            park.WeatherList = weatherList;
            return View(park);
        }
    }
}