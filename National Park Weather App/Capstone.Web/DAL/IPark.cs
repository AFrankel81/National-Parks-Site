using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public interface IPark
    {
        List<ParkModel> GetAllParks();

        ParkModel GetPark(string parkCode);

        IList<WeatherModel> GetWeather(string parkCode, string tempUnit);
    }
}
