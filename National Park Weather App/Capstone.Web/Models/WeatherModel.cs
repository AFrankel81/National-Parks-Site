using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class WeatherModel
    {
        public string ParkCode { get; set; }

        public int FiveDayForecast { get; set; }

        public int LowF { get; set; }

        public int HighF { get; set; }

        public string Forecast { get; set; }

        public int LowC { get; set; }

        public int HighC { get; set; }

        IList<WeatherModel> ForecastList { get; set; }

        public WeatherModel()
        {
        }

        public WeatherModel (string parkCode, int fiveDayForecast, int lowF, int highF, string forecast)
        {
            ParkCode = parkCode;
            FiveDayForecast = fiveDayForecast;
            LowF = lowF;
            HighF = highF;
            Forecast = forecast;
        }
    }
}
