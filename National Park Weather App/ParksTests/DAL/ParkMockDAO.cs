using Capstone.Web.DAL;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParksTests.DAL
{
    class ParkMockDAO : IPark
    {
        private List<ParkModel> parks = new List<ParkModel>()
        {
            new ParkModel("NP1", "National Park 1", "OH", 10000, 5000, 200, 50, "Woodland", 1980, 100000, "I love national parks", "unknown 1", "Test Park Description 1", 25, 100),
            new ParkModel("NP2", "National Park 2", "CA", 20000, 6000, 300, 60, "Tropical", 1970, 200000, "I love national parks a lot", "unknown 2", "Test Park Description 2", 35, 200),
            new ParkModel("NP3", "National Park 3", "CO", 30000, 6000, 400, 60, "Desert", 1960, 300000, "I love national parks a lot lot", "unknown 3", "Test Park Description 3", 45, 300),
        };

        private List<WeatherModel> weather = new List<WeatherModel>()
        {
            new WeatherModel("NP4", 1, 30, 60, "rain"),
            new WeatherModel("NP4", 2, 40, 70, "partly cloudy"),
            new WeatherModel("NP4", 3, 20, 66, "thunderstorms"),
            new WeatherModel("NP4", 4, 10, 68, "sunny"),
            new WeatherModel("NP4", 5, 35, 59, "rain"),
        };

        public List<ParkModel> GetAllParks()
        {
            return new List<ParkModel>(parks);
        }

        public ParkModel GetPark(string parkCode)
        {
            throw new NotImplementedException();
        }

        public IList<WeatherModel> GetWeather(string parkCode, string tempUnit)
        {
            return new List<WeatherModel>(weather);
        }
    }
}
